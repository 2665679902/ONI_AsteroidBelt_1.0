using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONI_AsteroidBelt_1.WorldCreator.Common
{
    internal class BandData
    {
        public BandData(double weight, SimHashes elementId, double temperature = -1, double density = 1, DiseaseID disease = DiseaseID.NONE)
        {
            Weight = weight;
            ElementId = elementId;
            Temperature = temperature;
            Density = density;
            this.disease = disease;
        }

        public enum DiseaseID { NONE, SLIMELUNG, FOOD_POISONING };

        /// <summary>
        /// 元素质量比重
        /// </summary>
        public virtual double Weight { get; set; }

        /// <summary>
        /// 元素的ID
        /// </summary>
        public virtual SimHashes ElementId { get; set; }

        /// <summary>
        /// 默认的温度
        /// </summary>
        public virtual double Temperature { get; set; }

        /// <summary>
        /// 密度比例：和标准密度的比例
        /// </summary>
        public virtual double Density { get; set; }

        /// <summary>
        /// 在这种生态单位里的病毒
        /// </summary>
        private readonly DiseaseID disease;

        public virtual byte Disease
        {
            get
            {
                switch (disease)
                {
                    case DiseaseID.NONE: return byte.MaxValue;
                    case DiseaseID.SLIMELUNG: return Db.Get().Diseases.GetIndex(Db.Get().Diseases.SlimeGerms.id);
                    case DiseaseID.FOOD_POISONING: return Db.Get().Diseases.GetIndex(Db.Get().Diseases.FoodGerms.id);
                    default: return byte.MaxValue;
                }

            }
        }

        /// <summary>
        /// 获得所记录的元素
        /// </summary>
        /// <returns></returns>
        public Element GetElement() { return ElementLoader.FindElementByHash(ElementId); }
    }
}
