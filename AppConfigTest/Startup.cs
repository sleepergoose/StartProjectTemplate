using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

using AppConfigTest.Infrastructure;

namespace AppConfigTest
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IWebHostEnvironment env)
        {
            var path = env.ContentRootPath;
            // for pointing to the "appsettings.json"
            Configuration = new ConfigurationBuilder() 
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFilterDiagnostics, DefaultFilterDiagnostics>();
            services.AddScoped<TimeFilter>();
            services.AddScoped<ViewResultDiagnostics>();
            services.AddScoped<DiagnosticsFilter>();
            services.AddScoped<MessageAttribute>();

            services.AddMvc(prop => prop.EnableEndpointRouting = false)
                .AddMvcOptions(options => {
                    options.Filters.Add(new MessageAttribute("Globaly-Scoped Attribute") { Order = 3 });
                });

            //services.AddMvc(prop => prop.EnableEndpointRouting = false).AddMvcOptions(options => {
            //    options.Filters.AddService(typeof(ViewResultDiagnostics));
            //    options.Filters.AddService(typeof(DiagnosticsFilter));
            //});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment() == true)
            {
                app.UseStatusCodePages();
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
