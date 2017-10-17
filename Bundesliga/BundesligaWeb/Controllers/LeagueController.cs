using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BundesligaEF;
using BundesligaWeb.ViewModels;
using BundesligaServices;
using BundesligaServices.Interfaces;
using AutoMapper;

namespace BundesligaWeb.Controllers
{
    [Route("[controller]")]
    public class LeagueController : Controller
    {
       
        private ILeagueServices _leagueServices;

        public LeagueController( ILeagueServices leagueservices)
        {
            _leagueServices = leagueservices;
        }
        [HttpGet]
        public IActionResult Index()
        {

            var leagues = _leagueServices.GetAllLeagues();
            var vm = Mapper.Map<IEnumerable<LeagueViewModel>>(leagues);           

            return View(vm);
        }
    }
}