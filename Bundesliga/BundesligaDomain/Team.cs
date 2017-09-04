using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundesligaDomain
{
    public class Team:Entity
    {
        public  string Name { get; set; }

        public int LeagueId { get; set; }
        public  League League { get; set; }


        public virtual IList<Player> Players { get; set; }
        public virtual IList<Coach> Coaches { get; set; }


        public virtual IList<Match> AwayMatches { get; set; }
        public virtual IList<Match> HomeMatches { get; set; }


        public virtual IList<Standings> Standings { get; set; }
        public Team()
        {
            Players = new List<Player>();
            Coaches = new List<Coach>();
            //Matches = new List<Match>();
            Standings = new List<Standings>();
        }
    }
}
