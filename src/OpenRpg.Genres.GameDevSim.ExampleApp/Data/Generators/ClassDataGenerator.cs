using OpenRpg.Core.Classes;
using OpenRpg.Core.Effects;
using OpenRpg.Genres.GameDevSim.Types;

namespace GameDevStory.ConsoleApp.Data.Generators;

public class ClassDataGenerator : IDataGenerator<IClassTemplate>
{
    public IReadOnlyCollection<IClassTemplate> Data { get; }

    public ClassDataGenerator()
    { Data = GenerateData().ToArray(); }

    public IEnumerable<IClassTemplate> GenerateData()
    {
        yield return new DefaultClassTemplate()
        {
            Id = ClassTypes.DeveloperId,
            NameLocaleId = "Developer",
            Effects = new[]
            {
                new Effect { EffectType = EffectTypes.LogicBonusAmount, Potency = 5 },
                new Effect { EffectType = EffectTypes.LogicBonusPercentage, Potency = 0.1f },
                new Effect { EffectType = EffectTypes.AllAttributeBonusAmount, Potency = 5 }
            }
        };
        
        yield return new DefaultClassTemplate()
        {
            Id = ClassTypes.DesignerId,
            NameLocaleId = "Designer",
            Effects = new[]
            {
                new Effect { EffectType = EffectTypes.CreativityBonusAmount, Potency = 5 },
                new Effect { EffectType = EffectTypes.CreativityBonusPercentage, Potency = 0.1f },
                new Effect { EffectType = EffectTypes.AllAttributeBonusAmount, Potency = 2 }
            }
        };
    }
}