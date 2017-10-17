using BundesligaDomain;
using System.Collections.Generic;

namespace BundesligaEF
{
    public interface IPlayerRepository:IRepository<Player>
    {
        IEnumerable<Player> GetTeamPlayers(int id);
        Player GetPlayerDetails(int id);
    }
}
