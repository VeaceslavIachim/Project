using BundesligaDomain;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BundesligaEF
{
    public class StandingsRepository : Repository<Standings>, IStandingsRepository
    {
        public StandingsRepository(BundesligaContext context) : base(context)
        {
        }

        public IEnumerable<Standings> GetStandingsDetails(int id)
        {
            var standings = _dbset.Where(s => s.LeagueId == id)
                .Include(s => s.Team)
                .OrderByDescending(s => s.Points)
                .ToList();
            return standings;
        }

        public void UpdateStandings(Match match)
        {
            var standings = _context.Standings.Where(x => 
                x.LeagueId == match.LeagueId && 
                x.Year == match.MatchDate.Year && 
                (x.TeamId == match.HomeTeamId || x.TeamId == match.AwayTeamId))
                .ToArray();
            

            var homeTeam = standings.FirstOrDefault(x => x.TeamId == match.HomeTeamId);
            var awayTeam = standings.FirstOrDefault(x => x.TeamId == match.AwayTeamId);
            

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

            homeTeam.Games++;
            awayTeam.Games++;
        }
        public void EditStandings(Match match)
        {
            var standings = _context.Standings.Where(x =>
                 x.LeagueId == match.LeagueId &&
                 x.Year == match.MatchDate.Year &&
                 (x.TeamId == match.HomeTeamId || x.TeamId == match.AwayTeamId))
                 .ToArray();


            var homeTeam = standings.FirstOrDefault(x => x.TeamId == match.HomeTeamId);
            var awayTeam = standings.FirstOrDefault(x => x.TeamId == match.AwayTeamId);

            if (match.HomeTeamScore > match.AwayTeamScore)
            {
                homeTeam.Points -= 3;
            }
            else if (match.HomeTeamScore < match.AwayTeamScore)
            {
                awayTeam.Points -= 3;
            }
            else
            {
                homeTeam.Points--;
                awayTeam.Points--;
            }

            homeTeam.Goals -= match.HomeTeamScore;
            awayTeam.Goals -= match.AwayTeamScore;

            homeTeam.Games--;
            awayTeam.Games--;
            _context.SaveChanges();

        }
    }
}
