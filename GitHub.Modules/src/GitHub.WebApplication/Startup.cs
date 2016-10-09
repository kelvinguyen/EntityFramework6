using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using GitHub.WebApplication.Entity.DataContext;
using GitHub.WebApplication.Entity.DataSeed;
using GitHub.WebApplication.Entity.Repository;
using Newtonsoft.Json.Serialization;

namespace GitHub.WebApplication
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
            services.AddMvc().AddJsonOptions(config =>
            {
                config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            }); 
            services.AddDbContext<PersonContext>();
            services.AddTransient<PersonSeedData>();
            services.AddScoped<IPersonRepo, PersonRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                            IHostingEnvironment env, 
                            ILoggerFactory loggerFactory,
                            PersonSeedData seeder)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            

            app.UseMvc(config =>
                            {
                                config.MapRoute(
                                        name: "default",
                                        template: "{Controller}/{Action}/{Id?}",
                                        defaults: new { controller = "App",action="Index" }
                                    );
                            });
            seeder.EnsureSeedData().Wait();

        }
    }
}
