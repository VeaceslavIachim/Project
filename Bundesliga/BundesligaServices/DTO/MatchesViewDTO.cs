using System;
using System.Collections.Generic;
using System.Text;

namespace BundesligaServices.DTO
{
    public class MatchesViewDTO
    {
        public int Id { get; set; }
        
        public string HomeTeam { get; set; }
       
        public string HomeTeamPhoto { get; set; }
        
        public string AwayTeam { get; set; }
      
        public string AwayTeamPhoto { get; set; }
       
        public int HomeTeamScore { get; set; }
       
        public int AwayTeamScore { get; set; }
        
        public DateTime Date { get; set; }
    }
}
