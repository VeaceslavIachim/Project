using AutoMapper;
using BundesligaEF;
using BundesligaServices.DTO;
using BundesligaServices.Interfaces;
using System.Collections.Generic;

namespace BundesligaServices.Services
{
    public class StandingsServices : IStandingsServices
    {
        private IStandingsRepository _standingsRepository;
        private IMatchRepository _matchRepository;
        private IMatchStatisticsRepository _matchStatisticsRepository;

        public StandingsServices(IStandingsRepository standingsRepository,
            IMatchRepository matchRepository,
            IMatchStatisticsRepository matchStatisticsRepository)
        {
            _standingsRepository = standingsRepository;
            _matchRepository = matchRepository;
            _matchStatisticsRepository = matchStatisticsRepository;
        }
        public StandingsDetailsDTO GetStandingsDetails(int id)
        {
            var standings = _standingsRepository.GetStandingsDetails(id);
            var matches = _matchRepository.GetPartial();
            var topscorers = _matchStatisticsRepository.GetTopScorers();

            var standingsDetails = new StandingsDetailsDTO();
            standingsDetails.TopScorers = Mapper.Map<List<TopScorersDTO>>(topscorers);
            standingsDetails.Matches = Mapper.Map<List<MatchesViewDTO>>(matches);
            standingsDetails.Standings = Mapper.Map<List<StandingsDTO>>(standings);

            return standingsDetails;
        }
    }
}
