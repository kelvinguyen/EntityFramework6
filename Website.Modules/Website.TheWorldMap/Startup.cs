using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Website.TheWorldMap.Services;
using Microsoft.Extensions.Configuration;
using Website.TheWorldMap.Models;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using Website.TheWorldMap.ViewModels;

namespace Website.TheWorldMap
{
    public class Startup
    {
        private IHostingEnvironment _en;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment en)
        {
            _en = en;
            var builder = new ConfigurationBuilder()
                        .SetBasePath(_en.ContentRootPath)
                        .AddJsonFile("config.json")
                        .AddEnvironmentVariables();
                        
            _config = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);
            if (_en.IsDevelopment())
            {
                services.AddScoped<IMailService, DebugMailService>();
            }
            else
            {
                // implement real mail service
            }
            services.AddTransient<WorldContextSeedData>();
            services.AddDbContext<WorldContext>();
            services.AddScoped<IWorldRepository, WorldRepository>();
            services.AddMvc().AddJsonOptions(config => 
                                                {
                                                    config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                                                });
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env, 
                              ILoggerFactory loggerFactory,
                              WorldContextSeedData seeder)
        {
            Mapper.Initialize(config =>
                                    {
                                        config.CreateMap<TripViewModel, Trip>().ReverseMap();
                                        config.CreateMap<StopViewModel, Stop>().ReverseMap();
                                    });

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddDebug(LogLevel.Information);
            }
            else
            {
                loggerFactory.AddDebug(LogLevel.Error);
            }


            app.UseMvc(config => config.MapRoute(
                    name : "default",
                    template : "{Controller}/{Action}/{Id?}",
                    defaults : new { Controller = "App", action = "Index" }
                ));
            //app.UseDefaultFiles();
            app.UseStaticFiles();

            seeder.EnsureSeedData().Wait();
        }
    }
}
