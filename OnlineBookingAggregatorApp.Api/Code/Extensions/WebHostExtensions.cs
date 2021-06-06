using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineBookingAggregatorApp.Persistence.Data;

namespace OnlineBookingAggregatorApp.Api.Extensions
{
    public static class WebHostExtensions
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var ctx = services.GetRequiredService<AppDbContext>();
                ctx.Database.Migrate();
                ctx.SeedPolicies();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return host;
        }
        
        public static IHostBuilder SetLogging(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureLogging(
                (_, logging) =>
                {
                    logging.SetMinimumLevel(LogLevel.Information);
                    logging.AddConsole();
                });

            return hostBuilder;
        }
    }
}