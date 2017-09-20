using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BundesligaWeb.ViewModels
{
    public class LeagueViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }               
        public string Country { get; set; }
        public string Photo { get; set; }
    }
}
