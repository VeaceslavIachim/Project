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
        public string Photo { get; set; }

        public int LeagueId { get; set; }
        public  League League { get; set; }


        public IList<Player> Players { get; set; }
        public IList<Coach> Coaches { get; set; }


        public IList<Match> AwayMatches { get; set; }
        public IList<Match> HomeMatches { get; set; }


        public IList<Standings> Standings { get; set; }
        public Team()
        {
            Players = new List<Player>();
            Coaches = new List<Coach>();
            //Matches = new List<Match>();
            Standings = new List<Standings>();
        }
    }
}
