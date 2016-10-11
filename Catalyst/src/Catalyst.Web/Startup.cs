using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Catalyst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Catalyst.Domain.DataSeed;
using Catalyst.Domain.Repos;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using Catalyst.Web.ViewModels;

namespace Catalyst.Web
{
    public class Startup
    {
        private IHostingEnvironment _env;

        private IConfigurationRoot _config;


        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath) 
                .AddJsonFile("config.json")
                .AddEnvironmentVariables(); 

            _config = builder.Build();


           
            using (var context = new PersonContext(_config, new DbContextOptions<PersonContext>()))
            {
                try
                {
                    context.Person.Any();
                }
                catch (Exception ex)
                {
                    context.Database.Migrate();
                }

            }
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddSingleton(_config);
            services.AddTransient<SeedData>();
            services.AddDbContext<PersonContext>();
            services.AddScoped<IPersonRepos, PersonRepos>();
            services.AddMvc()
                .AddJsonOptions(
                    config =>
                        config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver()

                )
                .AddJsonOptions(
                    config =>
                        config.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter())
                );
        }

        
        public void Configure(IApplicationBuilder app,IHostingEnvironment env,ILoggerFactory loggerFactory,SeedData seeder)
        {
            
            Mapper.Initialize(config =>
                    {
                        config.CreateMap<PersonViewModel, Person>().ReverseMap();
                    }
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddDebug(LogLevel.Information);
            }
            else
            {
                loggerFactory.AddDebug(LogLevel.Error);
            }

            app.UseStaticFiles();
            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Search", action = "Index" }
               );
            }
            );

            seeder.EnsureSeedData().Wait();
        }
    }
}
