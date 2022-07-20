using ONI_AsteroidBelt_1.WorldCreator.Common;
using PLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONI_AsteroidBelt_1.WorldCreator.WorldData.Biome.BiomeProfile
{
    internal class CommonBiome : BaseBiome
    {
        
        public CommonBiome(
            string backgroundSubworld, 
            double defaultTemperature, 
            BandData[] bands = null, 
            List<Critter> spawnablesOnFloor = null, 
            List<Critter> spawnablesOnCeil = null, 
            List<Critter> spawnablesInGround = null, 
            List<Critter> spawnablesInLiquid = null, 
            List<Critter> spawnablesInAir = null) : base(backgroundSubworld, defaultTemperature, bands, spawnablesOnFloor, spawnablesOnCeil, spawnablesInGround, spawnablesInLiquid, spawnablesInAir)
        {
        }
    }
}
