using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BundesligaEF;
using BundesligaWeb.ViewModels;
using BundesligaDomain;

namespace BundesligaWeb.Controllers
{
    [Route("[controller]")]
    public class StandingsController : Controller
    {
        private IStandingsRepository _standingsRepository;
        private IRepository<Team> _repository;
        private IMatchRepository _matchRepository;
        private IMatchStatisticsRepository _matchStatisticsRepository;

        public StandingsController(IStandingsRepository standingsRepository,
            IRepository<Team> repository,
            IMatchRepository matchRepository,
            IMatchStatisticsRepository matchStatisticsRepository)
        {
            _standingsRepository = standingsRepository;
            _repository = repository;
            _matchRepository = matchRepository;
            _matchStatisticsRepository = matchStatisticsRepository;
        }
        public IActionResult Index(int id)
        {
            var standings = _standingsRepository.GetStandingsDetails(id);
            var matches = _matchRepository.GetPartial();
            var topscorers = _matchStatisticsRepository.GetTopScorers();
            var vms = new StandingViewModel {
                Standings = standings.Select(x => new StandingsViewModel
                {
                    Id = x.TeamId,
                    Team = x.Team.Name,
                    Goals = x.Goals,
                    Points = x.Points,
                    Games = x.Games,
                    Photo = _repository.GetById(x.TeamId).Photo,

                })
            .ToList(),
            Matches = matches.Select(m => new MatchesViewViewModel
            {
                HomeTeamPhoto = m.HomeTeam.Photo,
                AwayTeamPhoto = m.AwayTeam.Photo,
                HomeTeamScore = m.HomeTeamScore,
                AwayTeamScore = m.AwayTeamScore
            }).ToList(),
            TopScorers=topscorers.Select(t=>new TopScorersViewModel
            {
                Player=t.Player,
                Goals=t.Goals
            }).ToList()          
            
            };
            return View(vms);
        }
    }
}