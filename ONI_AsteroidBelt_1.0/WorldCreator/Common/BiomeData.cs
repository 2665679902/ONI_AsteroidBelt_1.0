using ONI_AsteroidBelt_1.WorldCreator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONI_AsteroidBelt_1.WorldCreator.Common
{
    internal class BiomeData<TBehaviorPattern, TBiomeLocation>
    {
        /// <summary>
        /// 描述的生态对象
        /// </summary>
        public virtual BaseBiome BiomeType { get; set; }

        /// <summary>
        /// 包含该生态的格子
        /// </summary>
        public virtual HashSet<Vector2I> Cells { get; set; } = new HashSet<Vector2I>();

        /// <summary>
        /// 生态生成的行为模式
        /// </summary>
        public virtual TBehaviorPattern Pattern { get; set; }

        /// <summary>
        /// 生态生成的在世界中的相对位置
        /// </summary>
        public virtual TBiomeLocation Location { get; set; }

    }
}
