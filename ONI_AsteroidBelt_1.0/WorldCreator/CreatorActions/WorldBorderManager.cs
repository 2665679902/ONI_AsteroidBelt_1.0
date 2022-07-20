using ONI_AsteroidBelt_1.WorldCreator.WorldData.World.WorldProfile;
using ProcGenGame;
using System.Collections.Generic;

namespace ONI_AsteroidBelt_1.WorldCreator.CreatorActions
{
    internal class WorldBorderManager
    {
        public static ISet<Vector2I> DrawWorldBorders(Sim.Cell[] cells,CommonWorld world)
        {
            ISet<Vector2I> borderCells = new HashSet<Vector2I>();

            void AddBorderCell(int x, int y, Element e)
            {
                int cell = Grid.XYToCell(x, y);
                if (Grid.IsValidCell(cell))
                {
                    borderCells.Add(new Vector2I(x, y));
                    cells[cell].SetValues(e, ElementLoader.elements);
                }
            }

            Element borderMat = WorldGen.unobtaniumElement;

            for (int i = 0; i < world.Width; i++)
            {
                AddBorderCell(i, 0, borderMat);
            }

            for (int i = 0; i < world.Height; i++)
            {
                AddBorderCell(0, i, borderMat);
            }

            for (int i = 0; i < world.Height; i++)
            {
                AddBorderCell(world.Width - 1, i, borderMat);
            }
            return borderCells;
        }
    }
}
