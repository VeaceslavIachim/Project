using BundesligaDomain;
using System.Linq;

namespace BundesligaEF
{
    public class StandingsRepository : Repository<Standings>, IStandingsRepository
    {
        public StandingsRepository(BundesligaContext context) : base(context)
        {
        }

        public void UpdateStandings(Match match)
        {
            var standings = _context.Standings.Where(x => 
                x.LeagueId == match.LeagueId && 
                x.Year == match.MatchDate.Year && 
                (x.TeamId == match.HomeTeamId || x.TeamId == match.AwayTeamId))
                .ToArray();

            var homeTeam = standings.First(x => x.TeamId == match.HomeTeamId);
            var awayTeam = standings.First(x => x.TeamId == match.AwayTeamId);
            
            if (match.HomeTeamScore > match.AwayTeamScore)
            {
                homeTeam.Points += 3;
            }
            else if (match.HomeTeamScore < match.AwayTeamScore)
            {
                awayTeam.Points += 3;
            }
            else
            {
                homeTeam.Points++;
                awayTeam.Points++;
            }

            homeTeam.Goals += match.HomeTeamScore;
            awayTeam.Goals += match.AwayTeamScore;
        }
    }
}
