using GravityCalc;
using GravityData;
using GravityWebExt.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravityWebExt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataProvider provider = new ();
            CalcDataReporter calcReporter = new ("Calculator reporter");
            WebDataReporter webReporter = new("Web repoter");
            calcReporter.Subscribe(provider);
            webReporter.Subscribe(provider);

            provider.SendData(new Data(47.6456, -122.1312));

            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    InitDBData.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
            host.Run();

            calcReporter.Unsubscribe();
            webReporter.Unsubscribe();
            provider.EndTransmission();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
