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
        public virtual League League { get; set; }

        public int HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; }

        public virtual int HomeTeamScore {get;set;}
        public virtual int AwayTeamScore { get; set; }
        public virtual DateTime MatchDate { get; set; }
        public virtual IList<MatchStatistics> MatchStatistics { get; set; }
    }
}
