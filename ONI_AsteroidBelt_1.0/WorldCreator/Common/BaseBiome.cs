using ONI_AsteroidBelt_1.WorldCreator.Common;
using PLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONI_AsteroidBelt_1.WorldCreator.Common
{
    internal class BaseBiome
    {
        //-------------------------------------------------------------------- 静态------------------------------------------------------

        /// <summary>
        /// BaseBiome的默认元素分配方案
        /// </summary>
        private static readonly Func<BandData[], BandData[]> P_baseAssignment = (bandData) =>
        {
            int num = 10000;

            double[] doubles = new double[bandData.Count()];

            double total = 0;

            BandData[] res = new BandData[num];

            for (int i = 0; i < bandData.Count(); i++)
            {
                total += bandData[i].Weight;
                doubles[i] = bandData[i].Weight;
            }

            double rate = num / total;

            int current = 0;

            for (int i = 0; i < doubles.Count(); i++)
            {
                for (int j = 0; j < doubles[i] * rate && current < res.Count(); j++)
                {
                    res[current++] = bandData[i];
                }
            }

            if (current < res.Count())
                for (int i = current; i < res.Count(); i++)
                {
                    res[i] = bandData[bandData.Count()];
                }


            return res;
        };

        /// <summary>
        /// BaseBiome现在持有的元素分配方案保存处
        /// </summary>
        private static Func<BandData[], BandData[]> baseAssignment = P_baseAssignment;

        /// <summary>
        /// 当默认方案改变时触发此事件
        /// </summary>
        private static EventHandler AssignmentChanged;

        /// <summary>
        /// BaseBiome现在持有的元素分配方案
        /// </summary>
        public static Func<BandData[], BandData[]> BaseAssignment
        {
            get { return baseAssignment; }
            set
            {
                AssignmentChanged(value, null);
                baseAssignment = value;
            }
        }

        /// <summary>
        /// 重置分配方案为默认方案
        /// </summary>
        public static void ResetBaseAssignment()
        {
            BaseAssignment = P_baseAssignment;
        }

        /// <summary>
        /// 所有的生态的质量倍率
        /// </summary>
        public static int ResourceModifier { get; set; } = 1;






        //-------------------------------------------------------------------- 动态------------------------------------------------------

        public BaseBiome(
            string backgroundSubworld,
            double defaultTemperature,
            BandData[] bands,
            List<Critter> spawnablesOnFloor,
            List<Critter> spawnablesOnCeil,
            List<Critter> spawnablesInGround,
            List<Critter> spawnablesInLiquid,
            List<Critter> spawnablesInAir)
        {
            BackgroundSubworld = backgroundSubworld;
            DefaultTemperature = defaultTemperature;
            this.bands = bands;
            SpawnablesOnFloor = spawnablesOnFloor ?? new List<Critter>();
            SpawnablesOnCeil = spawnablesOnCeil ?? new List<Critter>();
            SpawnablesInGround = spawnablesInGround ?? new List<Critter>();
            SpawnablesInLiquid = spawnablesInLiquid ?? new List<Critter>();
            SpawnablesInAir = spawnablesInAir ?? new List<Critter>();

            //获取基础分配方案
            currentAssignment = BaseAssignment;
            //挂接基础方案更改事件
            AssignmentChanged += (s, e) =>
            {
                if (s is Func<BandData[], BandData[]> func)
                {
                    //如果这个生态的现在的分配方案不是特别配置过的
                    if (Assignment.Equals(BaseAssignment))
                    {
                        Assignment = func;
                    }
                }
            };
            //生成分配结果
            bandResult = Assignment.Invoke(bands);
        }



        /// <summary>
        /// 以什么世界作为背景
        /// </summary>
        public virtual string BackgroundSubworld { get; set; }

        /// <summary>
        /// 默认温度
        /// </summary>
        public virtual double DefaultTemperature { get; set; }

        /// <summary>
        /// 当前的分配方案
        /// </summary>
        private Func<BandData[], BandData[]> currentAssignment;

        /// <summary>
        /// 设定新的分配方案会重置分配的结果（但是会调用.Equals函数，如果和上一个方案相等就会取消调用）
        /// </summary>
        public virtual Func<BandData[], BandData[]> Assignment
        {
            get { return currentAssignment; }
            set
            {
                if (!currentAssignment.Equals(value))
                {
                    currentAssignment = value;
                    bandResult = value(bands);
                }
            }
        }

        /// <summary>
        /// 生态包含的物质组
        /// </summary>
        private BandData[] bands;

        /// <summary>
        /// 记录分配物质的分配结果，由Assignment方案产生
        /// </summary>
        private BandData[] bandResult;

        /// <summary>
        /// 可以刷在地上的东西
        /// </summary>
        public virtual List<Critter> SpawnablesOnFloor { get; set; }

        /// <summary>
        /// 可以刷在天花板上的东西
        /// </summary>
        public virtual List<Critter> SpawnablesOnCeil { get; set; }

        /// <summary>
        /// 可以刷在地里的东西
        /// </summary>
        public virtual List<Critter> SpawnablesInGround { get; set; }

        /// <summary>
        /// 可以刷在水里的东西
        /// </summary>
        public virtual List<Critter> SpawnablesInLiquid { get; set; }

        /// <summary>
        /// 可以刷在空中的东西
        /// </summary>
        public virtual List<Critter> SpawnablesInAir { get; set; }

        /// <summary>
        /// 获取一个元素，由一个【0，1】随机值在元素列表的条带中取出
        /// </summary>
        /// <param name="f">随机值</param>
        /// <returns>元素</returns>
        public virtual BandData GetBand(double f)
        {
            var res = (int)(f * 10000) < 10000 ? (int)(f * 10000): 9999;
            return bandResult[res];
        }

        /// <summary>
        /// 获得元素的物理属性
        /// </summary>
        /// <param name="band">元素</param>
        /// <param name="modifier">倍率</param>
        /// <returns>物理属性</returns>
        public virtual Sim.PhysicsData GetPhysicsData(BandData band, double modifier = 1)
        {
            //如果band.temperature < 0(没有设定过温度) 并且 默认温度 > 0(设定过温度) 就返回默认温度，否则返回设定温度
            double temperature = band.Temperature < 0 && DefaultTemperature > 0 ? DefaultTemperature : band.Temperature;
            return GetPhysicsData(band.GetElement(), modifier * band.Density, temperature);
        }

        /// <summary>
        /// 获得元素的物理属性
        /// </summary>
        /// <param name="element">元素</param>
        /// <param name="modifier">倍率</param>
        /// <param name="temperature">温度</param>
        /// <returns>物理属性</returns>
        public virtual Sim.PhysicsData GetPhysicsData(Element element, double modifier = 1, double temperature = -1)
        {
            Sim.PhysicsData defaultData = element.defaultValues;
            return new Sim.PhysicsData()
            {
                mass = (float)(defaultData.mass * modifier * (element.IsSolid ? ResourceModifier : 1)),
                temperature = (float)(temperature == -1 ? defaultData.temperature : temperature),
                pressure = defaultData.pressure
            };
        }

    }
}
