using BundesligaDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BundesligaWeb.ViewModels
{
    public class PlayerDetailsViewModel
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public string Position { get; set; }
        
        public string Country { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
    }
}
