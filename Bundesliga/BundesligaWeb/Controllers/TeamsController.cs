using BundesligaDomain;
using BundesligaEF;
using BundesligaWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace BundesligaWeb.Controllers
{
    public class TeamsController : Controller
    {
        private IRepository<Team> _repository;
        private IPlayerRepository _playerRepository;

        public TeamsController(IRepository<Team> repository,IPlayerRepository playerRepository)
        {
            _repository = repository;
            _playerRepository = playerRepository;
        }

        public IActionResult Index()
        {
            var teams = _repository.Get();
            return View(teams);
        }
        public IActionResult Team(int id)
        {
            var team = _repository.GetById(id);
            var vm = new TeamViewModel();
            vm.Name = team.Name;
            vm.Photo = team.Photo;
            vm.Players = _playerRepository.TeamPlayers(id);
            return View(vm);
        }
        public IActionResult Player(int id=2)
        {
            return View();
        }
    }
}