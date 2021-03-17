using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    class GridWithLoweredColumn
    {
        Grid grid;
        double row;
        int column;
        int positions;

        public GridWithLoweredColumn(Grid grid, double row, int column, int positions)
        {
            this.grid = grid;
            this.row = row;
            this.column = column;
            this.positions = positions;
        }

        private void LowerColumnInGrid()
        {
            if (positions == 0)
            {
                return;
            }

            IEnumerable<Element> extractedColumn = new ExtractedColumn(grid, column).GetColumn();

            int emptyPositionsAtTheEnd = extractedColumn.Reverse().TakeWhile(x => x == null).Count();

            int difference = positions - emptyPositionsAtTheEnd;

            if (difference > 0)
            {
                grid.elementArray = new ResizedElementArray(grid.elementArray, grid.rowSize + difference, grid.columnSize).Get();
            }

            for (int i = grid.rowSize - 1; i >= row; i--)
            {
                if (grid.elementArray[i, column] != null)
                {
                    if (grid.elementArray[i + positions, column] != null)
                    {
                        throw new InvalidOperationException("Cannot move. Space is not empty");
                    }

                    grid.elementArray[i + positions, column] = grid.elementArray[i, column];
                    grid.elementArray[i, column] = null;
                }
            }
        }

        public Grid GetNewGrid()
        {
            LowerColumnInGrid();
            return grid;
        }

    }
}