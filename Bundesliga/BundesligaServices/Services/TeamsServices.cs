using BundesligaDomain;
using BundesligaEF;
using BundesligaServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BundesligaServices.DTO;
using System.Linq;
using AutoMapper;

namespace BundesligaServices.Services
{
    public class TeamsServices:ITeamsServices
    {
        private IRepository<Team> _repository;
        private IPlayerRepository _playerRepository;

        public TeamsServices(IRepository<Team> repository, IPlayerRepository playerRepository)
        {
            _repository = repository;
            _playerRepository = playerRepository;
        }

        public TeamDTO GetTeamDetails(int id)
        {
            var team = _repository.GetById(id);
            var players = _playerRepository.GetTeamPlayers(id);
            var teamdto = Mapper.Map<TeamDTO>(team);
            //teamdto.Players = Mapper.Map<IEnumerable<PlayerDTO>>(players);
           

            return teamdto;
        }
    }
}
