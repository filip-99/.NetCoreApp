using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books
{
    public class Program
    {
        // Klasa koja se prva izvršava Program.cs i njena metoda main()
        public static void Main(string[] args)
        {
            // Main() poziva CreateHostBuilder(args).Build().Run() metodu koja podešava da početna klasa bude Startup.cs klasa
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
