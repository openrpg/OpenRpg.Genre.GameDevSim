using System.Collections.Generic;
using OpenRpg.Core.Common;
using OpenRpg.Core.Effects;
using OpenRpg.Core.Stats;
using OpenRpg.Genres.GameDevSim.Variables;

namespace OpenRpg.Genres.GameDevSim.Models
{
    public class Company : IHasDataId, IHasLocaleDescription, IHasEffects, IHasStats
    {
        public int Id { get; set; }
        public string NameLocaleId { get; set; }
        public string DescriptionLocaleId { get; set; }

        public IStatsVariables Stats { get; set; } = new DefaultStatsVariables();
        public ICollection<Staff> Staff { get; set; } = new List<Staff>();
        public ICollection<Game> Games { get; set; } = new List<Game>();
        public ICompanyVariables Variables { get; set; } = new DefaultCompanyVariables();
        public ICollection<Effect> UniqueEffects { get; set; } = new List<Effect>();
    
        public IEnumerable<Effect> Effects
        {
            get
            {
                foreach (var staffMember in Staff)
                {
                    foreach (var effect in staffMember.Effects)
                    { yield return effect; }
                }

                foreach (var uniqueEffects in UniqueEffects)
                { yield return uniqueEffects; }
            }
        }
    }
}
