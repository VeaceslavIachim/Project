using BundesligaDomain;
using System.Linq;

namespace BundesligaEF
{
    public interface ITeamRepository:IRepository<Team>
    {
        Team GetTeamDetailsById(int id);
    }
}
