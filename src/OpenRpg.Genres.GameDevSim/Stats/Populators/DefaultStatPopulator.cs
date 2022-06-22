using System.Collections.Generic;
using OpenRpg.Genres.GameDevSim.Extensions;
using OpenRpg.Core.Effects;
using OpenRpg.Core.Extensions;
using OpenRpg.Core.Stats.Variables;
using OpenRpg.Core.Variables;
using OpenRpg.Genres.GameDevSim.Types;

namespace OpenRpg.Genres.GameDevSim.Stats.Populators
{
    public class DefaultStatPopulator : IStatPopulator
    {
        public void Populate(IStatsVariables stats, IReadOnlyCollection<Effect> activeEffects, IReadOnlyCollection<IVariables> relatedVars)
        {
            var allAttributeValue = activeEffects.GetPotencyFor(EffectTypes.AllAttributeBonusAmount);
            var allAttributePercentage = activeEffects.GetPotencyFor(EffectTypes.AllAttributeBonusPercentage);

            var logicValue = (int)activeEffects.CalculateBonusFor(EffectTypes.LogicBonusAmount,
                EffectTypes.LogicBonusPercentage, allAttributeValue, allAttributePercentage);
            
            var creativityValue = (int)activeEffects.CalculateBonusFor(EffectTypes.CreativityBonusAmount,
                EffectTypes.CreativityBonusPercentage, allAttributeValue, allAttributePercentage);
            
            var staminaValue = (int)activeEffects.CalculateBonusFor(EffectTypes.StaminaBonusAmount,
                EffectTypes.StaminaBonusPercentage, allAttributeValue, allAttributePercentage);
            
            var understandingValue = (int)activeEffects.CalculateBonusFor(EffectTypes.UnderstandingBonusAmount,
                EffectTypes.UnderstandingBonusPercentage, allAttributeValue, allAttributePercentage);

            stats.Logic(logicValue);
            stats.Creativity(creativityValue);
            stats.Stamina(staminaValue);
            stats.Understanding(understandingValue);
        }
    }
}
