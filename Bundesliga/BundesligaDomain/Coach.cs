using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundesligaDomain
{
    public class Coach:Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
