using BundesligaDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BundesligaEF
{
    public class MatchRespository : Repository<Match>,IMatchRepository
    {
        private readonly IStandingsRepository _standingRepository;

        public MatchRespository(BundesligaContext context,
            IStandingsRepository standingsRepository) : base(context)
        {
            _standingRepository = standingsRepository;
        }

        public override void Insert(Match match)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                _context.Matches.Add(match);
                _standingRepository.UpdateStandings(match);
                _context.SaveChanges();
                transaction.Commit();
            }
        }

        public void EditStandings(Match match)
        {
                      
                _standingRepository.UpdateStandings(match);
                _context.SaveChanges();
               

        }

        public override IEnumerable<Match> Get()
        {
            var matches = _dbset
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .ToList();
            return matches;
        }

        public IEnumerable<Match> GetPartial()
        {
            var matches = _dbset
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .OrderByDescending(m=>m.MatchDate)
                .Take(6)
                .ToList();
            return matches;
        }

        public IEnumerable<Match> GetByWeek(int week)
        {
            DateTime initialDate = new DateTime(2017, 08, 14);
            DateTime lastWeekDay = initialDate + TimeSpan.FromDays(7 * week);
            DateTime firstWeekDay = lastWeekDay - TimeSpan.FromDays(7);
            var matches = _dbset
                .Where(x => (x.MatchDate > firstWeekDay) && (x.MatchDate < lastWeekDay))
               .Include(m => m.HomeTeam)
               .Include(m => m.AwayTeam)
               .ToList();

            return matches;
        }
    }
}
