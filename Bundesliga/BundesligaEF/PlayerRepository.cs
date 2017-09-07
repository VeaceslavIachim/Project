using System.Collections.Generic;
using BundesligaDomain;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BundesligaEF
{
    public class PlayerRepository :Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(BundesligaContext context) : base(context)
        {
        }

        public Player Player(int id)
        {
            return _dbset.Where(p => p.Id == id)
                .Include(p=>p.Position)
                .Include(p=>p.Country)
                .SingleOrDefault();
        }

        public IEnumerable<Player> TeamPlayers(int id)
        {
            return _dbset.Where(p => p.TeamId == id).ToList();
        }

        
    }
}
