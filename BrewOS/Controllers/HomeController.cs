using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BrewOS.Data;
using BrewOS.Hubs;
using BrewOS.Models;
using BrewOS.Models.UserAccounts;
using BrewOS.Models.Vessels;
using Microsoft.AspNetCore.Mvc;
using OneWire;

namespace BrewOS.Controllers
{
    public class HomeController : Controller
    {
        //public List<string> test = new List<string>() { "1", "2", "3", "4" };

        public List<Card> cards = new List<Card>()
        {
            new OnTapCard()
            {
                name = "Test One",
                style = "Test Style",
                image="./images/BeerImages/amber-ale.jpg",
                onTapName ="One",
                abv = "5",
                description = "sf;lkjgl"

            }

        };

        private BrewOSContext _context;
        private TemperatueHubService _service;
        private OneWireBus _bus = OneWireBus.Instance;

        public HomeController(BrewOSContext context, TemperatueHubService service)
        {
            _context = context;
            _service = service;

        }

        public IActionResult Index()
        {
            //return View();
            return View(cards);
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
