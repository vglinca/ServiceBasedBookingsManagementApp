using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using OnlineBookingAggregatorApp.Api.Middleware;
using OnlineBookingAggregatorApp.Infrastructure.Constants;

namespace OnlineBookingAggregatorApp.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }

        private static void UseClientExceptionPage(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async ctx =>
                {
                    ctx.Response.StatusCode = 500;
                    await ctx.Response.WriteAsync(AppConstants.TextMessages.Status500Message);
                });
            });
        }

        public static void UseExceptionPages(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                return;
            }

            app.UseClientExceptionPage();
        }

        public static void UseTokenMiddleware(this IApplicationBuilder app)
        {
            app.Use(async (ctx, nxt) =>
            {
                var token = ctx.Session.GetString(AppConstants.Parameters.JwtToken);
                if (!string.IsNullOrWhiteSpace(token))
                {
                    ctx.Request.Headers.Add(AppConstants.Parameters.Authorization, $"{AppConstants.Parameters.Bearer} {token}");
                }

                await nxt();
            });
        }

        public static void UseCorsMiddleware(this IApplicationBuilder app)
        {
            app.UseCors(AppConstants.Parameters.AllowOrigin);
        }
    }
}