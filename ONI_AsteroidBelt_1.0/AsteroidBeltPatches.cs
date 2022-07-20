using HarmonyLib;
using Klei.CustomSettings;
using KMod;
using PLog;
using ProcGenGame;
using System;
using static ONI_AsteroidBelt_1.AsteroidBeltData.Configs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONI_AsteroidBelt_1.WorldCreator;
using TUNING;
using ONI_AsteroidBelt_1.Habitate;
using Database;
using ONI_AsteroidBelt_1.AsteroidBeltData;
using ProcGen;
using UnityEngine;
using Klei;
using TemplateClasses;
using Delaunay.Geo;

namespace ONI_AsteroidBelt_1
{
    public class AsteroidBeltPatches : UserMod2
    {

        public override void OnLoad(Harmony harmony)
        {
            base.OnLoad(harmony);
            DataManager.Load(mod.ContentPath);
        }

        /// <summary>
        /// 捕获地图生成结果
        /// </summary>
        [HarmonyPatch(typeof(WorldGen), "RenderOffline")]
        public static class WorldGen_RenderOffline_Patch
        {
            public static bool Prefix(WorldGen __instance, ref bool __result, ref Sim.Cell[] cells, ref Sim.DiseaseCell[] dc, int baseId)
            {

                Log.Debug("-------------------世界生成函数捕获----------------------");
                Log.Debug($"Size  X: {__instance.World.size.X}    Y: {__instance.World.size.Y}");
                return !(IsAsteroidBelt && Creator.Catch(__instance, ref __result, ref cells, ref dc, baseId));
            }

            public static void Postfix()
            {
                Log.Debug("捕获结束");
            }
        }



        [HarmonyPatch(typeof(BestFit), "CountRocketInteriors")]
        public class CountRocketInteriorsPatch
        {
            public static void Prefix()
            {
                ROCKETRY.ROCKET_INTERIOR_SIZE = new Vector2I(70, 70);
            }

            public static void Postfix()
            {
                ROCKETRY.ROCKET_INTERIOR_SIZE = new Vector2I(32, 32);
            }
        }

        [HarmonyPatch(typeof(ClusterManager), "CreateRocketInteriorWorld")]
        public class CreateRocketInteriorWorldPatch
        {
            public static void Prefix(ref string interiorTemplateName)
            {
                //Log.Debug($"CreateRocketInteriorWorld X:{ROCKETRY.ROCKET_INTERIOR_SIZE.X}  Y:{ROCKETRY.ROCKET_INTERIOR_SIZE.Y}");
                if (interiorTemplateName == "expansion1::interiors/habitat_huge")
                {
                    ROCKETRY.ROCKET_INTERIOR_SIZE = new Vector2I(70, 70);
                }
                else
                {
                    ROCKETRY.ROCKET_INTERIOR_SIZE = new Vector2I(32, 32);
                }
                
            }

            public static void Postfix()
            {
                ROCKETRY.ROCKET_INTERIOR_SIZE = new Vector2I(32, 32);
            }
        }

        






        [HarmonyPatch(typeof(WorldContainer), "PlaceInteriorTemplate")]
        public class PlaceInteriorTemplatePatch
        {
            public static void Postfix(ref WorldContainer __instance, ref string template_name, ref System.Action callback)
            {
                var overworldCell = Traverse.Create(__instance).Field("overworldCell").GetValue<WorldDetailSave.OverworldCell>();
                overworldCell.zoneType = template_name != "expansion1::interiors/habitat_huge" ? SubWorld.ZoneType.RocketInterior : SubWorld.ZoneType.Sandstone;
                Log.OpenFile();
            }
        }



        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
        {
            public static void Prefix()
            {
                Log.Debug("Get it!");
                ROCKETRY.ROCKET_INTERIOR_SIZE = new Vector2I(70, 70);
                HabitateBuilder.AddBuildingStrings(MyHabitate.ID, "星舰！", " 很大 ", " 超级大");
                HabitateBuilder.AddBuildingStrings(MyNoseconeBasic.ID, "一般头锥", "它和泥土盆子一样简单 ", "它和泥土盆子一样简单");
                int num = BUILDINGS.PLANORDER.FindIndex((PlanScreen.PlanInfo x) => x.category == "Base");
                if (num == -1)
                {
                    return;
                }
                ModUtil.AddBuildingToPlanScreen(new HashedString(num), MyHabitate.ID);
                ModUtil.AddBuildingToPlanScreen(new HashedString(num), MyNoseconeBasic.ID);
                HabitateBuilder.AddRocketModuleToBuildList(MyHabitate.ID);
                HabitateBuilder.AddRocketModuleToBuildList(MyNoseconeBasic.ID);
            }
        }

        [HarmonyPatch(typeof(Techs), "Init")]
        public static class Database_Techs_Init_Patch
        {
            public static void Postfix(ref Techs __instance)
            {
                __instance.TryGetTechForTechItem("RationBox").unlockedItemIDs.Add(MyHabitate.ID);
                __instance.TryGetTechForTechItem("RationBox").unlockedItemIDs.Add(MyNoseconeBasic.ID);
            }
        }

        /// <summary>
        /// 数据库注入
        /// </summary>
        [HarmonyPatch(typeof(Db), "Initialize")]
        public class Db_Initialize_Patch
        {
            public static void Prefix()
            {
                Log.Debug("Db_Initialize_Patch Prefix -> 数据库注入");
                DataManager.StringsInject();
            }
        }


        /// <summary>
        /// 更改世界尺寸函数
        /// </summary>
        [HarmonyPatch(typeof(Worlds), "UpdateWorldCache")]
        public static class Worlds_UpdateWorldCache_Patch
        {
            public static void Postfix(Worlds __instance)
            {
                DataManager.WorldsDataInject(__instance);
            }
        }


        [HarmonyPatch(typeof(Cluster), "BeginGeneration")]
        public static class BeginGenerationPatch
        {
            public static void Postfix()
            {
                DataManager.ReLoad();
            }
        }




        /// <summary>
        /// 判断是不是这个模组生成的小行星群
        /// </summary>
        public static bool IsAsteroidBelt
        {
            get
            {
                return CustomGameSettings.Instance.GetCurrentQualitySetting(CustomGameSettingConfigs.ClusterLayout).id == ("clusters/" + ClusterName);
            }
        }
    }
}
