using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BundesligaEF;
using BundesligaWeb.ViewModels;
using BundesligaDomain;
using AutoMapper;
using BundesligaServices.Interfaces;

namespace BundesligaWeb.Controllers
{
    [Route("[controller]")]
    public class StandingsController : Controller
    {
        private IStandingsServices _standingsServices;

        public StandingsController(IStandingsServices standingsServices)
        {            
            _standingsServices = standingsServices;
        }
        public IActionResult Index(int id)
        {
            var standingDetails = _standingsServices.GetStandingsDetails(id);
            var vms = Mapper.Map<StandingDetailsViewModel>(standingDetails);
           
            return View(vms);
        }
    }
}