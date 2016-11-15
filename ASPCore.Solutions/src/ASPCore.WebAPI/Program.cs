using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace ASPCore.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()                     // initialize WebHost object
                .UseKestrel()                                   // Krestrel : cross platform web server  vs WebListener : Window only webserver
                .UseContentRoot(Directory.GetCurrentDirectory())// application base path = same as wwwroot path
                .UseIISIntegration()                            // Use IIS as reverse proxy server for krestrel webserver
                .UseStartup<Startup>()                          // startup type : is used by WebHost                          
                .Build();                                       // Build() : return Instance of WebHost

            host.Run();                                         // Run() : run the application
        }
    }
}
