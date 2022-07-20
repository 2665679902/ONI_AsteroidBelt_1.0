using System;
using static ONI_AsteroidBelt_1.AsteroidBeltData.Configs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONI_AsteroidBelt_1.WorldCreator;
using PLog;
using ONI_AsteroidBelt_1.WorldCreator.WorldData.World;
using System.IO;
using ONI_AsteroidBelt_1.Habitate;
using HarmonyLib;
using ONI_AsteroidBelt_1.WorldCreator.WorldData.Biome.BiomeProfile;
using ONI_AsteroidBelt_1.WorldCreator.Common;
using ONI_AsteroidBelt_1.WorldCreator.WorldData.Biome;

namespace ONI_AsteroidBelt_1.AsteroidBeltData
{
    internal static class DataManager
    {
        public static FileManager fileManager;

        public static void StringsInject()
        {
            //-------------------------------------
            Strings.Add($"STRINGS.CLUSTER_NAMES.{ClusterName.ToUpperInvariant()}.NAME", "小行星啊嗯");
            Strings.Add($"STRINGS.CLUSTER_NAMES.{ClusterName.ToUpperInvariant()}.DESCRIPTION", ClusterDescription);
            //-------------------------------------
            foreach (var world in Creator.WorldAccessible)
            {
                Strings.Add($"STRINGS.WORLDS.{world.GetName().ToUpper()}.NAME", world.GetName(true));
                Strings.Add($"STRINGS.WORLDS.{world.GetName().ToUpper()}.DESCRIPTION", world.GetDescription());
            }
        }

        public static void ReLoad()
        {
            Creator.WorldAccessible.Clear();
            Creator.WorldAccessible.Add(Worlds.AsteroidBeltSandStoneStart);
            Creator.WorldAccessible.Add(Worlds.AsteroidBeltLittleForest);
            Creator.WorldAccessible.Add(Worlds.AsteroidBeltLittleOil);
            Creator.WorldAccessible.Add(Worlds.AsteroidBeltLittleJungle);
            Creator.WorldAccessible.Add(Worlds.AsteroidBeltLittleSwamp);
            Creator.WorldAccessible.Add(Worlds.AsteroidBeltLittleOcean);
            Creator.WorldAccessible.Add(Worlds.AsteroidBeltLittleRust);
            Creator.WorldAccessible.Add(Worlds.AsteroidBeltLittleWasteland);
            Creator.WorldAccessible.Add(Worlds.AsteroidBeltLittleRadioactive);
            Creator.WorldAccessible.Add(Worlds.AsteroidBeltLittleMagma);
            Creator.WorldAccessible.Add(Worlds.AsteroidBeltLittleHotMarsh);
        }

        public static void Load(string modPath)
        {
            ReLoad();

            //-------------------------------------

            //Log.UnAble = true;
            Log.Path = Path.Combine(modPath, "Log", "AsteroidBelt");
            Log.ClearFile(true);
            Log.Debug("AsteroidBelt loaded.");
            fileManager = new FileManager (modPath);
            fileManager.WriteIn(HabitateBuilder.FormateFrame(65,65));
            fileManager.LoadHabitate();
            fileManager.LoadWorlds();
        }

        public static void WorldsDataInject(ProcGen.Worlds __instance)
        {
            try
            {
                Log.Debug("尝试空间信息注入" + __instance.worldCache.ContainsKey("expansion1::worlds/" + Creator.WorldAccessible[0].GetName()));
                if (__instance.worldCache.ContainsKey("expansion1::worlds/" + Creator.WorldAccessible[0].GetName()))
                {


                    foreach (var word in Creator.WorldAccessible)
                    {
                        var tempworld = __instance.worldCache["expansion1::worlds/" + word.GetName()];
                        Traverse.Create(tempworld).Property("worldsize").SetValue(new Vector2I(word.Width, word.Height + 2));
                    }
                    Log.Debug("世界空间信息注入完成");
                    FileManager.TakeBackFile();
                    fileManager.WriteIn(HabitateBuilder.FormateFrame(65, 65));
                    fileManager.LoadHabitate();
                }

            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
        }
    }
}
