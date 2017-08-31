using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BundesligaEF;

namespace BundesligaWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var context = new BundesligaContext();
            var positions = context.Positions;
            return View(positions);
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

        public IActionResult Error()
        {
            return View();
        }
    }
}
