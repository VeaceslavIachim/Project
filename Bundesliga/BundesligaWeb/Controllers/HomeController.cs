using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BundesligaEF;
using BundesligaDomain;
using BundesligaWeb.Services;

namespace BundesligaWeb.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Team> _repository;

        public HomeController(IRepository<Team> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var news = new NewsService();
            var newsList = news.GetNews().ToList();
            
            return View(newsList);
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
