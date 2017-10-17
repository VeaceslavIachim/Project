using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BundesligaServices.DTO
{
    public class MatchDTO
    {
        public int Id { get; set; }
        public int LeagueId { get; set; } = 1;       
        public int HomeTeamId { get; set; }

        public List<SelectListItem> Teams { get; set; }
        
        public int AwayTeamId { get; set; }

        public int HomeTeamScore { get; set; }
               
        public int AwayTeamScore { get; set; }
        public DateTime MatchDate { get; set; }
    }
}
