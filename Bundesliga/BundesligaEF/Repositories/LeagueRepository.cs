using BundesligaDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BundesligaEF
{
    public class LeagueRepository : Repository<League>, IleagueRepository
    {
        public LeagueRepository(BundesligaContext context) : base(context)
        {
        }

        public IEnumerable<League> GetLeagues()
        {
            return _dbset.Include(l => l.Country).ToList();
        }
    }
}
