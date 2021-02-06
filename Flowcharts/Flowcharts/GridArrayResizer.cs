using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class GridArrayResizer
    {
        int columnSize;
        int rowSize;
        Grid grid;

        public GridArrayResizer(Grid grid)
        {
            columnSize = grid.columnSize;
            rowSize = grid.rowSize;
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

            if (columnSize < columns)
            {
                grid.columnSize = columns;
            }
            if (rowSize < rows)
            {
                grid.rowSize = rows;
            }

            return newArray;
        }
    }
}
