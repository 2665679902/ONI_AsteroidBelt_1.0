using ONI_AsteroidBelt_1.WorldCreator.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONI_AsteroidBelt_1.WorldCreator.WorldData.World.WorldProfile
{
    internal class StartWorld: CommonWorld
    {
        /// <summary>
        /// 要在开局的时候直接刷在地上的物品 -> 物品名字：数量
        /// </summary>
        public virtual List<Things> StartingItems { get; set; } = new List<Things>();

        //开始世界的中心点
        public Vector2I Center { get; set; } = new Vector2I(0,0);
        //开始世界的模型
        public string StartingTemplate { private get; set; }
        //获得模型
        public TemplateContainer GetStartingTemplate() { return TemplateCache.GetTemplate(StartingTemplate);}
    }
}
