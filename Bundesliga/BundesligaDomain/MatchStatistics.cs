using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundesligaDomain
{
    public class MatchStatistics:Entity
    {
        public virtual Player Player { get; set; }
        public virtual Match Match { get; set; }
        public virtual int GoalsScored { get; set; }
        public virtual int MinutesPlayed { get; set; }
        public virtual int YellowCards { get; set; }
        public virtual int RedCards { get; set; }
        public virtual int TotalPasses { get; set; }
        public virtual int SuccesfullPasses { get; set; }
    }
}
