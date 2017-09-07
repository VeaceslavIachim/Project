using BundesligaDomain;

namespace BundesligaEF
{
    public interface IStandingsRepository:IRepository<Standings>
    {
        void UpdateStandings(Match match);
    }
}
