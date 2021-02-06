using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    class GridColumnLowerer
    {
        Element[,] elementGrid;
        Grid grid;
        int rowSize;
        int columnSize;

        public GridColumnLowerer(Grid grid)
        {
            elementGrid = grid.elementGrid;
            this.grid = grid;
            rowSize = grid.rowSize;
            columnSize = grid.columnSize;
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
                elementGrid = new GridArrayResizer(grid).Resize(elementGrid, rowSize + difference, columnSize);
            }

            for (int i = rowSize - 1; i >= row; i--)
            {
                if (elementGrid[i, column] != null)
                {
                    if (elementGrid[i + positions, column] != null)
                    {
                        throw new InvalidOperationException("Cannot move. Space is not empty");
                    }

                    elementGrid[i + positions, column] = elementGrid[i, column];
                    elementGrid[i, column] = null;
                }
            }
        }

    }
}
