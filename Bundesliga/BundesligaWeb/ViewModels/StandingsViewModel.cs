using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BundesligaWeb.ViewModels
{
    public class StandingsViewModel
    {
        public string Team { get; set; }
        public int Games { get; set; }
        public int Goals { get; set; }
        public int Points { get; set; }
    }
}
