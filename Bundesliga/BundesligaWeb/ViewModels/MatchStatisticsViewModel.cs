using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BundesligaWeb.ViewModels
{
    public class MatchStatisticsViewModel
    {
        public int PlayerId { get; set; }
        
        public int MatchId { get; set; }
       
        public int GoalsScored { get; set; }

        public int MinutesPlayed { get; set; } = 90;
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int TotalPasses { get; set; }
        public int SuccesfullPasses { get; set; }

        public List<SelectListItem> HomePlayers { get; set; }
        public List<SelectListItem> AwayPlayers { get; set; }


    }
}
