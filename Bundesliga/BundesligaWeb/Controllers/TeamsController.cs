using AutoMapper;
using BundesligaDomain;
using BundesligaEF;
using BundesligaServices.Interfaces;
using BundesligaWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BundesligaWeb.Controllers
{
    [Route("[controller]")]
    public class TeamsController : Controller
    {
        private ITeamsServices _teamServices;

        public TeamsController(ITeamsServices teamsServices)
        {
            _teamServices = teamsServices;
        }
        
        [HttpGet("{id}")]
        public IActionResult Team(int id)
        {
            var team = _teamServices.GetTeamDetails(id);
            var vm = Mapper.Map<TeamViewModel>(team);
            
            return View(vm);
        }

    }
}