using System.Collections.Generic;
using OpenRpg.Core.Variables;

namespace OpenRpg.Genres.GameDevSim.Variables
{
    public class DefaultGameStateVariables : DefaultVariables<float>, IGameStateVariables
    {
        public DefaultGameStateVariables(IDictionary<int, float> internalVariables = null) : base(GameDevSimVariableTypes.GameStateVariables, internalVariables)
        {
        }
    }
}

