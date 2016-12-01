using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace ASPCore.CityApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    // adding option for xml format : using pakage "Microsoft.AspNetCore.Mvc.Formatter.Xml"
                    .AddMvcOptions(opt => {
                        opt.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                    });
                    // change to camel case for json using Newtonsoft.Json.Serialization;
                    //.AddJsonOptions(opt => {
                    //    if (opt.SerializerSettings.ContractResolver != null)
                    //    {
                    //        var castedResolver = opt.SerializerSettings.ContractResolver 
                    //                             as DefaultContractResolver;
                    //        castedResolver.NamingStrategy = null;
                    //    }
                    //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
        }
    }
}
