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
using IT1.Services;
using IT1.Models;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using IT1.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IT1
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
                .AddEnvironmentVariables(); //Used to override config entries e.g "MailSettings__ToAddress" with Project Environment Variables

            _config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);

            services.AddMvc()
                .AddJsonOptions(config => config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.AddIdentity<IT1User, IdentityRole>(config =>
               {
                   config.User.RequireUniqueEmail = true;
                   config.Password.RequiredLength = 8;
                   config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
               }
            ).AddEntityFrameworkStores<AuthContext>();

            if (_env.IsDevelopment())
            {
                services.AddScoped<IMailService, DebugMailService>();
            }
            else
            {
                //implement real mail service!!
            }


            services.AddDbContext<IT1Context>();
            services.AddDbContext<AuthContext>();

            services.AddScoped<IIT1Repository, IT1Repository>();

            services.AddTransient<IT1ContextSeedData>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app
            , IHostingEnvironment env
            , ILoggerFactory loggerFactory
            , IT1ContextSeedData seeder
        )
        {
            Mapper.Initialize(config =>
                config.CreateMap<ExperienceViewModel, Experience>().ReverseMap()
            );

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            
            //app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseIdentity();

            app.UseMvc(config =>
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                )
            );

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            seeder.EnsureSeedData().Wait();
        }
    }
}
