using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class GridEmptySpotsFiller
    {
        Grid grid;
        int rowSize;
        Element[,] elementGrid;
        int lastOccupiedColumn;

        public GridEmptySpotsFiller(Grid grid)
        {
            this.grid = grid;
            rowSize = grid.rowSize;
            elementGrid = grid.elementGrid;
            lastOccupiedColumn = grid.lastOccupiedColumn;
        }

        public void FillEmptySpots()
        {
            var elementsActualizer = new GridElementActualizer(grid);
            for (int column = lastOccupiedColumn - 2; column >= 0; column--)
            {
                for (int row = 0; row < rowSize; row++)
                {
                    if (elementGrid[row, column] != null && elementGrid[row, column + 1] == null && elementGrid[row, column].MinColumnOfChildren() - 1 > column)
                    {
                        elementGrid[row, column].MinColumnOfChildren();
                        elementGrid[row, column + 1] = elementGrid[row, column];

                        elementGrid[row, column] = null;
                        elementsActualizer.Actualize();
                    }
                }
            }

            elementsActualizer.Actualize();
        }
    }
}
