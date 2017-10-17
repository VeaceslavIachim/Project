using BundesligaServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BundesligaServices.DTO;
using BundesligaEF;
using AutoMapper;

namespace BundesligaServices.Services
{
    public class PlayerServices : IPlayerServices
    {
        private IPlayerRepository _playerRepository;


        public PlayerServices(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }


        public PlayerDetailsDTO GetPlayerDetails(int id)
        {
            var player = _playerRepository.GetPlayerDetails(id);
            var playerdetails = Mapper.Map<PlayerDetailsDTO>(player);

            return playerdetails;
        }
    }
}
