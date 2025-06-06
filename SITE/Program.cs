using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SITE
{
    public class Program
    {
        public static void Main(string[] args)
        {

            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4Net.config"));
            var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                       typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);



            CreateHostBuilder(args).Build().Run();

           // var host = new WebHostBuilder()
           //.UseKestrel()
           //.UseContentRoot(Directory.GetCurrentDirectory())
           //.UseIISIntegration()
           //.UseStartup<Startup>()
           //.Build();

           // host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) => 
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseSetting("detailedErrors","true");
                    webBuilder.CaptureStartupErrors(true);
                    //webBuilder.UseKestrel();
                    //webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    //webBuilder.UseIISIntegration();
                    // webBuilder.Build();

                });
    }
}
