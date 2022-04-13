using OpenRpg.Genres.GameDevSim.Types;
using OpenRpg.Genres.GameDevSim.Variables;

namespace OpenRpg.Genres.GameDevSim.Extensions
{
    public static class GameVariableExtensions
    {
        public static float Fun(this IGameVariables stats) => stats.Get(GameVariableTypes.Fun);
        public static void Fun(this IGameVariables stats, float value) => stats[GameVariableTypes.Fun] = value;
        public static void AddFun(this IGameVariables stats, float value)
        {
            if (!stats.ContainsKey(GameVariableTypes.Fun))
            { stats[GameVariableTypes.Fun] = 0;}
            stats[GameVariableTypes.Fun] += value;
        }

        public static float Graphics(this IGameVariables stats) => stats.Get(GameVariableTypes.Graphics);
        public static void Graphics(this IGameVariables stats, float value) => stats[GameVariableTypes.Graphics] = value;
        public static void AddGraphics(this IGameVariables stats, float value)
        {
            if (!stats.ContainsKey(GameVariableTypes.Graphics))
            { stats[GameVariableTypes.Graphics] = 0;}
            stats[GameVariableTypes.Graphics] += value;
        }

        public static float Quality(this IGameVariables stats) => stats.Get(GameVariableTypes.Quality);
        public static void Quality(this IGameVariables stats, float value) => stats[GameVariableTypes.Quality] = value;
        public static void AddQuality(this IGameVariables stats, float value)
        {
            if (!stats.ContainsKey(GameVariableTypes.Quality))
            { stats[GameVariableTypes.Quality] = 0;}
            stats[GameVariableTypes.Quality] += value;
        }

        public static float Sound(this IGameVariables stats) => stats.Get(GameVariableTypes.Sound);
        public static void Sound(this IGameVariables stats, float value) => stats[GameVariableTypes.Sound] = value;
        public static void AddSound(this IGameVariables stats, float value)
        {
            if (!stats.ContainsKey(GameVariableTypes.Sound))
            { stats[GameVariableTypes.Sound] = 0;}
            stats[GameVariableTypes.Sound] += value;
        }

        public static float Stability(this IGameVariables stats) => stats.Get(GameVariableTypes.Stability);
        public static void Stability(this IGameVariables stats, float value) => stats[GameVariableTypes.Stability] = value;
        public static void AddStability(this IGameVariables stats, float value)
        {
            if (!stats.ContainsKey(GameVariableTypes.Stability))
            { stats[GameVariableTypes.Stability] = 0;}
            stats[GameVariableTypes.Stability] += value;
        }

        public static float Progress(this IGameVariables stats) => stats.Get(GameVariableTypes.Progress);
        public static void Progress(this IGameVariables stats, float value) => stats[GameVariableTypes.Progress] = value;
        public static void AddProgress(this IGameVariables stats, float value)
        {
            if (!stats.ContainsKey(GameVariableTypes.Progress))
            { stats[GameVariableTypes.Progress] = 0;}
            stats[GameVariableTypes.Progress] += value;
        }
    }
}
