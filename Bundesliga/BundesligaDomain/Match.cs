using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundesligaDomain
{
    public class Match : Entity
    {
        public int LeagueId { get; set; }
        public League League { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public int HomeTeamScore {get;set;}
        public int AwayTeamScore { get; set; }
        public DateTime MatchDate { get; set; }
        public IList<MatchStatistics> MatchStatistics { get; set; }
    }
}
