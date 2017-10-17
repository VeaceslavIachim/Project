using BundesligaDomain;
using System.Collections.Generic;
using System.Linq;

namespace BundesligaEF
{
    public interface ITeamRepository:IRepository<Team>
    {
        Team GetTeamDetailsById(int id);
        IEnumerable<Team> GetLiguesTeams(int id);
    }
}
