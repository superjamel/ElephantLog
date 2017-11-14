using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

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
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
