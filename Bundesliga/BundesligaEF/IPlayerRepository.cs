using BundesligaDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BundesligaEF
{
    public interface IPlayerRepository:IRepository<Player>
    {
        IEnumerable<Player> TeamPlayers(int id);
        Player Player(int id);
    }
}
