using BundesligaServices.DTO;
using System.Collections.Generic;

namespace BundesligaServices.Interfaces
{
    public interface IMatchServices
    {
        List<MatchesViewDTO> GetAllMatches();
        List<MatchesViewDTO> GetMatchesByWeek(int week);
        MatchDTO GetDataForMatch();
        int SaveMatch(MatchDTO match);
        MatchStatisticsDTO GetDataForStatistics(int id);
        void SaveStatistics(IList<MatchStatisticsDTO> matchStatistics);
        MatchDTO GetDataForEdit(int id);
        void EditMatch(MatchDTO matchDTO);
        void DeleteMatch(int id);
    }
}
