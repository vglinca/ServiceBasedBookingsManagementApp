using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using OnlineBookingAggregatorApp.Api.Extensions;

namespace OnlineBookingAggregatorApp.Api
{
    public class Program
    {
        public static void Main(string[] args) => 
            CreateHostBuilder(args)
                .SetLogging()
                .Build()
                .MigrateDatabase()
                .Run();

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}