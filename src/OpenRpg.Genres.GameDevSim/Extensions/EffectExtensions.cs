using System.Collections.Generic;
using OpenRpg.Core.Effects;
using OpenRpg.Core.Extensions;

namespace OpenRpg.Genres.GameDevSim.Extensions
{
    public static class EffectExtensions
    {
        public static float CalculateBonusFor(this IReadOnlyCollection<Effect> activeEffects, int amountBonusType, int percentageBonusType, float genericBonus = 0, float genericPercentage = 0, int miscBonus = 0)
        {
            var totalAmount = genericBonus + miscBonus + activeEffects.GetPotencyFor(amountBonusType);
            var percentageBonus = genericPercentage + activeEffects.GetPotencyFor(percentageBonusType);
            var totalBonus = totalAmount * percentageBonus;
            return totalAmount + totalBonus;
        }
    }
}
