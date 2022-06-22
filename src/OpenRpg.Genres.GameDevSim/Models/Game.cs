using OpenRpg.Genres.GameDevSim.Variables;

namespace OpenRpg.Genres.GameDevSim.Models
{
    public class Game
    {
        public string Name { get; set; }

        public GameTheme Theme { get; set; } = new GameTheme();
        public GameGenre Genre { get; set; } = new GameGenre();

        public GameReleaseInfo GameReleaseInfo { get; set; } = new GameReleaseInfo();
        public IGameStateVariables State { get; set; } = new DefaultGameStateVariables();
    }
}
