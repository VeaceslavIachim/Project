using BundesligaDomain;
using System.Collections.Generic;

namespace BundesligaEF
{
    public interface IStandingsRepository:IRepository<Standings>
    {
        void UpdateStandings(Match match);
        IEnumerable<Standings> GetStandingsDetails(int id);
        void EditStandings(Match match);
    }
}
