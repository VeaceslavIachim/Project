using BundesligaDomain;
using BundesligaEF;
using BundesligaWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BundesligaWeb.Controllers
{
    [Route("[controller]")]
    public class TeamsController : Controller
    {
        private IRepository<Team> _repository;
        private IPlayerRepository _playerRepository;
        private ITeamRepository _teamRepository;

        public TeamsController(
            IRepository<Team> repository,
            IPlayerRepository playerRepository,
            ITeamRepository teamRepository)
        {
            _repository = repository;
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var teams = _teamRepository.GetLiguesTeams(id);

            return View(teams);
        }

        [HttpGet("{id}")]
        public IActionResult Team(int id)
        {
            var team = _repository.GetById(id);
            var vm = new TeamViewModel();
            vm.Name = team.Name;
            vm.Photo = team.Photo;
            vm.Players = _playerRepository.GetTeamPlayers(id).Select(x => new PlayerViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            });
            return View(vm);
        }

    }
}