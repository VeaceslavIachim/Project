using BundesligaDomain;
using System.Collections.Generic;

namespace BundesligaEF
{
    public interface IPlayerRepository:IRepository<Player>
    {
        IEnumerable<Player> TeamPlayers(int id);
        Player Player(int id);
    }
}
