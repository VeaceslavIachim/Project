using BundesligaServices.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BundesligaServices.Interfaces
{
    public interface ITeamsServices
    {
        TeamDTO GetTeamDetails(int id);
    }
}
