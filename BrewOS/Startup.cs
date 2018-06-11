using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BrewOS.Models;
using BrewOS.Data;
using OneWire;
using BrewOS.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace BrewOS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            OneWireBus.InitializeBus(2000);
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BrewOSContext>(options =>
                options.UseSqlite("Data Source=BrewOS.db"));

            services.AddMvc();

            services.AddSignalR(options => options.EnableDetailedErrors = true);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

 
            app.UseStaticFiles();

            app.UseSignalR(routes =>
            {
                routes.MapHub<TemperatueHub>("/temperatureHub");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
