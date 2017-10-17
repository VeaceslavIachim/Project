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
        [Range(0,int.MaxValue,ErrorMessage ="Score can't be negative")]
        public int GoalsScored { get; set; }
        [Range(0, 120, ErrorMessage = "Minutes Played can't be negative")]
        public int MinutesPlayed { get; set; } = 90;
        [Range(0, 2, ErrorMessage = "Yellow cards can't be negative or more than two")]
        public int YellowCards { get; set; }
        [Range(0,1, ErrorMessage = "RedCards can't be negative or more than one")]
        public int RedCards { get; set; }
        [Range(0,int.MaxValue)]
        public int TotalPasses { get; set; }
        [Range(0,int.MaxValue)]
        public int SuccesfullPasses { get; set; }

        public List<SelectListItem> HomePlayers { get; set; }
        public List<SelectListItem> AwayPlayers { get; set; }


    }
}
