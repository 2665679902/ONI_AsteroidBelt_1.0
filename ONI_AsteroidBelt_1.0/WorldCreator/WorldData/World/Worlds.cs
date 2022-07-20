using ONI_AsteroidBelt_1.WorldCreator.Common;
using ONI_AsteroidBelt_1.WorldCreator.WorldData.Biome;
using ONI_AsteroidBelt_1.WorldCreator.WorldData.World.WorldProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONI_AsteroidBelt_1.WorldCreator.WorldData.World
{
    internal class Worlds
    {
        private static BiomeData<BehaviorPattern, BiomeLocation> GetBiomeData(BaseBiome biome, BiomeLocation location, BehaviorPattern pattern)
        {
            return new BiomeData<BehaviorPattern, BiomeLocation>() { BiomeType = biome, Location = location, Pattern = pattern };
        }

        private static List<BiomeData<BehaviorPattern, BiomeLocation>> GetSingle(BaseBiome biome, BiomeLocation location, BehaviorPattern pattern)
        {
            var res = new List<BiomeData<BehaviorPattern, BiomeLocation>>
            {
                GetBiomeData(biome, location, pattern)
            };

            return res;
        }



        public static StartWorld AsteroidBeltSandStoneStart = new StartWorld()
        {
            Height = 100, Width = 90,

            Biomes = GetSingle(Biomes.LittleSandStoneBiome, BiomeLocation.Middle, BehaviorPattern.Punctate),

            StartingTemplate = "bases/sandstoneBase",

            Name = "AsteroidBeltSandStoneStart",

            Templates = new List<TemplateData> {
                new TemplateData() { Name = "expansion1::poi/warp/teleporter", Max = 1, Min = 1 } ,
                new TemplateData() { Name = "expansion1::poi/warp/sender", Max = 1, Min = 1 } ,
                new TemplateData() { Name = "expansion1::poi/warp/receiver", Max = 1, Min = 1 } ,
                new TemplateData() { Name = "expansion1::poi/poi_geyser_dirty_slush", Max = 1, Min = 1 } 
            },

            ChineseName = "土丘",

            Description = "一个摇摇欲坠的小土丘，记得带上你的老鼠！和哈奇？"
        };

        public static StartWorld AsteroidBeltLittleForest = new StartWorld()
        {
            Height = 100,
            Width = 90,

            Biomes = GetSingle(Biomes.LittleForestBiome, BiomeLocation.Middle, BehaviorPattern.Circular),

            StartingTemplate = "expansion1::bases/warpworldForestBase",

            Templates = new List<TemplateData> {
                new TemplateData() { Name = "geysers/big_volcano", Max = 2, Min = 1 }
            },

            Name = "AsteroidBeltLittleForest",

            ChineseName = "绿洲",

            Description = "一个小绿洲，有树，没有树鼠"
        };


        public static CommonWorld AsteroidBeltLittleOil = new CommonWorld()
        {
            Height = 100,
            Width = 90,

            Biomes = GetSingle(Biomes.LittleOilBiome, BiomeLocation.Down, BehaviorPattern.LowFull),

            Templates = new List<TemplateData> {
                new TemplateData() { Name = "geysers/oil_drip", Max = 2, Min = 1 }
            },

            Name = "AsteroidBeltLittleOil",

            ChineseName = "原油",

            Description = "很多油！和一个可爱的毛茸茸"
        };

        public static CommonWorld AsteroidBeltLittleJungle = new CommonWorld()
        {
            Height = 100,
            Width = 90,

            Biomes = GetSingle(Biomes.LittleJungleBiome, BiomeLocation.Down, BehaviorPattern.Bulk),

            Templates = new List<TemplateData> {
                new TemplateData() { Name = "geysers/chlorine_gas", Max = 1, Min = 1 }
            },

            Name = "AsteroidBeltLittleJungle",

            ChineseName = "丛林",

            Description = "氯气和氢气组成的酸性世界"
        };

        public static CommonWorld AsteroidBeltLittleSwamp = new CommonWorld()
        {
            Height = 100,
            Width = 90,

            Biomes = GetSingle(Biomes.LittleSwampBiome, BiomeLocation.Down, BehaviorPattern.Punctate),

            Templates = new List<TemplateData> {
                new TemplateData() { Name = "geysers/hot_water", Max = 1, Min = 1 }
            },

            Name = "AsteroidBeltLittleSwamp",

            ChineseName = "沼泽",

            Description = "粘嗒嗒的世界，但是谁会不喜欢玩泥巴呢？"
        };

        public static CommonWorld AsteroidBeltLittleOcean = new CommonWorld()
        {
            Height = 100,
            Width = 90,

            Biomes = GetSingle(Biomes.LittleOceanBiome, BiomeLocation.Down, BehaviorPattern.LowFull),

            Templates = new List<TemplateData> {
                new TemplateData() { Name = "geysers/salt_water", Max = 1, Min = 1 }
            },

            Name = "AsteroidBeltLittleOcean",

            ChineseName = "海洋",

            Description = "有一只无害且和平的小生物"
        };

        public static CommonWorld AsteroidBeltLittleRust = new CommonWorld()
        {
            Height = 100,
            Width = 90,

            Biomes = GetSingle(Biomes.LittleRustBiome, BiomeLocation.Down, BehaviorPattern.Bulk),

            Templates = new List<TemplateData> {
                new TemplateData() { Name = "geysers/molten_iron", Max = 1, Min = 1 }
            },

            Name = "AsteroidBeltLittleRust",

            ChineseName = "锈带",

            Description = "这个地方以前是一颗金属星，但是现在生锈了"
        };

        public static CommonWorld AsteroidBeltLittleWasteland = new CommonWorld()
        {
            Height = 100,
            Width = 90,

            Biomes = GetSingle(Biomes.LittleWastelandBiome, BiomeLocation.Down, BehaviorPattern.Circular),

            Templates = new List<TemplateData> {
                new TemplateData() { Name = "expansion1::geysers/liquid_sulfur", Max = 1, Min = 1 }
            },

            Name = "AsteroidBeltLittleWasteland",

            ChineseName = "荒野",

            Description = "破碎的荒野上还有一些坚强的生命"
        };

        public static CommonWorld AsteroidBeltLittleRadioactive = new CommonWorld()
        {
            Height = 100,
            Width = 90,

            Biomes = GetSingle(Biomes.LittleRadioactiveBiome, BiomeLocation.Middle, BehaviorPattern.Punctate),

            Templates = new List<TemplateData> {
                new TemplateData() { Name = "expansion1::geysers/molten_cobalt", Max = 1, Min = 1 }
            },

            Name = "AsteroidBeltLittleRadioactive",

            ChineseName = "辐射",

            Description = "一块飘荡的宇宙中的放射性物质，和几只需要拯救的蜜蜂"
        };

        public static CommonWorld AsteroidBeltLittleMagma = new CommonWorld()
        {
            Height = 100,
            Width = 90,

            Biomes = new List<BiomeData<BehaviorPattern, BiomeLocation>>
            { 
                GetBiomeData(Biomes.LittleNiobiumBiome, BiomeLocation.Down, BehaviorPattern.LowFull),
                GetBiomeData(Biomes.LittleMagmaBiome, BiomeLocation.Middle, BehaviorPattern.Bulk),
                GetBiomeData(Biomes.LittleMagmaBiome, BiomeLocation.Left, BehaviorPattern.Bulk),
                GetBiomeData(Biomes.LittleMagmaBiome, BiomeLocation.Right, BehaviorPattern.Bulk),

            },

            Templates = new List<TemplateData> {
                new TemplateData() { Name = "expansion1::geysers/molten_niobium", Max = 2, Min = 1 },
            },

            Name = "AsteroidBeltLittleMagma",

            ChineseName = "熔岩",

            Description = "这里的地质非常不稳定"
        };

        public static CommonWorld AsteroidBeltLittleHotMarsh = new CommonWorld()
        {
            Height = 100,
            Width = 90,

            Biomes =  GetSingle(Biomes.LittleHotMarshBiome, BiomeLocation.Middle, BehaviorPattern.Punctate),

            Templates = new List<TemplateData> {
                new TemplateData() { Name = "geysers/molten_gold", Max = 3, Min = 1 },
                new TemplateData() { Name = "expansion1::poi/sap_tree_room", Max = 3, Min = 1 },
            },

            Name = "AsteroidBeltLittleHotMarsh",

            ChineseName = "泥潭",

            Description = "饥饿的泥潭，准备好喂饱它了吗？"
        };
    }
}
