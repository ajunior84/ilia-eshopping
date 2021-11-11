using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IliaEShopping.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .ConfigureAppConfiguration((webHostBuilderContext, configBuilder) =>
                        {
                            var env = webHostBuilderContext.HostingEnvironment;
                            var root = Directory.GetCurrentDirectory();

                            configBuilder
                                .AddJsonFile(Path.Combine(root, "appsettings.json"), optional: true, reloadOnChange: true)
                                .AddJsonFile(Path.Combine(root, $"appsettings.{env.EnvironmentName}.json"), optional: true, reloadOnChange: true);

                            configBuilder.AddEnvironmentVariables();
                        })
                        .UseSockets()
                        .UseStartup<Startup>();
                });
    }
}
