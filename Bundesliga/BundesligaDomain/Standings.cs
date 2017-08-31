using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundesligaDomain
{
    public class Standings:Entity
    {
        public virtual Team Team { get; set; }
        public virtual League League { get; set; }
        public virtual int Goals { get; set; }
        public virtual int Points { get; set; }
        public virtual int Year { get; set; }
    }
}
