using BundesligaEF.DTO;
using System.Collections.Generic;

namespace BundesligaEF
{
    public interface IMatchStatisticsRepository
    {
        IEnumerable<TopScorersDTOEF> GetTopScorers();
    }
}
