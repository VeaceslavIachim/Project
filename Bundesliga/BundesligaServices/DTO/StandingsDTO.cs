using System;
using System.Collections.Generic;
using System.Text;

namespace BundesligaServices.DTO
{
    public class StandingsDTO
    {
        public int Id { get; set; }
        public string Team { get; set; }
        public int LeagueId { get; set; }
        public int Games { get; set; }
        public int Goals { get; set; }
        public int Points { get; set; }
        public string Photo { get; set; }
    }
}
