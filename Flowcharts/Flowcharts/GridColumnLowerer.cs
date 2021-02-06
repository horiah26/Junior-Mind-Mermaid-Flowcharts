using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    class GridColumnLowerer
    {
        Element[,] elementGrid;

        public GridColumnLowerer(Element[,] elementGrid)
        {
            this.elementGrid = elementGrid;
        }

        public void LowerColumnInGrid(double row, int column, int positions)
        {
            if (positions == 0)
            {
                return;
            }

            IEnumerable<Element> extractedColumn = GetColumn(column);

            int emptyPositionsAtTheEnd = extractedColumn.Reverse().TakeWhile(x => x == null).Count();

            int difference = positions - emptyPositionsAtTheEnd;

            if (difference > 0)
            {
                elementGrid = ResizeArray(elementGrid, rowSize + difference, columnSize);
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
