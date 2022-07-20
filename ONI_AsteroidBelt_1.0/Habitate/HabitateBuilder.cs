using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONI_AsteroidBelt_1.Habitate
{
    internal class HabitateBuilder
    {
        public static string FormateFrame(int x, int y)
        {
            StringBuilder result = new StringBuilder(
                $"name: habitat_medium\n" +
                $"info:\n" +
                $"  size:\n" +
                $"    X: {x}\n" +
                $"    Y: {y}\n" +
                $"  area: {x * y}\n" +
                $"cells:\n");

            for (int location_y = 0; location_y < y; location_y++)
            {
                for (int location_x = 0; location_x < x; location_x++)
                {
                    if (location_x == 0 || location_x == x - 1 || location_y == 0 || location_y == y - 1)
                    {
                        if (location_y == y - 1 && (x - location_x < 6 && x - location_x > 1))
                        {
                            continue;
                        }

                        if(location_y == 0)
                        {
                            result.Append(
                            $"- element: Diamond\n" +
                            $"  mass: 100\n" +
                            $"  temperature: 293.149994\n" +
                            $"  location_x: {location_x - (x / 2) + 1}\n" +
                            $"  location_y: {-location_y + (y / 2) - 1}\n");
                            continue;
                        }
                        result.Append(
                            $"- element: Steel\n" +
                            $"  mass: 100\n" +
                            $"  temperature: 293.149994\n" +
                            $"  location_x: {location_x - (x / 2) + 1}\n" +
                            $"  location_y: {-location_y + (y / 2) - 1}\n");
                    }
                    else
                    {
                        result.Append(
                            $"- element: Vacuum\n" +
                            $"  location_x: {location_x - (x / 2) + 1}\n" +
                            $"  location_y: {-location_y + (y / 2) - 1}\n");
                    }
                }
            }

            result.AppendLine("buildings:");

            Queue<string> ele = new Queue<string>();
            ele.Enqueue("RocketInteriorLiquidOutputPort");
            ele.Enqueue("RocketInteriorLiquidInputPort");
            ele.Enqueue("RocketInteriorGasOutputPort");
            ele.Enqueue("RocketInteriorGasInputPort");


            for (int location_y = 0; location_y < y; location_y++)
            {
                for (int location_x = 0; location_x < x; location_x++)
                {
                    if (location_x == 0 || location_x == x - 1 || location_y == 0 || location_y == y - 1)
                    {
                        if (location_y == y - 1 && (x - location_x < 6 && x - location_x > 1))
                        {
                            result.Append(
                            $"- id: {ele.Dequeue()}\n" +
                            $"  location_x: {location_x - (x / 2) + 1}\n" +
                            $"  location_y: {-location_y + (y / 2) - 1}\n" +
                            $"  element: Steel\n" +
                            $"  temperature: 293.149994\n");
                            continue;
                        }

                        if (location_y == 0)
                        {
                            result.Append(
                            $"- id: RocketEnvelopeWindowTile\n" +
                            $"  location_x: {location_x - (x / 2) + 1}\n" +
                            $"  location_y: {-location_y + (y / 2) - 1}\n" +
                            $"  element: Diamond\n" +
                            $"  temperature: 293.149994\n");
                            continue;
                        }

                        result.Append(
                        $"- id: RocketWallTile\n" +
                        $"  location_x: {location_x - (x / 2) + 1}\n" +
                        $"  location_y: {-location_y + (y / 2) - 1}\n" +
                        $"  element: Steel\n" +
                        $"  temperature: 293.149994\n");
                    }

                    if (location_y == y - 2 && x - location_x == 6)
                    {
                        result.Append(
                        $"- id: RocketControlStation\n" +
                        $"  location_x: {location_x - (x / 2) + 1}\n" +
                        $"  location_y: {-location_y + (y / 2) - 1}\n" +
                        $"  element: Cuprite\n" +
                        $"  temperature: 293.149994\n");
                    }
                }
            }

            result.AppendLine(
                $"otherEntities:\n" +
                $"- id: ClustercraftInteriorDoor\n" +
                $"  location_x: {-(x / 2) + 1}\n" +
                $"  location_y: {2 - y + (y / 2) - 1}\n" +
                $"  element: Unobtanium\n" +
                $"  temperature: 294.149994\n" +
                $"  units: 1\n" +
                $"  type: Other\n"
                );

            return result.ToString();
        }

        public static void AddBuildingStrings(string buildingId, string name, string description, string effect)
        {
            Strings.Add(new string[]
            {
                "STRINGS.BUILDINGS.PREFABS." + buildingId.ToUpperInvariant() + ".NAME",
                UI.FormatAsLink(name, buildingId)
            });
            Strings.Add(new string[]
            {
                "STRINGS.BUILDINGS.PREFABS." + buildingId.ToUpperInvariant() + ".DESC",
                description
            });
            Strings.Add(new string[]
            {
                "STRINGS.BUILDINGS.PREFABS." + buildingId.ToUpperInvariant() + ".EFFECT",
                effect
            });
        }

        public static void AddRocketModuleToBuildList(string moduleId, string placebehind = "")
        {
            if (!SelectModuleSideScreen.moduleButtonSortOrder.Contains(moduleId))
            {
                int num = -1;
                if (placebehind != "")
                {
                    num = SelectModuleSideScreen.moduleButtonSortOrder.IndexOf(placebehind);
                }
                int index = (num == -1) ? SelectModuleSideScreen.moduleButtonSortOrder.Count : (num + 1);
                SelectModuleSideScreen.moduleButtonSortOrder.Insert(index, moduleId);
            }
        }
    }
}
