using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundesligaDomain
{
    public class League : Entity
    {
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string Photo { get; set; }

        public IList<Team> Teams { get; set; }
        public IList<Match> Matches { get; set; }
        public IList<Standings> Standings { get; set; }
        public League()
        {
            Teams = new List<Team>();
            Matches = new List<Match>();
            Standings = new List<Standings>();
        }
    }
}
