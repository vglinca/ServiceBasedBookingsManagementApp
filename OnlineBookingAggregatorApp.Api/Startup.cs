using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineBookingAggregatorApp.Api.Extensions;
using OnlineBookingAggregatorApp.Api.Hubs;
using OnlineBookingAggregatorApp.Api.Security;
using OnlineBookingAggregatorApp.Core;
using OnlineBookingAggregatorApp.Infrastructure;
using OnlineBookingAggregatorApp.Infrastructure.Constants;
using OnlineBookingAggregatorApp.Infrastructure.Services;
using OnlineBookingAggregatorApp.Infrastructure.Services.Interfaces;
using OnlineBookingAggregatorApp.Persistence.Data;
// ReSharper disable All

namespace OnlineBookingAggregatorApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connString = Configuration["ConnectionStrings:OnlineBookingAggregatorConnectionString"];
            var authOptions = services.ConfigureAuthOptions(Configuration);
            var smtpOptions = services.ConfigureSmtpOptions(Configuration);

            services
                .AddDistributedMemoryCache()
                .AddSession(x => x.IdleTimeout = TimeSpan.FromMinutes(60))
                .AddHttpContextAccessor()
                .ConfigureCors()
                .ConfigureIdentity()
                .ConfigureJwtAuthentication(authOptions)
                .ConfigureAuthorization()
                .ConfigureControllers()
                .AddSmtpClient(smtpOptions)
                .AddTransient<IEmailService, EmailService>()
                .AddTransient<IAppAuthorizationService, AppAppAuthorizationService>()
                .AddTransient<IBookingTimeChecker, BookingTimeChecker>()
                .AddDbContext<AppDbContext>(options => options.UseNpgsql(connString))
                .AddScoped<IAuthorizationHandler, PolicyAuthorizationHandler>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<JwtService>()
                .AddCommands()
                .AddQueries()
                .ConfigureSwaggerDoc()
                .AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionPages(env);
            app.UseExceptionHandlingMiddleware();
            app.UseStaticFiles();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseSession();
            app.UseRouting();
            app.UseCorsMiddleware();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>(AppConstants.Parameters.HubEndpoint);
            });
        }
    }
}