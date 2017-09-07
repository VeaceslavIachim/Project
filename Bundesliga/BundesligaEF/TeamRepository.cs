using BundesligaDomain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BundesligaEF
{
    public class TeamRepository : Repository<Team>,ITeamRepository
    {
        public TeamRepository(BundesligaContext context):base(context)
        {
            
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
