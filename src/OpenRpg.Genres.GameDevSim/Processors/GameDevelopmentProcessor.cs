using System.Linq;
using OpenRpg.Genres.GameDevSim.Extensions;
using OpenRpg.Core.Effects;
using OpenRpg.Core.Extensions;
using OpenRpg.Core.Stats.Variables;
using OpenRpg.Core.Utils;
using OpenRpg.Genres.GameDevSim.Models;
using OpenRpg.Genres.GameDevSim.Types;

namespace OpenRpg.Genres.GameDevSim.Processors
{
    public class GameDevelopmentProcessor : IGameDevelopmentProcessor
    {
        public IRandomizer Randomizer { get; }

        public GameDevelopmentProcessor(IRandomizer randomizer)
        {
            Randomizer = randomizer;
        }

        public void UpdateDevelopment(Game game, Company company)
        {
            var randomProgress = Randomizer.Random(1, 6);
            game.State.AddProgress(randomProgress);

            var effectsToUse = company.Effects
                .Union(game.Genre.Effects)
                .Union(game.Theme.Effects)
                .ToArray();

            var funAdded = CalculateFun(company.Stats, effectsToUse);
            var graphicsAdded = CalculateGraphics(company.Stats, effectsToUse);
            var qualityAdded = CalculateQuality(company.Stats, effectsToUse);
            var soundAdded = CalculateSound(company.Stats, effectsToUse);
            var stabilityAdded = CalculateStability(company.Stats, effectsToUse);
            
            game.State.AddFun(funAdded);
            game.State.AddGraphics(graphicsAdded);
            game.State.AddQuality(qualityAdded);
            game.State.AddSound(soundAdded);
            game.State.AddStability(stabilityAdded);

            if (game.State.Progress() > 100)
            { game.State.Progress(100); }
        }

        public int CalculateFun(IStatsVariables stats, Effect[] effects)
        {
            var baseAmount = stats.Creativity() * Randomizer.Random(0.9f, 0.99f);
            var bonusAmount = effects.GetPotencyFor(EffectTypes.FunBonusAmount, EffectTypes.AllDevelopmentBonusAmount);
            var bonusPercentage = effects.GetPotencyFor(EffectTypes.FunBonusPercentage, EffectTypes.AllDevelopmentBonusPercentage);
            var fun = baseAmount + bonusAmount;
            var funBonus = fun * bonusPercentage;
            return (int)(fun + funBonus);
        }
        
        public int CalculateGraphics(IStatsVariables stats, Effect[] effects)
        {
            var baseAmount = (stats.Creativity() + stats.Logic()) * Randomizer.Random(0.4f, 0.5f);
            var bonusAmount = effects.GetPotencyFor(EffectTypes.GraphicsBonusAmount, EffectTypes.AllDevelopmentBonusAmount);
            var bonusPercentage = effects.GetPotencyFor(EffectTypes.GraphicsBonusAmount, EffectTypes.AllDevelopmentBonusPercentage);
            var graphics = baseAmount + bonusAmount;
            var graphicsBonus = graphics * bonusPercentage;
            return (int)(graphics + graphicsBonus);
        }
        
        public int CalculateQuality(IStatsVariables stats, Effect[] effects)
        {
            var baseAmount = stats.Understanding() * Randomizer.Random(0.9f, 0.99f);
            var bonusAmount = effects.GetPotencyFor(EffectTypes.QualityBonusAmount, EffectTypes.AllDevelopmentBonusAmount);
            var bonusPercentage = effects.GetPotencyFor(EffectTypes.QualityBonusPercentage, EffectTypes.AllDevelopmentBonusPercentage);
            var quality = baseAmount + bonusAmount;
            var qualityBonus = quality * bonusPercentage;
            return (int)(quality + qualityBonus);
        }
        
        public int CalculateSound(IStatsVariables stats, Effect[] effects)
        {
            var baseAmount = (stats.Creativity() + stats.Understanding()) * Randomizer.Random(0.4f, 0.5f);
            var bonusAmount = effects.GetPotencyFor(EffectTypes.SoundBonusAmount, EffectTypes.AllDevelopmentBonusAmount);
            var bonusPercentage = effects.GetPotencyFor(EffectTypes.SoundBonusAmount, EffectTypes.AllDevelopmentBonusPercentage);
            var sound = baseAmount + bonusAmount;
            var soundBonus = sound * bonusPercentage;
            return (int)(sound + soundBonus);
        }
        
        public int CalculateStability(IStatsVariables stats, Effect[] effects)
        {
            var baseAmount = (stats.Logic() + stats.Understanding()) * Randomizer.Random(0.4f, 0.5f);
            var bonusAmount = effects.GetPotencyFor(EffectTypes.StabilityBonusAmount, EffectTypes.AllDevelopmentBonusAmount);
            var bonusPercentage = effects.GetPotencyFor(EffectTypes.StabilityBonusAmount, EffectTypes.AllDevelopmentBonusPercentage);
            var stability = baseAmount + bonusAmount;
            var stabilityBonus = stability * bonusPercentage;
            return (int)(stability + stabilityBonus);
        }
    }
}