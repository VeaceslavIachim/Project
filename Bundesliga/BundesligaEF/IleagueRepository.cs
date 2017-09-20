using BundesligaDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BundesligaEF
{
    public interface IleagueRepository
    {
        IEnumerable<League> GetLeagues();
    }
}
