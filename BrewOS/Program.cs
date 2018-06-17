using BrewOS.Data;
using BrewOS.Models;
using BrewOS.Models.Sensors.TemperatureSensors;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BrewOS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            //using (var context = BrewOSContext.Instance)
            //{
            //    context.Database.EnsureCreated();

                //db.Accounts.Add(new User()
                //{
                //    UserID = 1,
                //    ContactInfo = new ContactInformation()
                //    {
                //        UserID = 1,
                //        LastName = "Mitchell",
                //        FirstName = "Bradley",
                //        PhoneNumber = "(716)866-8168"
                //    },
                //    PermissionSet = new UserPermissions() { PermissionSetID = "Admin" }
                //});

            //    var x = Accounts.Instance;
            //    context.SaveChanges();

                BuildWebHost(args).InitializeTestDB().Run();

                

            //}
            
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        
    }
    public static class StartupExtensions
    {
        public static IWebHost InitializeTestDB(this IWebHost webHost)
        {
            var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<BrewOSContext>();

                if (dbContext != null)
                {
                    initializeDB(dbContext);
                }
            }

            return webHost;
        }

        private static async void initializeDB(BrewOSContext context)
        {
            if (!await context.Sensors.AnyAsync())
            {
                var item = new TemperatureSensor()
                {
                    Address = "ADR",
                    Name = "NM"
                };
                context.Sensors.Add(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
