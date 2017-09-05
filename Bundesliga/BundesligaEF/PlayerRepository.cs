using System.Collections.Generic;
using BundesligaDomain;
using System.Linq;

namespace BundesligaEF
{
    public class PlayerRepository :Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(BundesligaContext context) : base(context)
        {
        }

        public Player Player(int id)
        {
            return _dbset.Where(p => p.Id == id).SingleOrDefault();
        }

        public IEnumerable<Player> TeamPlayers(int id)
        {
            return _dbset.Where(p => p.TeamId == id).ToList();
        }

        
    }
}
