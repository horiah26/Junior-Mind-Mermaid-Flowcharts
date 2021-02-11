using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class GridElementAdder
    {
        readonly Grid grid;

        public GridElementAdder(Grid grid)
        {
            this.grid = grid;
        }

        public void Add(Element element, int row, int column)
        {
            var gridResizer = new GridArrayResizer(grid);

            if (row > grid.rowSize - 1)
            {
                grid.elementGrid = gridResizer.Resize(grid.elementGrid, row + 1, grid.columnSize);
            }
            if (column > grid.columnSize - 1)
            {
                grid.elementGrid = gridResizer.Resize(grid.elementGrid, grid.rowSize, column + 1);
            }

            if (grid.elementGrid[row, column] != null)
            {
                throw new InvalidOperationException("Element occupied");
            }

            grid.elementGrid[row, column] = element;
        }
    }
}
