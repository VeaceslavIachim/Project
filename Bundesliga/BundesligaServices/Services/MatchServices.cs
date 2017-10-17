using AutoMapper;
using BundesligaDomain;
using BundesligaEF;
using BundesligaServices.DTO;
using BundesligaServices.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BundesligaServices.Services
{
    public class MatchServices:IMatchServices
    {
        private IMatchRepository _matchRepository;
        private IRepository<Team> _repository;
        private IPlayerRepository _playerRepository;
        private IRepository<MatchStatistics> _statisticsRepository;
        private IStandingsRepository _standingsRepository;

        public MatchServices(IMatchRepository matchRepository,
            IRepository<Team> repository,
            IPlayerRepository playerRepository,
            IRepository<MatchStatistics> statisticsRepository,
            IStandingsRepository standingsRepository)
        {
            _matchRepository = matchRepository;
            _repository = repository;
            _playerRepository = playerRepository;
            _statisticsRepository = statisticsRepository;
            _standingsRepository = standingsRepository;
        }

        public List<MatchesViewDTO> GetAllMatches()
        {
            var matches = _matchRepository.Get();
            var allMatches = Mapper.Map<List<MatchesViewDTO>>(matches);
            return allMatches;
        }

        public List<MatchesViewDTO> GetMatchesByWeek(int week)
        {
            var matches = _matchRepository.GetByWeek(week);
            var weekMatches = Mapper.Map<List<MatchesViewDTO>>(matches);
            return weekMatches;
        }

        public MatchDTO GetDataForMatch()
        {
            var teams = _repository.Get();
            var matchDto = new MatchDTO();
            matchDto.Teams = teams.Select(item => new SelectListItem { Value = item.Id.ToString(), Text = item.Name }).ToList();


            return matchDto;
        }

        public int SaveMatch(MatchDTO match)
        {
            var newMatch = Mapper.Map<Match>(match);
            _matchRepository.Insert(newMatch);

            return newMatch.Id;
        }

        public MatchStatisticsDTO GetDataForStatistics(int id)
        {
            var match = _matchRepository.GetById(id);
            var homeTeamPlayers = _playerRepository.GetTeamPlayers(match.HomeTeamId);
            var awayTeamPlayers = _playerRepository.GetTeamPlayers(match.AwayTeamId);
            var vm = new MatchStatisticsDTO();
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

            return vm;
        }

        public void SaveStatistics(IList<MatchStatisticsDTO> matchStatistics)
        {
            var _matchStatistics = Mapper.Map<IList<MatchStatistics>>(matchStatistics);
            _statisticsRepository.InsertRange(_matchStatistics);

        }

        public MatchDTO GetDataForEdit(int id)
        {
            
            var match = _matchRepository.GetById(id);
           _standingsRepository.EditStandings(match);
            var teams = _repository.Get();

            var matchDTO = Mapper.Map<MatchDTO>(match);    
            matchDTO.Teams = teams.Select(item => new SelectListItem { Value = item.Id.ToString(), Text = item.Name }).ToList();

            return matchDTO;

        }

        public void EditMatch(MatchDTO matchDTO)
        {
            var match = _matchRepository.GetById(matchDTO.Id);
            _matchRepository.Update(match);
            match = Mapper.Map<Match>(matchDTO);
            
            _matchRepository.EditStandings(match);
        }

        public void DeleteMatch(int id)
        {
            var entityToDelete = _matchRepository.GetById(id);
            _standingsRepository.EditStandings(entityToDelete);
            _matchRepository.Delete(entityToDelete);

        }
    }
}
