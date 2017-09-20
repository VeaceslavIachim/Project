using Microsoft.AspNetCore.Mvc;
using BundesligaWeb.ViewModels;
using BundesligaEF;
using System;
using System.Linq;

namespace BundesligaWeb.Controllers
{
    [Route("[controller]")]
    public class PlayerController : Controller
    {
        private IPlayerRepository _repository;

        public PlayerController(IPlayerRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{id}")]
        public IActionResult Index(int id=2)
        {
            var player = _repository.GetPlayerDetails(id);

            var vm = new PlayerDetailsViewModel();
            vm.Name = $"{player.LastName} {player.FirstName}";
            //vm.LastName = player.LastName;
            vm.Number = player.Number;
            vm.Position =player.Position.Name;
            vm.Country = player.Country.Name;
            vm.Height = player.Height;
            vm.Age = (DateTime.Now.Year - player.Age.Year);
            return View(vm);
        }
    }
}