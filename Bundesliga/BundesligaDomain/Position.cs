using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundesligaDomain
{
    public class Position:Entity
    {
        public string Name { get; set; }
        public IList<Player> Players { get; set; }
        public Position()
        {
            Players = new List<Player>();
        }
    }
}
