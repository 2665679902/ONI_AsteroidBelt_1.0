using Klei;
using ONI_AsteroidBelt_1.WorldCreator.Common;
using ONI_AsteroidBelt_1.WorldCreator.WorldData.World.WorldProfile;
using PLog;
using System.Collections.Generic;
using static ONI_AsteroidBelt_1.WorldCreator.Creator;

namespace ONI_AsteroidBelt_1.WorldCreator.CreatorActions
{
    internal class TerrainSetter
    {
        public static void ClearTerrain(Sim.Cell[] cells, float[] bgTemp, Sim.DiseaseCell[] dc)
        {
            //遍历每一个格子
            for (int index = 0; index < cells.Length; ++index)
            {
                //每个格子填入真空和可承载元素的列表？
                cells[index].SetValues(ElementLoader.FindElementByHash(SimHashes.Vacuum), ElementLoader.elements);
                //这个应该是温度
                bgTemp[index] = -1f;
                //新建一个疾病格子放进去
                dc[index] = new Sim.DiseaseCell
                {
                    diseaseIdx = byte.MaxValue
                };
            }
        }

        public static void DrawCustomTerrain(Data data, Sim.Cell[] cells, float[] bgTemp, Sim.DiseaseCell[] dc, float[,] noiseMap, CommonWorld world)
        {
            var claimedCells = new HashSet<int>();

            for (int index = 0; index < data.terrainCells.Count; ++index)
                data.terrainCells[index].InitializeCells(claimedCells);
            //if (false)
            //    return biomeCells;

            // 使用平滑噪声映射，通过元素带轮廓将噪声值映射到元素
            void SetTerrain(BaseBiome biome, ISet<Vector2I> positions)
            {
                //遍历位置
                foreach (var pos in positions)
                {
                    float e = noiseMap[pos.x, pos.y];
                    BandData bandData = biome.GetBand(e);
                    Element element = bandData.GetElement();
                    Sim.PhysicsData elementData = biome.GetPhysicsData(bandData);
                    int cell = Grid.PosToCell(pos);//从位置唯一映射到格子
                    cells[cell].SetValues(element, elementData, ElementLoader.elements);
                    //填入细菌
                    dc[cell] = new Sim.DiseaseCell()
                    {
                        diseaseIdx = bandData.Disease,
                        elementCount = CreatorRandom.Next(10000, 1000000),
                    };
                }
            }


            //为相对应的格子添加地形
            foreach (var biome in world.Biomes)
            {
                SetTerrain(biome.BiomeType, biome.Cells);

                Log.Debug($"Set biome {biome.Cells.Count} cells");
            }


        }
    }
}
