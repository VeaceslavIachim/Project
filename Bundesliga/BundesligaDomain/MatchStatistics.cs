using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundesligaDomain
{
    public class MatchStatistics:Entity
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int GoalsScored { get; set; }
        public int MinutesPlayed { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int TotalPasses { get; set; }
        public int SuccesfullPasses { get; set; }
    }
}
