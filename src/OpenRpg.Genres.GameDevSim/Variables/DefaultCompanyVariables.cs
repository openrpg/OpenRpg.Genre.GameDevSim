using System.Collections.Generic;
using OpenRpg.Core.Variables;

namespace OpenRpg.Genres.GameDevSim.Variables
{
    public class DefaultCompanyVariables : DefaultVariables<object>, ICompanyVariables
    {
        public DefaultCompanyVariables(IDictionary<int, object> internalVariables = null) : base(GameDevSimVariableTypes.CompanyVariables, internalVariables)
        {
        }
    }
}

