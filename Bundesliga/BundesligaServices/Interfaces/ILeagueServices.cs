using BundesligaServices.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BundesligaServices.Interfaces
{
    public interface ILeagueServices
    {
        IEnumerable<LeagueDTO> GetAllLeagues();
    }
}
