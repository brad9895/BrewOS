using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BrewOS;
using BrewOS.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace VancouverBrewingOS
{
    public class Program
    {
        public static void Main(string[] args)
        {


            using (var db = new BrewOSContext())
            {
                db.Database.EnsureCreated();
                db.Brews.Add(new Beer());

                BuildWebHost(args).Run();
            }
            
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
