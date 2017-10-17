using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BundesligaWeb.ViewModels
{
    public class StandingDetailsViewModel
    {
        public List<StandingsViewModel> Standings { get; set; }
        public List<MatchesViewViewModel> Matches { get; set; }
        public List<TopScorersViewModel> TopScorers { get; set; }

    }
}
