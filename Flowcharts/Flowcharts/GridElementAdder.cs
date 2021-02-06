using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class GridElementAdder
    {
        Grid grid;
        int rowSize;
        int columnSize;
        Element[,] elementGrid;

        public GridElementAdder(Grid grid)
        {
            this.grid = grid;
            rowSize = grid.rowSize;
            columnSize = grid.columnSize;
            elementGrid = grid.elementGrid;

        }

        public void Add(Element element, int row, int column)
        {
            if (column > grid.columnSize - 1)
            {
                grid.elementGrid = new GridArrayResizer(grid).Resize(elementGrid, rowSize, column + 1);
            }
            if (row > grid.rowSize - 1)
            {
                grid.elementGrid = new GridArrayResizer(grid).Resize(elementGrid, row + 1, columnSize);
            }

            if (grid.elementGrid[row, column] != null)
            {
                throw new InvalidOperationException("Element occupied");
            }

            grid.elementGrid[row, column] = element;
        }
    }
}
