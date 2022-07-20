using PLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateClasses;

namespace ONI_AsteroidBelt_1.WorldCreator.Common
{
    internal class BaseItemData
    {
        public virtual string Name { get; set; }
    }

    internal class Things: BaseItemData
    {
        public virtual int Amount { get; set; } = 1;

        public virtual Prefab GetPrefab(int x, int y)
        {
            return new Prefab(Name, Prefab.Type.Pickupable, x, y, 0, _units: Amount);
        }
    }

    internal class TemplateData : BaseItemData
    {
        public virtual int Min { get; set; } = 1;

        public virtual int Max { get; set; } = 1;

        public virtual TemplateContainer GetTemplate()
        {
            return TemplateCache.GetTemplate(Name);
        }
    }

    internal class Critter : BaseItemData
    {

        public Critter(string name,double possibility )
        {
            Possibility = possibility;
            Name = name;
        }

        public virtual double Possibility { get; set; } = 0.001;

        public virtual Prefab GetPrefab(int x, int y)
        {
            return new Prefab(Name, Prefab.Type.Pickupable, x, y, 0);
        }
    }

}
