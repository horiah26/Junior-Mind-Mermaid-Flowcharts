using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class GridArrayResizer
    {
        readonly Grid grid;

        public GridArrayResizer(Grid grid)
        {
            this.grid = grid;
        }

        public Element[,] Resize<Element>(Element[,] original, int rows, int columns)
        {
            var newArray = new Element[rows, columns];
            int minRows = Math.Min(rows, original.GetLength(0));
            int minCols = Math.Min(columns, original.GetLength(1));
            for (int i = 0; i < minRows; i++)
            {
                for (int j = 0; j < minCols; j++)
                {
                    newArray[i, j] = original[i, j];
                }
            }

            if (grid.columnSize < columns)
            {
                grid.columnSize = columns;
            }
            if (grid.rowSize < rows)
            {
                grid.rowSize = rows;
            }

            return newArray;
        }
    }
}
