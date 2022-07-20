using ONI_AsteroidBelt_1.WorldCreator.WorldData.Biome.BiomeProfile;
using ONI_AsteroidBelt_1.WorldCreator.Common;
using System.Collections.Generic;
using static ONI_AsteroidBelt_1.WorldCreator.Common.BandData;

namespace ONI_AsteroidBelt_1.WorldCreator.WorldData.Biome
{
    internal class Biomes
    {
        public static CommonBiome LittleSandStoneBiome { get; set; } = new CommonBiome(
            "subworlds/sandstone/SandstoneStart",
            -1,
            new BandData[]
            {
                new BandData(0.2, SimHashes.Water, density: 2f),
                new BandData(0.2, SimHashes.Water, density: 2f),
                new BandData(0.2, SimHashes.Water, density: 2f),
                new BandData(0.2, SimHashes.Water, density: 2f),
                new BandData(0.2, SimHashes.Oxygen, density: 2f),
                new BandData(0.2, SimHashes.Dirt),
                new BandData(0.2, SimHashes.Algae, density: 4f,disease:DiseaseID.SLIMELUNG),
                new BandData(0.2, SimHashes.IronOre),
                new BandData(0.2, SimHashes.SandStone),
                new BandData(0.2, SimHashes.SandStone),
                new BandData(0.2, SimHashes.SandStone),
                new BandData(0.2, SimHashes.Carbon),
                new BandData(0.2, SimHashes.SandStone),
                new BandData(0.2, SimHashes.Fossil),
                new BandData(0.2, SimHashes.Granite),
                new BandData(0.2, SimHashes.Cuprite),
                new BandData(0.2, SimHashes.Dirt),
                new BandData(0.2, SimHashes.Oxygen, density: 2f),
                new BandData(0.2, SimHashes.CarbonDioxide)
            },// 水 氧气 泥土 菌泥 铁矿 砂石 二氧化碳 沉积岩 化肥 铜矿
            spawnablesOnFloor:
            new List<Critter>
            {
                new Critter("Squirrel",0.0001) ,//松鼠
                new Critter("BasicSingleHarvestPlant", 0.03) ,//米虱木
                new Critter("PrickleFlower",0.02 ),//毛刺花
                new Critter("PrickleGrass",0.06) ,//诱人荆棘
                new Critter("BasicForagePlantPlanted",0.05)//淤泥根

            },//松鼠 米虱木 诱人荆棘 毛刺花  淤泥根
            spawnablesInGround:
            new List<Critter>
            {
                new Critter("Hatch",0.0001) ,//哈奇
                new Critter("BasicForagePlant", 0.003),//淤泥根
                new Critter("BasicSingleHarvestPlantSeed",0.002),//米虱木种子
                new Critter("PrickleFlowerSeed", 0.006) ,//毛刺花种子
                new Critter("ColdBreatherSeed",0.005)//冰息萝卜

            },// 哈奇 淤泥根 米虱木种子 毛刺花种子 冰息萝卜
            spawnablesInAir:
            new List<Critter>
            {
                new Critter("LightBug",0.0005),//发光虫
            }//发光虫

            );


        public static CommonBiome LittleForestBiome { get; set; } = new CommonBiome(
            "expansion1::subworlds/forest/med_ForestStart",
            -1,
            new BandData[]
            {
                new BandData(0.2, SimHashes.Water, density: 2f),
                new BandData(0.2, SimHashes.Water, density: 2f),
                new BandData(0.2, SimHashes.Water, density: 2f),
                new BandData(0.2, SimHashes.Oxygen, density: 2f),
                new BandData(0.2, SimHashes.Dirt),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.Dirt),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.Dirt),
                new BandData(0.2, SimHashes.SandStone),
                new BandData(0.2, SimHashes.Carbon),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.AluminumOre),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.Oxygen, density: 2f),
                new BandData(0.2, SimHashes.Dirt),
                new BandData(0.2, SimHashes.Oxygen, density: 2f),
                new BandData(0.2, SimHashes.CarbonDioxide)
            },// 水 氧气 泥土 菌泥 铁矿 砂石 二氧化碳 沉积岩 化肥 铜矿
            spawnablesOnFloor:
            new List<Critter>
            {
                new Critter("ForestTree",0.0001) ,//树
                new Critter("Oxyfern", 0.025) ,//氧齿蕨
                new Critter("LeafyPlant",0.02 ),//欢乐叶
                new Critter("ForestForagePlantPlanted",0.07) ,//六角根

            },//欢乐叶 氧齿蕨 树 六角根
            spawnablesInGround:
            new List<Critter>
            {
                new Critter("OxyfernSeed",0.0001) ,//氧齿蕨
                new Critter("LeafyPlantSeed", 0.03),//欢乐叶

            },// 欢乐叶 氧齿蕨 
            spawnablesInAir:
            new List<Critter>
            {
            }

            );

        public static CommonBiome LittleOilBiome { get; set; } = new CommonBiome(
            "expansion1::subworlds/oil/OilSparse",
            340,
            new BandData[]
            {
                new BandData(0.2, SimHashes.Diamond),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.Fossil),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.CrudeOil),
                new BandData(0.2, SimHashes.SourGas),
                new BandData(0.2, SimHashes.CrudeOil),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.CrudeOil),
                new BandData(0.2, SimHashes.SourGas),
                new BandData(0.2, SimHashes.Fossil),
                new BandData(0.2, SimHashes.IronOre),
                new BandData(0.2, SimHashes.IronOre),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.CrudeOil),
                new BandData(0.2, SimHashes.Lead),
                new BandData(0.2, SimHashes.Diamond)
            },//  钻石 原油 铅 
            spawnablesOnFloor:
            new List<Critter>
            {
                new Critter("EVILFLOWER",0.0001) ,//花
                new Critter("OilFloaterDecor", 0.0001) ,//浮油生物

            },//花 浮油生物
            spawnablesInGround:
            new List<Critter>
            {
                new Critter("CactusPlantSeed",0.01) ,//雀跃掌

            },//雀跃掌
            spawnablesInAir:
            new List<Critter>
            {
            }
            );

        public static CommonBiome LittleAquaticBiome { get; set; } = new CommonBiome(
            "expansion1::subworlds/ocean/med_OceanDeep",
            -1,
            new BandData[]
            {
                new BandData(0.2, SimHashes.Water),
                new BandData(0.2, SimHashes.Graphite),
                new BandData(0.2, SimHashes.Water),
                new BandData(0.2, SimHashes.Oxygen),
                new BandData(0.2, SimHashes.Water),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.Water),
                new BandData(0.2, SimHashes.Water),
                new BandData(0.2, SimHashes.Water),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.Graphite),
                new BandData(0.2, SimHashes.CarbonDioxide)
            },// 水 石墨
            spawnablesOnFloor:
            new List<Critter>
            {
            },
            spawnablesInGround:
            new List<Critter>
            {
            },
            spawnablesInAir:
            new List<Critter>
            {
            },
            spawnablesInLiquid:
            new List<Critter>
            {
                new Critter("Pacu",0.0001) ,//帕库鱼
            }
            );


        public static CommonBiome LittleBarrenBiome { get; set; } = new CommonBiome(//地底 有精炼铁
            "subworlds/barren/BarrenGranite",
            -1,
            new BandData[]
            {
                new BandData(0.2, SimHashes.Obsidian),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.Granite),
                new BandData(0.2, SimHashes.Carbon),
                new BandData(0.2, SimHashes.Granite),
                new BandData(0.2, SimHashes.SandStone),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.Granite),
                new BandData(0.2, SimHashes.Granite),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.Iron),
                new BandData(0.2, SimHashes.Obsidian)
            },// 黑曜石 花岗岩 火成岩 碳 铁
            spawnablesOnFloor:
            new List<Critter>
            {
            },
            spawnablesInGround:
            new List<Critter>
            {
            },
            spawnablesInAir:
            new List<Critter>
            {
            },
            spawnablesInLiquid:
            new List<Critter>
            {
            }
            );


        public static CommonBiome LittleFrozenBiome { get; set; } = new CommonBiome(
            "subworlds/barren/BarrenGranite",
            42,
            new BandData[]
            {
                new BandData(0.2, SimHashes.LiquidOxygen),
                new BandData(0.2, SimHashes.Ice),
                new BandData(0.2, SimHashes.SolidCarbonDioxide),
                new BandData(0.2, SimHashes.LiquidOxygen),
                new BandData(0.2, SimHashes.BrineIce),
                new BandData(0.2, SimHashes.SedimentaryRock),
                new BandData(0.2, SimHashes.SedimentaryRock),
                new BandData(0.2, SimHashes.LiquidOxygen),
                new BandData(0.2, SimHashes.SedimentaryRock),
                new BandData(0.2, SimHashes.LiquidOxygen),
                new BandData(0.2, SimHashes.BrineIce),
                new BandData(0.2, SimHashes.SedimentaryRock)
            },// 固液态co2 冰 液氧 浓盐冰 雪 污染冰
            spawnablesOnFloor:
            new List<Critter>
            {
                new Critter("ColdWheat",0.0001) ,//冰霜麦粒 
                new Critter("ColdBreather",0.01) ,//冰萝卜

            },//冰霜麦粒 冰萝卜
            spawnablesInGround:
            new List<Critter>
            {
                new Critter("ColdBreatherSeed",0.01) ,//冰萝卜
            },
            spawnablesInAir:
            new List<Critter>
            {
            },
            spawnablesInLiquid:
            new List<Critter>
            {
            }
            );


        public static CommonBiome LittleMagmaBiome { get; set; } = new CommonBiome(//地底 有精炼铁
            "expansion1::subworlds/magma/MagmaSurface",
            1820,
            new BandData[]
            {
                new BandData(0.2, SimHashes.Magma),
                new BandData(0.2, SimHashes.Obsidian),
                new BandData(0.2, SimHashes.Magma),
                new BandData(0.2, SimHashes.Obsidian),
                new BandData(0.2, SimHashes.Magma),
                new BandData(0.2, SimHashes.Obsidian),
                new BandData(0.2, SimHashes.Magma),
                new BandData(0.2, SimHashes.Obsidian),
                new BandData(0.2, SimHashes.Magma),
                new BandData(0.2, SimHashes.Obsidian),
                new BandData(0.2, SimHashes.Magma),
                new BandData(0.2, SimHashes.Obsidian)
            },// 岩浆 黑曜石
            spawnablesOnFloor:
            new List<Critter>
            {
            },
            spawnablesInGround:
            new List<Critter>
            {
            },
            spawnablesInAir:
            new List<Critter>
            {
            },
            spawnablesInLiquid:
            new List<Critter>
            {
            }
            );


        public static CommonBiome LittleMetallicBiome { get; set; } = new CommonBiome(//
            "expansion1::subworlds/metallic/RenewableMetallic",
            -1,
            new BandData[]
            {
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.Carbon),
                new BandData(0.2, SimHashes.Cuprite),
                new BandData(0.2, SimHashes.OxyRock),
                new BandData(0.2, SimHashes.GoldAmalgam),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.AluminumOre),
                new BandData(0.2, SimHashes.GoldAmalgam),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.GoldAmalgam),
                new BandData(0.2, SimHashes.Dirt)
            },// 泥土 火成岩 金矿 铝矿 铜矿 碳 
            spawnablesOnFloor:
            new List<Critter>
            {
            },
            spawnablesInGround:
            new List<Critter>
            {
            },
            spawnablesInAir:
            new List<Critter>
            {
            },
            spawnablesInLiquid:
            new List<Critter>
            {
            }
            );


        public static CommonBiome LittleMiscBiome { get; set; } = new CommonBiome(//
            "expansion1::subworlds/moo/MooCore",
            -1,
            new BandData[]
            {
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.MaficRock),
                new BandData(0.2, SimHashes.Regolith),
                new BandData(0.2, SimHashes.MaficRock),
                new BandData(0.2, SimHashes.MaficRock),
                new BandData(0.2, SimHashes.Regolith),
                new BandData(0.2, SimHashes.MaficRock),
                new BandData(0.2, SimHashes.IronOre),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.Cuprite),
                new BandData(0.2, SimHashes.Regolith),
                new BandData(0.2, SimHashes.Rust)
            },// 泥土 火成岩 金矿 铝矿 铜矿 碳 
            spawnablesOnFloor:
            new List<Critter>
            {
            },
            spawnablesInGround:
            new List<Critter>
            {
                new Critter("MOLE",0.0002) ,//田鼠
            },// 田鼠
            spawnablesInAir:
            new List<Critter>
            {
            },
            spawnablesInLiquid:
            new List<Critter>
            {
            }
            );


        public static CommonBiome LittleNiobiumBiome { get; set; } = new CommonBiome(//
            "expansion1::subworlds/magma/MagmaSurface",
            -1,
            new BandData[]
            {
                new BandData(0.2, SimHashes.Obsidian,density:0.6),
                new BandData(0.2, SimHashes.Niobium,density:0.6),
                new BandData(0.2, SimHashes.Obsidian,density:0.6),
                new BandData(0.2, SimHashes.Niobium,density:0.6),
                new BandData(0.2, SimHashes.Obsidian,density:0.6),
                new BandData(0.2, SimHashes.Niobium,density:0.6),
                new BandData(0.2, SimHashes.Obsidian,density:0.6),
                new BandData(0.2, SimHashes.Niobium,density:0.6),
                new BandData(0.2, SimHashes.Obsidian,density:0.6),
                new BandData(0.2, SimHashes.Niobium,density:0.6),
                new BandData(0.2, SimHashes.Obsidian,density:0.6),
                new BandData(0.2, SimHashes.Niobium,density:0.6)
            },// ni 黑曜石
            spawnablesOnFloor:
            new List<Critter>
            {
            },
            spawnablesInGround:
            new List<Critter>
            {
                new Critter("MOLE",0.0002) ,//田鼠
            },// 田鼠
            spawnablesInAir:
            new List<Critter>
            {
            },
            spawnablesInLiquid:
            new List<Critter>
            {
            }
            );


        public static CommonBiome LittleRadioactiveBiome { get; set; } = new CommonBiome(//
            "expansion1::subworlds/radioactive/med_Radioactive",
            240,
            new BandData[]
            {
                new BandData(0.2, SimHashes.UraniumOre),
                new BandData(0.2, SimHashes.Ice),
                new BandData(0.2, SimHashes.Sulfur),
                new BandData(0.2, SimHashes.CarbonDioxide),
                new BandData(0.2, SimHashes.UraniumOre),
                new BandData(0.2, SimHashes.CarbonDioxide),
                new BandData(0.2, SimHashes.CarbonDioxide),
                new BandData(0.2, SimHashes.Wolframite),
                new BandData(0.2, SimHashes.Rust),
                new BandData(0.2, SimHashes.CarbonDioxide),
                new BandData(0.2, SimHashes.CarbonDioxide),
                new BandData(0.2, SimHashes.Ice)
            },// 铀矿 冰 硫 铁锈 土 漂白石 co2 黑钨矿
            spawnablesOnFloor:
            new List<Critter>
            {
                new Critter("BeeHive",0.002) ,//bee
            },
            spawnablesInGround:
            new List<Critter>
            {
                new Critter("CritterTrapPlantSeed",0.02) ,//动物捕草
            },
            spawnablesInAir:
            new List<Critter>
            {
            },
            spawnablesInLiquid:
            new List<Critter>
            {
            }
            );

        public static CommonBiome LittleSwampBiome { get; set; } = new CommonBiome(//
            "expansion1::subworlds/swamp/SwampStart",
            -1,
            new BandData[]
            {
                new BandData(0.2, SimHashes.Cobaltite),
                new BandData(0.2, SimHashes.Mud),
                new BandData(0.2, SimHashes.DirtyWater),
                new BandData(0.2, SimHashes.ToxicSand),
                new BandData(0.2, SimHashes.Cobaltite),
                new BandData(0.2, SimHashes.Mud),
                new BandData(0.2, SimHashes.CarbonDioxide),
                new BandData(0.2, SimHashes.DirtyWater),
                new BandData(0.2, SimHashes.Mud),
                new BandData(0.2, SimHashes.ToxicSand),
                new BandData(0.2, SimHashes.CarbonDioxide),
                new BandData(0.2, SimHashes.Phosphorite)
            },//污染土 钴矿 泥巴 co2 磷矿
            spawnablesOnFloor:
            new List<Critter>
            {
                new Critter("STATERPILLAR",0.0002) ,//蛞蝓
                new Critter("SwampForagePlantPlanted",0.02) ,//甜菜根
                new Critter("WineCups",0.02) ,//飞机杯
            },
            spawnablesInGround:
            new List<Critter>
            {

            },
            spawnablesInAir:
            new List<Critter>
            {
            },
            spawnablesInLiquid:
            new List<Critter>
            {
            }
            );

        public static CommonBiome LittleWastelandBiome { get; set; } = new CommonBiome(//
            "expansion1::subworlds/wasteland/WastelandWorm",
            320,
            new BandData[]
            {
                new BandData(0.2, SimHashes.SandStone),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.MaficRock),
                new BandData(0.2, SimHashes.Cuprite),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.MaficRock),
                new BandData(0.2, SimHashes.Oxygen),
                new BandData(0.2, SimHashes.MaficRock),
                new BandData(0.2, SimHashes.Oxygen),
                new BandData(0.2, SimHashes.MaficRock),
                new BandData(0.2, SimHashes.Sulfur),
                new BandData(0.2, SimHashes.Oxygen)
            },//砂石 火成岩 硫 痒 铜矿 镁铁质岩
            spawnablesOnFloor:
            new List<Critter>
            {
                new Critter("Cylindrica",0.0001) ,//蛞蝓
                new Critter("DivergentBeetle",0.0001) ,//甜菜根
                new Critter("WormPlant",0.0003) ,//飞机杯
            },//极乐刺 甲虫 虫果
            spawnablesInGround:
            new List<Critter>
            {

            },
            spawnablesInAir:
            new List<Critter>
            {
            },
            spawnablesInLiquid:
            new List<Critter>
            {
            }
            );


        public static CommonBiome LittleJungleBiome { get; set; } = new CommonBiome(//
            "subworlds/jungle/Jungle",
            320,
            new BandData[]
            {
                new BandData(0.2, SimHashes.Phosphorite),
                new BandData(0.2, SimHashes.Carbon),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.IronOre),
                new BandData(0.2, SimHashes.Algae),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.ChlorineGas),
                new BandData(0.2, SimHashes.IronOre),
                new BandData(0.2, SimHashes.Hydrogen),
                new BandData(0.2, SimHashes.ChlorineGas),
                new BandData(0.2, SimHashes.IgneousRock),
                new BandData(0.2, SimHashes.IronOre),
                new BandData(0.2, SimHashes.Phosphorite),
            },//磷矿 c 火成岩 Fe 藻类 H 氯
            spawnablesOnFloor:
            new List<Critter>
            {
                new Critter("SwampLily",0.0001) ,//芳香百合
                new Critter("Drecko",0.0003) ,//毛鳞壁虎
            },// 芳香百合 毛鳞壁虎
            
            spawnablesInAir:
            new List<Critter>
            {
            },
            spawnablesInLiquid:
            new List<Critter>
            {
            },
            spawnablesOnCeil:
            new List<Critter>
            {
                new Critter("SpiceVine",0.0001) ,//火椒藤
            }//火椒藤
            );


        public static CommonBiome LittleOceanBiome { get; set; } = new CommonBiome(//
            "subworlds/ocean/Ocean",
            310,
            new BandData[]
            {
                new BandData(0.2, SimHashes.Granite),
                new BandData(0.2, SimHashes.SedimentaryRock),
                new BandData(0.2, SimHashes.BleachStone),
                new BandData(0.2, SimHashes.Sand),
                new BandData(0.2, SimHashes.SaltWater),
                new BandData(0.2, SimHashes.SedimentaryRock),
                new BandData(0.2, SimHashes.CarbonDioxide),
                new BandData(0.2, SimHashes.SedimentaryRock),
                new BandData(0.2, SimHashes.Hydrogen),
                new BandData(0.2, SimHashes.CarbonDioxide),
                new BandData(0.2, SimHashes.Granite),
                new BandData(0.2, SimHashes.BleachStone),
                new BandData(0.2, SimHashes.Hydrogen),
            },//花岗岩 沉积岩 漂白石 沙子 盐水 H co2
            spawnablesOnFloor:
            new List<Critter>
            {
                new Critter("SeaLettuce",0.0001) ,//水草
                new Critter("Crab",0.0001) ,//沙泥蟹
                new Critter("SaltPlant",0.0003) ,//沙盐藤
            },//水草 沙泥蟹 沙盐藤
            spawnablesInGround:
            new List<Critter>
            {

            },
            spawnablesInAir:
            new List<Critter>
            {
            },
            spawnablesInLiquid:
            new List<Critter>
            {
            }
            );

        public static CommonBiome LittleRustBiome { get; set; } = new CommonBiome(//
            "subworlds/ocean/Ocean",
            210,
            new BandData[]
            {
                new BandData(0.2, SimHashes.IronOre),
                new BandData(0.2, SimHashes.MaficRock),
                new BandData(0.2, SimHashes.Rust),
                new BandData(0.2, SimHashes.CarbonDioxide),
                new BandData(0.2, SimHashes.ChlorineGas),
                new BandData(0.2, SimHashes.Rust),
                new BandData(0.2, SimHashes.ChlorineGas),
                new BandData(0.2, SimHashes.MaficRock),
                new BandData(0.2, SimHashes.Snow),
                new BandData(0.2, SimHashes.CarbonDioxide),
                new BandData(0.2, SimHashes.MaficRock),
                new BandData(0.2, SimHashes.Rust),
                new BandData(0.2, SimHashes.IronOre),
            },//fe 铁锈 镁铁质岩 氯 盐水 雪 
            spawnablesOnFloor:
            new List<Critter>
            {
                new Critter("BeanPlant",0.0001) ,//小吃芽
            },//小吃芽
            spawnablesInGround:
            new List<Critter>
            {

            },
            spawnablesInAir:
            new List<Critter>
            {
            },
            spawnablesInLiquid:
            new List<Critter>
            {
            }
            );

        public static CommonBiome LittleHotMarshBiome { get; set; } = new CommonBiome(//
            "subworlds/marsh/HotMarsh",
            310,
            new BandData[]
            {
                new BandData(0.2, SimHashes.Algae),
                new BandData(0.2, SimHashes.Clay),
                new BandData(0.2, SimHashes.SlimeMold,disease: DiseaseID.SLIMELUNG),
                new BandData(0.2, SimHashes.CarbonDioxide),
                new BandData(0.2, SimHashes.SedimentaryRock),
                new BandData(0.2, SimHashes.SedimentaryRock),
                new BandData(0.2, SimHashes.Algae),
                new BandData(0.2, SimHashes.SlimeMold),
                new BandData(0.2, SimHashes.Clay),
                new BandData(0.2, SimHashes.CarbonDioxide),
                new BandData(0.2, SimHashes.GoldAmalgam),
                new BandData(0.2, SimHashes.CarbonDioxide),
                new BandData(0.2, SimHashes.GoldAmalgam),
            },//藻类 粘菌 沉积岩 金 受污染的氧气 co2
            spawnablesOnFloor:
            new List<Critter>
            {
                new Critter("BulbPlant",0.01) ,//同伴芽
            },//同伴芽
            spawnablesInGround:
            new List<Critter>
            {
                new Critter("BulbPlantSeed",0.01) ,//同伴芽
                new Critter("BasicFabricMaterialPlantSeed",0.0001) ,//同伴芽
            },
            spawnablesInAir:
            new List<Critter>
            {
                new Critter("Puft",0.0001) ,//喷浮飞鱼

            },
            spawnablesInLiquid:
            new List<Critter>
            {
            }
            );
    }
}
