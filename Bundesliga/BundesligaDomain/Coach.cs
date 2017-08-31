using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundesligaDomain
{
    public class Coach:Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
