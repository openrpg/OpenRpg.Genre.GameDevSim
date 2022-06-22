using GameDevStory.ConsoleApp.Data;
using OpenRpg.Core.Utils;
using OpenRpg.Genres.GameDevSim.Processors;
using OpenRpg.Genres.GameDevSim.Stats.Populators;
using OpenRpg.Data;

namespace GameDevStory.ConsoleApp;

// To keep things simpler wont bother with DI will just statically make everything here
public class Services
{
    public static readonly IRandomizer Randomizer = new DefaultRandomizer(new Random());
    public static readonly IGameDevelopmentProcessor GameDevelopmentProcessor = new GameDevelopmentProcessor(Randomizer);
    public static readonly IGameReleaseProcessor GameReleaseProcessor = new GameReleaseProcessor(Randomizer);
    
    public static readonly IRepository Repository = new DefaultRepository(new InMemoryGameDataSource());
    
    public static readonly DefaultStatPopulator StatsPopulator = new();
}