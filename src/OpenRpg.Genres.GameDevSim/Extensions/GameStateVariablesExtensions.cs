using OpenRpg.Genres.GameDevSim.Types;
using OpenRpg.Genres.GameDevSim.Variables;

namespace OpenRpg.Genres.GameDevSim.Extensions
{
    public static class GameStateVariablesExtensions
    {
        public static float Fun(this IGameStateVariables state) => state.Get(GameVariableTypes.Fun);
        public static void Fun(this IGameStateVariables state, float value) => state[GameVariableTypes.Fun] = value;
        public static void AddFun(this IGameStateVariables state, float value)
        {
            if (!state.ContainsKey(GameVariableTypes.Fun))
            { state[GameVariableTypes.Fun] = 0;}
            state[GameVariableTypes.Fun] += value;
        }

        public static float Graphics(this IGameStateVariables state) => state.Get(GameVariableTypes.Graphics);
        public static void Graphics(this IGameStateVariables state, float value) => state[GameVariableTypes.Graphics] = value;
        public static void AddGraphics(this IGameStateVariables state, float value)
        {
            if (!state.ContainsKey(GameVariableTypes.Graphics))
            { state[GameVariableTypes.Graphics] = 0;}
            state[GameVariableTypes.Graphics] += value;
        }

        public static float Quality(this IGameStateVariables state) => state.Get(GameVariableTypes.Quality);
        public static void Quality(this IGameStateVariables state, float value) => state[GameVariableTypes.Quality] = value;
        public static void AddQuality(this IGameStateVariables state, float value)
        {
            if (!state.ContainsKey(GameVariableTypes.Quality))
            { state[GameVariableTypes.Quality] = 0;}
            state[GameVariableTypes.Quality] += value;
        }

        public static float Sound(this IGameStateVariables state) => state.Get(GameVariableTypes.Sound);
        public static void Sound(this IGameStateVariables state, float value) => state[GameVariableTypes.Sound] = value;
        public static void AddSound(this IGameStateVariables state, float value)
        {
            if (!state.ContainsKey(GameVariableTypes.Sound))
            { state[GameVariableTypes.Sound] = 0;}
            state[GameVariableTypes.Sound] += value;
        }

        public static float Stability(this IGameStateVariables state) => state.Get(GameVariableTypes.Stability);
        public static void Stability(this IGameStateVariables state, float value) => state[GameVariableTypes.Stability] = value;
        public static void AddStability(this IGameStateVariables state, float value)
        {
            if (!state.ContainsKey(GameVariableTypes.Stability))
            { state[GameVariableTypes.Stability] = 0;}
            state[GameVariableTypes.Stability] += value;
        }

        public static float Progress(this IGameStateVariables state) => state.Get(GameVariableTypes.Progress);
        public static void Progress(this IGameStateVariables state, float value) => state[GameVariableTypes.Progress] = value;
        public static void AddProgress(this IGameStateVariables state, float value)
        {
            if (!state.ContainsKey(GameVariableTypes.Progress))
            { state[GameVariableTypes.Progress] = 0;}
            state[GameVariableTypes.Progress] += value;
        }
    }
}
