using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OnlineBookingAggregatorApp.Api.Security;
using OnlineBookingAggregatorApp.Domain.Entities;
using OnlineBookingAggregatorApp.Domain.Enums;
using OnlineBookingAggregatorApp.Infrastructure;
using OnlineBookingAggregatorApp.Infrastructure.Constants;
using OnlineBookingAggregatorApp.Infrastructure.Settings;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddCommandQueryHandlers(this IServiceCollection services, Type handlerInterface)  
        {  
            var handlers = typeof(Mediator).Assembly.GetTypes()  
                .Where(t => t.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface));  
  
            foreach (var handler in handlers)
            {
                services.AddTransient(
                    handler.GetInterfaces()
                        .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface), handler);
            }

            return services;
        }

        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assembly = Assembly.GetAssembly(typeof(Command<>));
            var commandTypes = assembly.ExportedTypes.Where(type =>
                type.BaseType != null && (type.BaseType == typeof(Command) || (type.BaseType.IsConstructedGenericType &&
                    (type.BaseType.GetGenericTypeDefinition() == typeof(Command<>) || type.BaseType.GetGenericTypeDefinition() == typeof(Command<,>)))));

            foreach (var commandType in commandTypes)
            {
                services.AddTransient(commandType);
            }
            
            return services;
        }

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            var assembly = Assembly.GetAssembly(typeof(Query<>));
            var queryTypes = assembly.ExportedTypes.Where(type =>
                type.BaseType != null && type.BaseType.IsConstructedGenericType &&
                (type.BaseType.GetGenericTypeDefinition() == typeof(Query<>) || type.BaseType.GetGenericTypeDefinition() == typeof(Query<,>)));

            foreach (var queryType in queryTypes)
            {
                services.AddTransient(queryType);
            }

            return services;
        }

        public static IServiceCollection ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssemblies(new[] {typeof(Startup).Assembly, typeof(Command).Assembly});
                    opt.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                })
                .AddXmlDataContractSerializerFormatters()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = ctx =>
                    {
                        var problemDetails = new ValidationProblemDetails(ctx.ModelState)
                        {
                            Title = AppConstants.TextMessages.ValidationProblemTitle,
                            Status = StatusCodes.Status400BadRequest,
                            Detail = AppConstants.TextMessages.ValidationProblemDetails,
                            Instance = ctx.HttpContext.Request.Path
                        };
                        problemDetails.Extensions.Add(AppConstants.Parameters.TraceId, ctx.HttpContext.TraceIdentifier);

                        return new UnprocessableEntityObjectResult(problemDetails)
                        {
                            ContentTypes = {AppConstants.TextMessages.ErrorMessageContentType}
                        };
                    };
                });
            
            return services;
        }

        public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            static void Options(IdentityOptions cfg)
            {
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
            }

            services.AddIdentity<User, Role>(Options)
                .AddRoles<Role>()
                //.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<User, Role>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddUserManager<UserManager<User>>()
                .AddSignInManager<SignInManager<User>>()
                .AddErrorDescriber<IdentityErrorDescriber>();
                //.AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(Options);

            return services;
        }

        public static AuthOptions ConfigureAuthOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var authOptionsConfigurationSection = configuration.GetSection(nameof(AuthOptions));
            services.Configure<AuthOptions>(authOptionsConfigurationSection);
            var authOptions = authOptionsConfigurationSection.Get<AuthOptions>();
            
            return authOptions;
        }

        public static SmtpOptions ConfigureSmtpOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection(nameof(SmtpOptions));
            services.Configure<SmtpOptions>(section);
            var smtpOptions = section.Get<SmtpOptions>();

            return smtpOptions;
        }

        public static IServiceCollection AddSmtpClient(this IServiceCollection services, SmtpOptions smtpOptions)
        {
            services.AddTransient(_ => new SmtpClient
            {
                Host = smtpOptions.SmtpServer,
                Port = smtpOptions.Port,
                Credentials = new NetworkCredential(smtpOptions.From, smtpOptions.Password)
            });

            return services;
        }

        public static IServiceCollection AddConfigOptions<TOptions>(this IServiceCollection services,
            IConfiguration configuration, string section) where TOptions : class, new()
        {
            services.Configure<TOptions>(configuration.GetSection(section));
            services.AddSingleton(x => x.GetRequiredService<IOptions<TOptions>>().Value);

            return services;
        }

        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(x => x.AddPolicy(
                AppConstants.Parameters.AllowOrigin,
                builder => builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            ));

            return services;
        }

        public static IServiceCollection ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                var requirements = GeneratePolicyRequirements();
                foreach (var req in requirements)
                {
                    options.AddPolicy(req.PolicyName, policy => policy.Requirements.Add(req));
                }
            });

            return services;
        }

        private static IList<PolicyAssigned> GeneratePolicyRequirements()
        {
            var requirements = Enum.GetValues(typeof(Policy))
                .Cast<Policy>()
                .Select(policy => new PolicyAssigned(policy.ToString()))
                .ToList();
            
            return requirements;
        } 

        public static IServiceCollection ConfigureJwtAuthentication(this IServiceCollection services, AuthOptions options)
        {
            services
                .AddAuthentication(cfg =>
                {
                    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = options.Issuer,
                        ValidateAudience = true,
                        ValidAudience = options.Audience,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = options.GetSymmetricSecurityKey()
                    };

                    cfg.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = ctx =>
                        {
                            if (ctx.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                ctx.Response.Headers.Add(AppConstants.Parameters.TokenExpired, "true");
                            }

                            return Task.CompletedTask;
                        },
                        OnMessageReceived = ctx =>
                        {
                            var accessToken = ctx.Request.Query["access_token"];
                            var path = ctx.HttpContext.Request.Path;
                            if (!string.IsNullOrWhiteSpace(accessToken) && 
                                path.StartsWithSegments(AppConstants.Parameters.HubEndpoint))
                            {
                                ctx.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            return services;
        }

        public static IServiceCollection ConfigureSwaggerDoc(this IServiceCollection services)
        {
            services.AddSwaggerDocument(doc =>
            {
                doc.Title = AppConstants.TextMessages.SwaggerDocName;
                doc.Version = AppConstants.TextMessages.SwaggerDocVersion;
                doc.SerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                };
            });

            return services;
        }
    }
}