using BrewOS.Data;
using BrewOS.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OneWire;
using System.Linq;

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
            
            
           services.AddSingleton(typeof(TemperatueHubService), typeof(TemperatueHubService));


            services.AddSignalR(options => options.EnableDetailedErrors = true)
                .AddMessagePackProtocol();

            services.AddCors();

            //var provider = services.BuildServiceProvider();
            //var context = provider.GetService<IHubContext<TemperatueHub>>();



            //var service = new TemperatueHubService(context);
            //services.AddSingleton(service);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
               
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

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

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.Use(async (context, next) =>
            {
                var forwardedPath = context.Request.Headers["X-Forwarded-Path"].FirstOrDefault();
                if (!string.IsNullOrEmpty(forwardedPath))
                {
                    context.Request.PathBase = forwardedPath;
                }

                await next();
            });
        }
    }
}
