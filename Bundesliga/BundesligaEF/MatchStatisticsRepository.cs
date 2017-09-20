using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BundesligaEF.DTO;

namespace BundesligaEF
{
    public class MatchStatisticsRepository : Repository<MatchStatisticsRepository>, IMatchStatisticsRepository
    {
        public MatchStatisticsRepository(BundesligaContext context) : base(context)
        {
        }

        public IEnumerable<TopScorersDTO> GetTopScorers()
        {
            var topScorers = _context.MatchStatistics
                .Include(p => p.Player)
                .Select(p => new TopScorersDTO {
                    Player = p.Player.FirstName,
                    Goals = p.GoalsScored
                })
                .OrderByDescending(p => p.Goals)
                .Take(5)
                .ToList();

            return topScorers;
        }
    }
}
