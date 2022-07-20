using HarmonyLib;
using ONI_AsteroidBelt_1.WorldCreator.CreatorActions;
using ONI_AsteroidBelt_1.WorldCreator.Common;
using ONI_AsteroidBelt_1.WorldCreator.WorldData.World.WorldProfile;
using PLog;
using ProcGenGame;
using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ONI_AsteroidBelt_1.WorldCreator
{
    internal class Creator
    {
        public static bool RandomRead { get; set; } = false;

        public static List<CommonWorld> WorldAccessible { get; set; } = new List<CommonWorld>();

        public static Random CreatorRandom { get; set; }

        public static bool Catch(WorldGen __instance, ref bool __result, ref Sim.Cell[] cells, ref Sim.DiseaseCell[] dc, int baseId)
        {
            //判断是否还能取值
            if (!WorldAccessible.Any())
                return false;

            //生成取值
            CreatorRandom = new Random(__instance.data.globalTerrainSeed);

            //获取世界
            CommonWorld world;
            if(RandomRead)
                world = WorldAccessible[CreatorRandom.Next(0, WorldAccessible.Count())];
            else
                world = WorldAccessible.First();
            WorldAccessible.Remove(world);

            try
            {
                //生成世界
                __result = CreatWorld(__instance, ref cells, ref dc, baseId, world);
            }
            catch(Exception e)
            {
                Log.Error("世界生成错误错误抛出 -> "+e.Message);
                return false;
            }
            

            return true;
        }

        public static bool CreatWorld(WorldGen gen, ref Sim.Cell[] cells, ref Sim.DiseaseCell[] dc, int baseId, CommonWorld world)
        {
            Log.Debug("获取世界信息成功");

            // 把方法里要用的私有属性弄出来
            var worldGen = Traverse.Create(gen);
            var data = gen.data;
            var myRandom = worldGen.Field("myRandom").GetValue<SeededRandom>();// 随机种子用的

            //几个用于表示状态的参数
            var updateProgressFn = worldGen.Field("successCallbackFn").GetValue<WorldGen.OfflineCallbackFunction>();
            var errorCallback = worldGen.Field("errorCallback").GetValue<Action<OfflineWorldGen.ErrorInfo>>();
            var running = worldGen.Field("running");

            Log.Debug("获取世界资源");

            running.SetValue(true);


            // 初始化 noise maps
            Log.Debug("初始化 noise maps");
            updateProgressFn(UI.WORLDGEN.GENERATENOISE.key, 0f, WorldGenProgressStages.Stages.NoiseMapBuilder);
            var noiseMap = NoiseMapper.GenerateNoiseMap(world.Width, world.Height);
            updateProgressFn(UI.WORLDGEN.GENERATENOISE.key, 0.9f, WorldGenProgressStages.Stages.NoiseMapBuilder);

            //分配格子
            Log.Debug("分配格子");
            CellsSeparater.SeparateCells(world);


            // 设置生物群落
            Log.Debug("Setting biomes");
            BiomeSetter.SetBiomes(data.overworldCells, world);

            // 重写 WorldGen.RenderToMap 函数，该函数调用默认地形和边界生成，放置要素并生成动植物
            cells = new Sim.Cell[Grid.CellCount];
            var bgTemp = new float[Grid.CellCount];
            dc = new Sim.DiseaseCell[Grid.CellCount];

            // 初始化地形
            Log.Debug("Clearing terrain");
            updateProgressFn(UI.WORLDGEN.CLEARINGLEVEL.key, 0f, WorldGenProgressStages.Stages.ClearingLevel);
            TerrainSetter.ClearTerrain(cells, bgTemp, dc);
            updateProgressFn(UI.WORLDGEN.CLEARINGLEVEL.key, 1f, WorldGenProgressStages.Stages.ClearingLevel);

            // 绘制自定义地形
            Log.Debug("Drawing terrain");
            updateProgressFn(UI.WORLDGEN.PROCESSING.key, 0f, WorldGenProgressStages.Stages.Processing);
            TerrainSetter.DrawCustomTerrain(data, cells, bgTemp, dc, noiseMap, world);
            updateProgressFn(UI.WORLDGEN.PROCESSING.key, 0.9f, WorldGenProgressStages.Stages.Processing);


            // 绘制出生点 和 模板生态
            var templateSpawnTargets = new List<KeyValuePair<Vector2I, TemplateContainer>>();
            if (world is StartWorld startWorld)
            {
                Log.Debug("Generating starting template");
                var startPos = startWorld.Center;
                data.gameSpawnData.baseStartPos = startPos;//设置出生点
                TemplateContainer startingBaseTemplate = startWorld.GetStartingTemplate();

                Log.Debug("Adding starting items");
                var itemPos = new Vector2I(3, 1);
                Log.Debug("获取初始items："+ startWorld.StartingItems.Count());
                foreach (var entry in startWorld.StartingItems) // Add custom defined starting items
                    startingBaseTemplate.pickupables.Add(entry.GetPrefab(itemPos.x, itemPos.y));
                Log.Debug("尝试加入中心模块");
                templateSpawnTargets.Add(new KeyValuePair<Vector2I, TemplateContainer>(startPos, startingBaseTemplate));

            }

            // Tempelate
            Log.Debug("Placing Tempelate");
            TempelateMananger.AddTempelates(templateSpawnTargets, world);
            
            // Draw borders
            Log.Debug("Drawing borders");
            updateProgressFn(UI.WORLDGEN.DRAWWORLDBORDER.key, 0f, WorldGenProgressStages.Stages.DrawWorldBorder);
            ISet<Vector2I> borderCells = WorldBorderManager.DrawWorldBorders(cells, world);
            updateProgressFn(UI.WORLDGEN.DRAWWORLDBORDER.key, 1f, WorldGenProgressStages.Stages.DrawWorldBorder);

            // Settle simulation
            // 这会将单元格写入世界，然后执行两个游戏帧的模拟，然后保存游戏
            Log.Debug("Settling sim");
            running.SetValue(WorldGenSimUtil.DoSettleSim(gen.Settings, ref cells, ref bgTemp, ref dc, updateProgressFn, data, templateSpawnTargets, errorCallback, baseId));

            // Place templates, pretty much just the printing pod
            //把模板放进世界
            Log.Debug("Placing templates");
            var claimedCells = new Dictionary<int, int>();
            foreach (KeyValuePair<Vector2I, TemplateContainer> keyValuePair in templateSpawnTargets)
                data.gameSpawnData.AddTemplate(keyValuePair.Value, keyValuePair.Key, ref claimedCells);

            // 添加植物、生物和物品
            Log.Debug("Adding critters, etc");
            updateProgressFn(UI.WORLDGEN.PLACINGCREATURES.key, 0f, WorldGenProgressStages.Stages.PlacingCreatures);
            CritterPlacer.PlaceSpawnables(cells, data.gameSpawnData.pickupables, world);
            updateProgressFn(UI.WORLDGEN.PLACINGCREATURES.key, 100f, WorldGenProgressStages.Stages.PlacingCreatures);

            Log.Debug("end one");

            // Finish and save
            Log.Debug("Saving world");
            gen.SaveWorldGen();
            updateProgressFn(UI.WORLDGEN.COMPLETE.key, 1f, WorldGenProgressStages.Stages.Complete);

            return true;
        }

    }


}
