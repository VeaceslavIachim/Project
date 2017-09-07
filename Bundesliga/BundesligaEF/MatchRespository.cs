using BundesligaDomain;

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
    }
}
