using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public class GridElementActualizer
    {
        int rowSize;
        int columnSize;
        Element[,] elementGrid;
        public GridElementActualizer(Grid grid)
        {
            rowSize = grid.rowSize;
            columnSize = grid.columnSize;
            elementGrid = grid.elementGrid;
        }

        public void Actualize()
        {
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < columnSize; j++)
                {
                    if (elementGrid[i, j] != null)
                    {
                        elementGrid[i, j].Row = i;
                        elementGrid[i, j].Column = j;

                        elementGrid[i, j].columnSize = columnSize;
                        elementGrid[i, j].rowSize = rowSize;
                    }
                }
            }
        }
    }
}
