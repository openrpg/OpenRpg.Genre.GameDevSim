using System.Collections.Generic;
using OpenRpg.Core.Common;
using OpenRpg.Core.Effects;
using OpenRpg.Core.Requirements;

namespace OpenRpg.Genres.GameDevSim.Models
{
    public class GameTheme : IHasDataId, IHasLocaleDescription, IHasRequirements, IHasEffects
    {
        public int Id { get; set; }
        public string NameLocaleId { get; set; }
        public string DescriptionLocaleId { get; set; }
    
        public int Cost { get; set; }

        public IEnumerable<Requirement> Requirements { get; set; } = new List<Requirement>();
        public IEnumerable<Effect> Effects { get; set; } = new List<Effect>();
    }
}