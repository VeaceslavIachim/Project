using System;
using System.Collections.Generic;
using System.Text;

namespace BundesligaServices.DTO
{
    public class PlayerDetailsDTO
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public string Position { get; set; }

        public string Country { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
    }
}
