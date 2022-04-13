using OpenRpg.Genres.GameDevSim.Models;

namespace OpenRpg.Genres.GameDevSim.Processors
{
    public interface IGameReleaseProcessor
    {
        int CalculateCopiesSoldForWeek(Game game, Company company);
        int CalculateGameSalePrice(Game game, Company company);
    }
}