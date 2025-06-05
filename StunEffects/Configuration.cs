using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;

namespace StunEffects
{
    public class Configuration : IRocketPluginConfiguration
    {
        public ushort EffectID { get; set; }
        public int HealthThreashold { get; set; }

        public ToggleBodyPartPlayEffect ToggleBodyPartPlayEffect { get; set; }

        public bool Debug { get; set; }

        public void LoadDefaults()
        {
            EffectID = 49500;
            HealthThreashold = 85;

            ToggleBodyPartPlayEffect = new ToggleBodyPartPlayEffect()
            {
                Head = true,
                Torso = true,
                Arms = true,
                Legs = true
            };

            Debug = false;
        }
    }

    public class ToggleBodyPartPlayEffect
    {
        public bool Head { get; set; }
        public bool Torso { get; set; }
        public bool Arms { get; set; }
        public bool Legs { get; set; }
    }
}
