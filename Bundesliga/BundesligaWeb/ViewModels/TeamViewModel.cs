using BundesligaDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BundesligaWeb.ViewModels
{
    public class TeamViewModel
    {
        public string Name { get; set; }
        public string Photo { get; set; }
     
        public IEnumerable<Player> Players { get; set; }
        
    }
}
