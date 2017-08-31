using System.Collections.Generic;

namespace BundesligaDomain
{
    public class Country:Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<Player> Players { get;  set; }
        public virtual IList<League> Leagues { get;  set; }
        public virtual IList<Coach> Coaches { get;  set; }

       public  Country()
        {
            Players = new List<Player>();
            Leagues = new List<League>();
            Coaches = new List<Coach>();
        }

        public virtual void Add(League league)
        {
            Leagues.Add(league);
            league.Country = this;
        }
        
    }
}
