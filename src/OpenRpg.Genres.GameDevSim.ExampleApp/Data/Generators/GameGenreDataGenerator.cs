using OpenRpg.Core.Effects;
using OpenRpg.Genres.GameDevSim.Models;
using OpenRpg.Genres.GameDevSim.Types;

namespace GameDevStory.ConsoleApp.Data.Generators;

public class GameGenreDataGenerator : IDataGenerator<GameGenre>
{
    public IReadOnlyCollection<GameGenre> Data { get; }

    public GameGenreDataGenerator()
    { Data = GenerateData().ToArray(); }
    
    public IEnumerable<GameGenre> GenerateData()
    {
        yield return new GameGenre
        {
            Id = GameGenreTypes.Action,
            NameLocaleId = "Action",
            Effects = new[]
            {
                new Effect { EffectType = EffectTypes.StaminaBonusPercentage, Potency = 0.05f }
            }
        };
        
        yield return new GameGenre
        {
            Id = GameGenreTypes.Adventure,
            NameLocaleId = "Adventure",
            Effects = new[]
            {
                new Effect { EffectType = EffectTypes.UnderstandingBonusAmount, Potency = 0.05f },
                new Effect { EffectType = EffectTypes.GraphicsBonusAmount, Potency = 0.05f }
            }
        };
        
        yield return new GameGenre
        {
            Id = GameGenreTypes.Racing,
            NameLocaleId = "Racing",
            Effects = new[]
            {
                new Effect { EffectType = EffectTypes.FunBonusPercentage, Potency = 0.05f }
            }
        };
        
                
        yield return new GameGenre
        {
            Id = GameGenreTypes.Shooter,
            NameLocaleId = "Shooter",
            Effects = new[]
            {
                new Effect { EffectType = EffectTypes.GraphicsBonusAmount, Potency = 0.05f }
            }
        };
    }
}