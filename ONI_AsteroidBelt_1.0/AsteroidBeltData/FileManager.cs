using PLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONI_AsteroidBelt_1.AsteroidBeltData
{
    internal class FileManager
    {
        private static readonly List<string> movedFile = new List<string>();

        private static string fileWorldsPath;

        private static string directWorldsPath;

        private static string fileInteriorsPath;

        private static string directInteriorsPath;
        public FileManager(string modPath)
        {
            fileWorldsPath = Path.Combine(modPath, @"Sourse\worlds");
            fileWorldsPath = fileWorldsPath.Replace('/', '\\');

            fileInteriorsPath = Path.Combine(modPath, @"Sourse\interiors");
            fileInteriorsPath = fileInteriorsPath.Replace('/', '\\');

            directWorldsPath = Path.Combine(Directory.GetCurrentDirectory(), @"OxygenNotIncluded_Data\StreamingAssets\dlc\expansion1\worldgen\worlds");
            directWorldsPath = directWorldsPath.Replace('/', '\\');

            directInteriorsPath = Path.Combine(Directory.GetCurrentDirectory(), @"OxygenNotIncluded_Data\StreamingAssets\dlc\expansion1\templates\interiors");
            directInteriorsPath = directInteriorsPath.Replace('/', '\\');
        }

        public void WriteIn(string st)
        {
            Log.Debug(Path.Combine(fileInteriorsPath, "habitat_huge.yaml"));
            File.WriteAllText(Path.Combine(fileInteriorsPath, "habitat_huge.yaml"), st);
        }

        public void LoadHabitate()
        {
            CopyTo(fileInteriorsPath, directInteriorsPath);
        }

        public void LoadWorlds()
        {
            CopyTo(fileWorldsPath, directWorldsPath);
        }

        private void CopyTo(string sourse, string target)
        {
            foreach (var file in Directory.GetFiles(sourse))
            {
                string name = Path.GetFileName(file);
                if (File.Exists(Path.Combine(target, name)))
                    File.Delete(Path.Combine(target, name));
                File.Copy(file, Path.Combine(target, name));
                movedFile.Add(Path.Combine(target, name));
                Log.Debug("Load: " + name);
            }
        }

        public static void TakeBackFile()
        {
            foreach (var file in movedFile)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
        }
    }
}
