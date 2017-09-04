using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundesligaDomain
{
    public class Standings:Entity
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int LeagueId { get; set; }
        public League League { get; set; }

        public int Goals { get; set; }
        public int Points { get; set; }
        public int Year { get; set; }
    }
}
