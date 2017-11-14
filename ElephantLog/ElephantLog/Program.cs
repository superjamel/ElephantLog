using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace ElephantLog
{
    public class Program
    {
        public static string AsciiiElephant = @"
          / \__/ \_____
         /  /  \  \    `\
         )  \''/  (     |\
         `\__)/__/'_\  / `
            //_|_|~|_|_|   ";

       

        public static void Main(string[] args)
        {
            Console.WriteLine(AsciiiElephant);
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var webHost = new WebHostBuilder()
               .UseKestrel()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .ConfigureAppConfiguration((hostingContext, config) =>
               {
                   var env = hostingContext.HostingEnvironment;
                   config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                         .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                   config.AddEnvironmentVariables();
               })
               .UseStartup<Startup>()
               .UseSerilog(new LoggerConfiguration()
                            .MinimumLevel.Is(LogEventLevel.Information)
                            .Enrich.FromLogContext()
                            .WriteTo.Console(LogEventLevel.Information)
                            .WriteTo.MongoDB("mongodb://localhost/logs", collectionName: "appAudits")
                            .CreateLogger())
                            .Build();
            return webHost;
        }
    }
}
