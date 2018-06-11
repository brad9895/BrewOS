using BrewOS.Data;
using BrewOS.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

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

                BuildWebHost(args).Run();

                

            //}
            
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
