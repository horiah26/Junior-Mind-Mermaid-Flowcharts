using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    class GridColumnLowerer
    {
        Grid grid;

        public GridColumnLowerer(Grid grid)
        {
            this.grid = grid;
        }

        public void LowerColumnInGrid(double row, int column, int positions)
        {
            if (positions == 0)
            {
                return;
            }

            IEnumerable<Element> extractedColumn = new GridColumnExtractor(grid).Extract(column);

            int emptyPositionsAtTheEnd = extractedColumn.Reverse().TakeWhile(x => x == null).Count();

            int difference = positions - emptyPositionsAtTheEnd;

            if (difference > 0)
            {
                grid.elementGrid = new GridArrayResizer(grid).Resize(grid.elementGrid, grid.rowSize + difference, grid.columnSize);
            }

            for (int i = grid.rowSize - 1; i >= row; i--)
            {
                if (grid.elementGrid[i, column] != null)
                {
                    if (grid.elementGrid[i + positions, column] != null)
                    {
                        throw new InvalidOperationException("Cannot move. Space is not empty");
                    }

                    grid.elementGrid[i + positions, column] = grid.elementGrid[i, column];
                    grid.elementGrid[i, column] = null;
                }
            }
        }

    }
}
