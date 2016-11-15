using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ASPCore.WebAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        /*
         * ConfigureServices :  - Add services to the container
         *                      - Container : is use for dependency injection
         *                      - ConfigureServices() : is optional method
         * 
         * Services : - 
         * */
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); // intellisense didn't work for this
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        /**
         *  Configure :  - After ConfigureServices Method
         *               - How asp.net core will response to HttpRequest
         */
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
