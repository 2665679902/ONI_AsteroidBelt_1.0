﻿using ONI_AsteroidBelt_1.WorldCreator.WorldData.World.WorldProfile;
using PLog;
using System.Collections.Generic;
using System.Linq;
using static ONI_AsteroidBelt_1.WorldCreator.Creator;

namespace ONI_AsteroidBelt_1.WorldCreator.CreatorActions
{
    internal class TempelateMananger
    {
        public static void AddTempelates(List<KeyValuePair<Vector2I, TemplateContainer>> templateSpawnTargets,  CommonWorld world)
        {
            HashSet<Vector2I> DrawTempelateRange(TemplateContainer tempelate, Vector2I center)
            {
                var res = new HashSet<Vector2I>();

                foreach (var cell in tempelate.cells)
                {
                    res.Add(new Vector2I(cell.location_x, cell.location_y) + center);
                }

                return res;

            }

            HashSet<Vector2I> avaccessible = new HashSet<Vector2I>();

            for (int i = 1; i < world.Width - 1; i++)
                for (int j = 1; j < world.Height; j++)
                    avaccessible.Add(new Vector2I(i, j));

            if (world is StartWorld startWorld)
            {
                avaccessible.ExceptWith(DrawTempelateRange(startWorld.GetStartingTemplate(), startWorld.Center));
            }

            foreach (var templateDatas in world.Templates)
            {
                var template = templateDatas.GetTemplate();


                while (true)
                {
                    if (!avaccessible.Any())
                        return;
                    var loc = avaccessible.ToArray()[CreatorRandom.Next(avaccessible.Count)];
                    var range = DrawTempelateRange(template, loc);
                    foreach (var vector in range)
                    {
                        if (!avaccessible.Contains(vector))
                        {
                            avaccessible.Remove(loc);
                            break;
                        }
                    }

                    if (avaccessible.Contains(loc))
                    {
                        avaccessible.ExceptWith(range);
                        templateSpawnTargets.Add(new KeyValuePair<Vector2I, TemplateContainer>(loc, template));
                        break;
                    }

                }
            }
        }
    }
}
