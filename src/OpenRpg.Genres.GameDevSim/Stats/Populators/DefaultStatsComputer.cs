using System.Collections.Generic;
using OpenRpg.Core.Effects;
using OpenRpg.Core.Stats;

namespace OpenRpg.Genres.GameDevSim.Stats.Populators
{
    public class DefaultStatsComputer : IStatsComputer
    {
        public IAttributeStatPopulator AttributeStatPopulator { get; }

        public DefaultStatsComputer(IAttributeStatPopulator attributeStatPopulator)
        {
            AttributeStatPopulator = attributeStatPopulator;
        }

        public IStatsVariables ComputeStats(IReadOnlyCollection<Effect> effects)
        {
            var stats = new DefaultStatsVariables();
            RecomputeStats(stats, effects);
            return stats;
        }

        public void RecomputeStats(IStatsVariables stats, IReadOnlyCollection<Effect> effects)
        {
            AttributeStatPopulator.PopulateStats(stats, effects);
        }
    }
}
