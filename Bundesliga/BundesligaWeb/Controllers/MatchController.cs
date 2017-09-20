using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BundesligaDomain;
using BundesligaEF;
using BundesligaWeb.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace BundesligaWeb.Controllers
{
    [Route("[controller]")]
    public class MatchController : Controller
    {
        private IRepository<Team> _repository;
        private IMatchRepository _matchRepository;
        private IPlayerRepository _playerRepository;
        private IRepository<MatchStatistics> _statisticsRepository;
        private IStandingsRepository _standingsRepository;

        public MatchController(IRepository<Team> repository,
            IMatchRepository matchRepository, 
            IPlayerRepository playerRepository,
            IRepository<MatchStatistics> statisticsRepository,
            IStandingsRepository standingsRepository)
        {
            _repository = repository;
            _matchRepository = matchRepository;
            _playerRepository = playerRepository;
            _statisticsRepository = statisticsRepository;
            _standingsRepository = standingsRepository;
        }
        [HttpGet("Matches")]      
        public IActionResult Index()
        {
            var match = _matchRepository.Get();
            var vm = new List<MatchesViewViewModel>();
            vm = match.Select(m => new MatchesViewViewModel
            {
                Id = m.Id,
                HomeTeam = m.HomeTeam.Name,
                HomeTeamPhoto = m.HomeTeam.Photo,
                HomeTeamScore = m.HomeTeamScore,
                AwayTeam = m.AwayTeam.Name,
                AwayTeamPhoto = m.AwayTeam.Photo,
                AwayTeamScore = m.AwayTeamScore,
                Date = m.MatchDate

            }).ToList();

            return View(vm);
        }
        [HttpGet("AddMatch")]      
        [Authorize]
        public IActionResult AddMatch()
        {
            var teams = _repository.Get();
            var vm = new MatchViewModel();
            vm.Teams = teams.Select(item => new SelectListItem { Value = item.Id.ToString(), Text = item.Name }).ToList();


            return View(vm);
        }
        [HttpPost("AddMatch")]
        public IActionResult AddMatch(MatchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var match = new Match();
                match.LeagueId = vm.LeagueId;
                match.HomeTeamId = vm.HomeTeamId;
                match.AwayTeamId = vm.AwayTeamId;
                match.HomeTeamScore = vm.HomeTeamScore;
                match.AwayTeamScore = vm.AwayTeamScore;
                match.MatchDate = vm.MatchDate;
                _matchRepository.Insert(match);

                return RedirectToAction("AddStatistic", new { id = match.Id });
            }
            return View(vm);
            //return RedirectToAction($"AddStatistic({vm.Id})");
        }
        [HttpGet("{id}/statistics")]    
        [Authorize]
        public IActionResult AddStatistic(int id)
        {
            var match = _matchRepository.GetById(id);
            var homeTeamPlayers = _playerRepository.GetTeamPlayers(match.HomeTeamId);
            var awayTeamPlayers = _playerRepository.GetTeamPlayers(match.AwayTeamId);

            var vm = new MatchStatisticsViewModel();
            vm.MatchId = id;
            vm.HomePlayers = homeTeamPlayers
                .Select(item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = $"{item.FirstName} {item.LastName}"
                })
                .ToList();

            vm.AwayPlayers = awayTeamPlayers
               .Select(item => new SelectListItem
               {
                   Value = item.Id.ToString(),
                   Text = $"{item.FirstName} {item.LastName}"
               })
               .ToList();

            return View(Enumerable.Repeat(vm, 28).ToList());
        }
        [HttpPost("{id}/statistics")]
       public IActionResult AddStatistic(int id,IList<MatchStatisticsViewModel> vm)
        {

            var matchStatistics = vm.Select(m => new MatchStatistics
            {
                PlayerId = m.PlayerId,
                MatchId = id,
                GoalsScored = m.GoalsScored,
                MinutesPlayed = m.MinutesPlayed,
                YellowCards = m.YellowCards,
                RedCards = m.RedCards,
                TotalPasses = m.TotalPasses,
                SuccesfullPasses = m.SuccesfullPasses
            }).ToList();

            _statisticsRepository.InsertRange(matchStatistics);
            return RedirectToAction("AddMatch");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var match = _matchRepository.GetById(id);
            _standingsRepository.EditStandings(match);
            var teams = _repository.Get();           
            var vm = new MatchViewModel();
            vm.Id = id;
            vm.HomeTeamScore = match.HomeTeamScore;
            vm.AwayTeamScore = match.AwayTeamScore;
            vm.MatchDate = match.MatchDate;
            vm.HomeTeamId = match.HomeTeamId;
            vm.AwayTeamId = match.AwayTeamId;
            vm.Teams = teams.Select(item => new SelectListItem { Value = item.Id.ToString(), Text = item.Name }).ToList();

            return View(vm);

        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(MatchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var match = _matchRepository.GetById(vm.Id);
                _matchRepository.Update(match);
                match.LeagueId = vm.LeagueId;
                match.HomeTeamId = vm.HomeTeamId;
                match.AwayTeamId = vm.AwayTeamId;
                match.HomeTeamScore = vm.HomeTeamScore;
                match.AwayTeamScore = vm.AwayTeamScore;
                match.MatchDate = vm.MatchDate;
                _matchRepository.EditStandings(match);
               // _matchRepository.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(vm);

        }

    }
}