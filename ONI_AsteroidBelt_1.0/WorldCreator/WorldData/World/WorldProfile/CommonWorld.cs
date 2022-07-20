using ONI_AsteroidBelt_1.WorldCreator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONI_AsteroidBelt_1.WorldCreator.WorldData.World.WorldProfile
{
    internal class CommonWorld : BaseWorld<BehaviorPattern, BiomeLocation>
    {
        public string Name {private get; set; }

        public string ChineseName { private get; set; }

        public string Description { private get; set; }

        public override string GetDescription()
        {
            return Description;
        }

        public override string GetName(bool Chinese = false)
        {
            if(Chinese)
                return ChineseName;
            return Name;
        }
    }
}
