using BundesligaDomain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace BundesligaEF
{
    public class TeamRepository : Repository<Team>,ITeamRepository
    {
        public TeamRepository(BundesligaContext context):base(context)
        {
            
        }

        public IEnumerable<Team> GetLiguesTeams(int id)
        {
            var teams = _dbset.Where(t => t.LeagueId == id).ToList();
            return teams;
        }

        public Team GetTeamDetailsById(int id)
        {
            var team = _dbset.Include(t => t.Players)
                .Where(t => t.Id == id)
                .Include(t=>t.Players)
                .FirstOrDefault();

            return team;
              
        }
        
    }
}
