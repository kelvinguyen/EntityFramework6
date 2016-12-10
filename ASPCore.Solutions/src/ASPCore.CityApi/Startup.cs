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
using NLog.Extensions.Logging;
using ASPCore.CityApi.Services;
using Microsoft.Extensions.Configuration;
using ASPCore.CityApi.Entities;
using Microsoft.EntityFrameworkCore;


namespace ASPCore.CityApi
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            // order of AddJsonFile is important, last json file call win
            var builder = new ConfigurationBuilder()
                        .SetBasePath(env.ContentRootPath)
                        .AddJsonFile("appSettings.json", optional:false,reloadOnChange:true)
                        .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }
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
#if DEBUG
            services.AddTransient<IMailService,LocalMailService>();
#else
            services.AddTransient<IMailService,CloudMailService>();
#endif
            // EF way 2 : using Contructor
            var connectionstring = @"Server=(localdb)\MSSQLLocalDB;Database=CityInfoDB;Trusted_Connection=True;";
            services.AddDbContext<CityInfoContext>(o => o.UseSqlServer(connectionstring));
            // EF way 1
            //services.AddDbContext<CityInfoContext>();

            //register repository
            services.AddScoped<ICityInfoRepository, CityInfoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,CityInfoContext cityInfoContext)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            //third party logger NLog
            //Long way : loggerFactory.AddProvider(new NLog.Extensions.Logging.NLogLoggerProvider());
            //short way
            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            cityInfoContext.EnsureSeedDataForContext();
            app.UseStatusCodePages();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                // By Default, it will ignore null reference exception
                // cfg.CreateMap<From, To>();
                cfg.CreateMap<Entities.City, Models.CityWithoutPointsOfInterestDto>();
                cfg.CreateMap<Entities.City, Models.CityDto>();
                cfg.CreateMap<Entities.PointOfInterest, Models.PointOfInterestDto>();
                cfg.CreateMap<Models.PointOfInterestForCreationDto, Entities.PointOfInterest>();
                cfg.CreateMap<Models.PointOfInterestForUpdateDto, Entities.PointOfInterest>();
                cfg.CreateMap<Entities.PointOfInterest, Models.PointOfInterestForUpdateDto>();
            });
            app.UseMvcWithDefaultRoute();
        }
    }
}
