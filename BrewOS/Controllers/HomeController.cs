using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrewOS.Models;
using BrewOS.Models.UserAccounts;
using BrewOS.Models.Vessels;

namespace BrewOS.Controllers
{
    public class HomeController : Controller
    {
        //public List<string> test = new List<string>() { "1", "2", "3", "4" };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        
        public IActionResult Temperature()
        {
            Fermenter ferm1 = new Fermenter
            {
                Name = "test_ferm1",
                TargetTemp = 65
            };
            Fermenter ferm2 = new Fermenter
            {
                Name = "test_ferm2",
                TargetTemp = 65
            };
            Fermenter ferm3 = new Fermenter
            {
                Name = "test_ferm3",
                TargetTemp = 65
            };
            List<Fermenter> ferms = new List<Fermenter> { ferm1, ferm2, ferm3 };
            ViewData["Message"] = ferms;

            return View();
        }

        public IActionResult Login()
        {
            //ViewData["Message"] = "Scan your QR code.";

            return View();
        }

        [HttpPost]
        public IActionResult Login(User scannedUser)
        {
            //ViewData["Message"] = "Scan your QR code.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
