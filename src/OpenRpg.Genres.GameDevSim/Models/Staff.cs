using System.Collections.Generic;
using OpenRpg.Core.Effects;
using OpenRpg.Genres.Characters;
using OpenRpg.Items.Extensions;

namespace OpenRpg.Genres.GameDevSim.Models
{
    public class Staff : DefaultCharacter, IHasEffects
    {
        public ICollection<Effect> UniqueEffects { get; set; } = new List<Effect>();
    
        public virtual IEnumerable<Effect> Effects
        {
            get
            {
                foreach (var classEffects in Class.ClassTemplate.Effects)
                { yield return classEffects; }

                foreach (var equipmentEffects in Equipment.GetEffects())
                { yield return equipmentEffects; }

                foreach (var uniqueEffects in UniqueEffects)
                { yield return uniqueEffects; }
            }
        }
    }
}