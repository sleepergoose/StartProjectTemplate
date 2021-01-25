using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

using Microsoft.AspNetCore.Routing;
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
            services.Configure<RouteOptions>(options => 
                options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint)));
           
            services.AddMvc(prop => prop.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment() == true)
            {
                app.UseStatusCodePages();
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseMvc(routes => {
                routes.MapRoute(
                        name: "areas",
                        template: "{area:exists}/{controller=Home}/{action=Index}"
                    );
                 routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
            });

            /* 
             * 
             *             app.UseMvc(routes => {
                                routes.MapRoute(
                                    name: null,
                                    template: "{controller}/{action}/{id?}/{*catchall}",
                                    defaults: new { controller = "Home", action="CustomVariable" },
                                    constraints: new { id = new Microsoft.AspNetCore.Routing.Constraints
                                        .RegexRouteConstraint(@"^1\d{2}$")});
             * 
             *  routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}/{id?}/{*catchall}",
                    defaults: new { controller = "Home", action="CustomVariable" },
                    constraints: new { id = new Microsoft.AspNetCore.Routing.Constraints.IntRouteConstraint() });

             * id:int? - segment id, type int, nullable (/123/)
             * *catchall = changable amount of segments (/Seg1/Seg2/)
             *  /Home/CustomVariable/123/Seg1/Seg2/...
             *  
             *  
             *  
             */
        


            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: null,
            //        template: "{controller}/{action}",
            //        defaults: new { controller = "Home", action = "Index" });

            //    routes.MapRoute(
            //        name: null,
            //        template: "Public{controller=Customer}/{action=Index}"
            //        );
            //});
        }
    }
}
