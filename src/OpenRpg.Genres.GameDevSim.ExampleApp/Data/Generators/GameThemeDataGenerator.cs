using OpenRpg.Core.Effects;
using OpenRpg.Genres.GameDevSim.Models;
using OpenRpg.Genres.GameDevSim.Types;

namespace GameDevStory.ConsoleApp.Data.Generators;

public class GameThemeDataGenerator : IDataGenerator<GameTheme>
{
    public IReadOnlyCollection<GameTheme> Data { get; }

    public GameThemeDataGenerator()
    { Data = GenerateData().ToArray(); }
    
    public IEnumerable<GameTheme> GenerateData()
    {
        yield return new GameTheme
        {
            Id = GameThemeTypes.Fantasy,
            NameLocaleId = "Fantasy",
            Effects = new[]
            {
                new Effect { EffectType = EffectTypes.UnderstandingBonusPercentage, Potency = 0.05f }
            }
        };
        
        yield return new GameTheme
        {
            Id = GameThemeTypes.Football,
            NameLocaleId = "Football",
            Effects = new[]
            {
                new Effect { EffectType = EffectTypes.CopiesSoldBonusPercentage, Potency = 0.05f }
            }
        };
        
        yield return new GameTheme
        {
            Id = GameThemeTypes.Driving,
            NameLocaleId = "Driving",
            Effects = new[]
            {
                new Effect { EffectType = EffectTypes.FunBonusPercentage, Potency = 0.05f }
            }
        };
    }
}