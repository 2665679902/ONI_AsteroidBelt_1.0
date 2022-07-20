using ONI_AsteroidBelt_1.WorldCreator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONI_AsteroidBelt_1.WorldCreator.Common
{
    internal abstract class BaseWorld<TBehaviorPattern, TBiomeLocation>
    {
        /// <summary>
        /// 世界的高度
        /// </summary>
        public virtual int Height { get; set; }

        /// <summary>
        /// 世界的宽度
        /// </summary>
        public virtual int Width { get; set; }

        /// <summary>
        /// 世界包含的生态
        /// </summary>
        public virtual List<BiomeData<TBehaviorPattern, TBiomeLocation>> Biomes { get; set; }=new List<BiomeData<TBehaviorPattern, TBiomeLocation>>();

        /// <summary>
        /// 世界里包含的模板
        /// </summary>
        public virtual List<TemplateData> Templates { get; set; }=new List<TemplateData>();

        /// <summary>
        /// 获得世界的名字
        /// </summary>
        /// <returns>名字</returns>
        public abstract string GetName(bool Chinese = false);

        /// <summary>
        /// 获得世界的描述
        /// </summary>
        /// <returns>描述</returns>
        public abstract string GetDescription();
    }
}
