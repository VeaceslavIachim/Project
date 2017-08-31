using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundesligaDomain
{
    public class Player:Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Number { get; set; }

        //public int PositionId { get; set; }
        public Position Position { get; set; }

        public Team Team { get; set; }
        public Country Country { get; set; }
        public DateTime Age { get; set; }
        public int Height { get; set; }
        public IList<MatchStatistics> MatchStatistics { get; set;}
        public Player()
        {
            MatchStatistics = new List<MatchStatistics>();
        }
       

    }
}
