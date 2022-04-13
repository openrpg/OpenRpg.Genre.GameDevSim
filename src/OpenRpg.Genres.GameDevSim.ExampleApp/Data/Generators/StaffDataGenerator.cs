using GameDevStory.ConsoleApp.Lookups;
using OpenRpg.Core.Classes;
using OpenRpg.Core.Effects;
using OpenRpg.Core.Stats;
using OpenRpg.Genres.GameDevSim.Models;
using OpenRpg.Genres.GameDevSim.Types;
using OpenRpg.Genres.Types;
using OpenRpg.Genres.Variables;
using OpenRpg.Items.Equipment;
using EffectTypes = OpenRpg.Genres.GameDevSim.Types.EffectTypes;

namespace GameDevStory.ConsoleApp.Data.Generators;

public class StaffDataGenerator : IDataGenerator<Staff>
{
    public IDataGenerator<IClassTemplate> ClassDataGenerator { get; }
    public IReadOnlyCollection<Staff> Data { get; }

    public StaffDataGenerator(IDataGenerator<IClassTemplate> classDataGenerator)
    {
        ClassDataGenerator = classDataGenerator;
        Data = GenerateData().ToArray();
    }

    public IEnumerable<Staff> GenerateData()
    {
        var developerClassTemplate = ClassDataGenerator.Data.Single(x => x.Id == ClassTypes.DeveloperId);
        var designerClassTemplate = ClassDataGenerator.Data.Single(x => x.Id == ClassTypes.DesignerId);
        
        yield return new Staff
        {
            Id = StaffLookups.TheGoose,
            GenderType = (byte)GenderTypes.Male,
            NameLocaleId = "The Goose",
            Class = new DefaultClass(1, developerClassTemplate),
            Equipment = new DefaultEquipment(),
            Stats = new DefaultStatsVariables(),
            Variables = new DefaultCharacterVariables(),
            UniqueEffects = new List<Effect> {
                new() { EffectType = EffectTypes.AllAttributeBonusAmount, Potency = 1 },
                new() { EffectType = EffectTypes.StabilityBonusPercentage, Potency = -0.1f }
            }
        };
        
        yield return new Staff
        {
            Id = StaffLookups.Tudge,
            GenderType = (byte)GenderTypes.Male,
            NameLocaleId = "Tudge",
            Class = new DefaultClass(1, designerClassTemplate),
            Equipment = new DefaultEquipment(),
            Stats = new DefaultStatsVariables(),
            Variables = new DefaultCharacterVariables(),
            UniqueEffects = new List<Effect> {
                new() { EffectType = EffectTypes.AllAttributeBonusAmount, Potency = 1 },
                new() { EffectType = EffectTypes.CreativityBonusAmount, Potency = 10 },
                new() { EffectType = EffectTypes.StaminaBonusAmount, Potency = 100 },
                new() { EffectType = EffectTypes.GraphicsBonusPercentage, Potency = 0.1f },
            }
        };
        
        yield return new Staff
        {
            Id = StaffLookups.HeroKojima,
            GenderType = (byte)GenderTypes.Male,
            NameLocaleId = "Hero Kojima",
            Class = new DefaultClass(1, designerClassTemplate),
            Equipment = new DefaultEquipment(),
            Stats = new DefaultStatsVariables(),
            Variables = new DefaultCharacterVariables(),
            UniqueEffects = new List<Effect> {
                new() { EffectType = EffectTypes.AllAttributeBonusAmount, Potency = 20 },
                new() { EffectType = EffectTypes.QualityBonusPercentage, Potency = 0.25f },
                new() { EffectType = EffectTypes.CopiesSoldBonusPercentage, Potency = 0.25f }
            }
        };
    }
}