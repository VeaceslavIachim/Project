using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BundesligaEF;
using BundesligaWeb.ViewModels;

namespace BundesligaWeb.Controllers
{
    [Route("[controller]")]
    public class LeagueController : Controller
    {
        private IleagueRepository _leagueRepository;

        public LeagueController(IleagueRepository leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var leagues = _leagueRepository.GetLeagues();
            var vmList = leagues
                .Select(item =>new LeagueViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Country = item.Country.Name,
                    Photo = item.Photo
                })
                .ToList();
            
            return View(vmList);
        }
    }
}