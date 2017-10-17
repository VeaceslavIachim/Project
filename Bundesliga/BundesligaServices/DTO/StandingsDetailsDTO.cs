using System;
using System.Collections.Generic;
using System.Text;

namespace BundesligaServices.DTO
{
    public class StandingsDetailsDTO
    {
        public List<StandingsDTO> Standings { get; set; }
        public List<MatchesViewDTO> Matches { get; set; }
        public List<TopScorersDTO> TopScorers { get; set; }
    }
}
