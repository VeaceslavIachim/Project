using BundesligaDomain;
using System.Collections.Generic;

namespace BundesligaEF
{
    public interface IMatchRepository:IRepository<Match>
    {
        void Insert(Match match);
        void EditStandings(Match match);
        IEnumerable<Match> GetPartial();

    }
}