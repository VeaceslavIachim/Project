using AutoMapper;
using BundesligaEF;
using BundesligaServices.DTO;
using BundesligaServices.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BundesligaServices
{
    public class LeagueServices:ILeagueServices
    {
        private IleagueRepository _leagueRepository;

        public LeagueServices(IleagueRepository leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }

        public IEnumerable<LeagueDTO> GetAllLeagues()
        {
            var leagues = _leagueRepository.GetLeagues();
            var leagueList = Mapper.Map<IEnumerable<LeagueDTO>>(leagues);

            return leagueList;
        }

      
    }
}
