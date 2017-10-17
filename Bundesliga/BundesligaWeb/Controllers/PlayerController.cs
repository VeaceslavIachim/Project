using Microsoft.AspNetCore.Mvc;
using BundesligaWeb.ViewModels;
using BundesligaEF;
using System;
using System.Linq;
using AutoMapper;
using BundesligaServices.Interfaces;

namespace BundesligaWeb.Controllers
{
    [Route("[controller]")]
    public class PlayerController : Controller
    {
        private IPlayerServices _playerServices;

        public PlayerController(IPlayerServices playerServices)
        {
            _playerServices = playerServices;
        }
        [HttpGet("{id}")]
        public IActionResult Index(int id=2)
        {
            var player = _playerServices.GetPlayerDetails(id);
            var vm = Mapper.Map<PlayerDetailsViewModel>(player);

            return View(vm);
        }
    }
}