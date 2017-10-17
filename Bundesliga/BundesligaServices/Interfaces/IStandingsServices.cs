using BundesligaServices.DTO;

namespace BundesligaServices.Interfaces
{
    public interface IStandingsServices
    {
        StandingsDetailsDTO GetStandingsDetails(int id);
    }
}
