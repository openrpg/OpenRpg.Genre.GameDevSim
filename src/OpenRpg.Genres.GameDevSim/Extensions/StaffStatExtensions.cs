using OpenRpg.Core.Stats;
using OpenRpg.Core.Stats.Variables;
using OpenRpg.Genres.GameDevSim.Types;
using OpenRpg.Genres.GameDevSim.Variables;

namespace OpenRpg.Genres.GameDevSim.Extensions
{
    public static class StaffStatExtensions
    {
        public static int Creativity(this IStatsVariables stats) => (int)stats.Get(StatsVariableTypes.Creativity);
        public static void Creativity(this IStatsVariables stats, int value) => stats[StatsVariableTypes.Creativity] = value;
        public static int Logic(this IStatsVariables stats) => (int)stats.Get(StatsVariableTypes.Logic);
        public static void Logic(this IStatsVariables stats, int value) => stats[StatsVariableTypes.Logic] = value;
        public static int Understanding(this IStatsVariables stats) => (int)stats.Get(StatsVariableTypes.Understanding);
        public static void Understanding(this IStatsVariables stats, int value) => stats[StatsVariableTypes.Understanding] = value;
        public static int Stamina(this IStatsVariables stats) => (int)stats.Get(StatsVariableTypes.Stamina);
        public static void Stamina(this IStatsVariables stats, int value) => stats[StatsVariableTypes.Stamina] = value;
    }
}

