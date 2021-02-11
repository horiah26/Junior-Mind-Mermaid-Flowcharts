using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class GridEmptySpotsFiller
    {
        Grid grid;

        public GridEmptySpotsFiller(Grid grid)
        {
            this.grid = grid;
        }

        public void FillEmptySpots()
        {
            var elementsActualizer = new GridElementActualizer(grid);
            for (int column = grid.lastOccupiedColumn - 2; column >= 0; column--)
            {
                for (int row = 0; row < grid.rowSize; row++)
                {
                    if (grid.elementGrid[row, column] != null && grid.elementGrid[row, column + 1] == null && grid.elementGrid[row, column].MinColumnOfChildren() - 1 > column)
                    {
                        grid.elementGrid[row, column].MinColumnOfChildren();
                        grid.elementGrid[row, column + 1] = grid.elementGrid[row, column];

                        grid.elementGrid[row, column] = null;
                        elementsActualizer.Actualize();
                    }
                }
            }

            elementsActualizer.Actualize();
        }
    }
}
