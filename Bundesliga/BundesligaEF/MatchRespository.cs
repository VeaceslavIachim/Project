using BundesligaDomain;
using Microsoft.EntityFrameworkCore;
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
            using (var transaction = _context.Database.BeginTransaction())
            {               
                _standingRepository.UpdateStandings(match);
                _context.SaveChanges();
                transaction.Commit();
            }

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

    }
}
