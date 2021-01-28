using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

using AppConfigTest.Infrastructure;
using AppConfigTest.Models;

namespace AppConfigTest
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        private IWebHostEnvironment hostEnv;

        public Startup(IWebHostEnvironment env)
        {
            hostEnv = env;
            var path = hostEnv.ContentRootPath;
            // for pointing to the "appsettings.json"
            Configuration = new ConfigurationBuilder() 
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IModelStorage, DictionaryStorage>();
            services.AddScoped<IRepository>(provider => {
                if (hostEnv.IsDevelopment())
                {
                    var x = provider.GetService<MemoryRepository>();
                    return x;
                }
                else
                {
                    return new AlternateRepository();
                    //var x = provider.GetService<AlternateRepository>();
                    //return x;
                }
            });

            // TypeBroker.SetRepoType<AlternateRepository>();
            services.AddTransient<MemoryRepository>();
            //services.AddTransient<AlternateRepository>();
            //services.AddSingleton<IRepository, MemoryRepository>();
            services.AddTransient<ProductTotalizer>();
            services.AddMvc(prop => prop.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
 
                app.UseStatusCodePages();
                app.UseDeveloperExceptionPage();

            // app.ApplicationServices.GetService<IRepository>();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
