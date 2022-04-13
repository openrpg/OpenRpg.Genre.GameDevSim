using OpenRpg.Genres.GameDevSim.Models;

namespace OpenRpg.Genres.GameDevSim.Processors
{
    public interface IGameDevelopmentProcessor
    {
        void UpdateDevelopment(Game game, Company company);
    }
}

