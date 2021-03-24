using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    class ElementArrayWithLoweredColumn
    {
        readonly Grid grid;
        Element[,] elementArray;
        readonly double row;
        readonly int column;
        readonly int positions;

        public ElementArrayWithLoweredColumn(Grid grid, double row, int column, int positions)
        {
            elementArray = grid.elementArray;
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

            var extractedColumn = new ExtractedColumn(grid, column).GetColumn();
            var reversedColumn = extractedColumn.Reverse();
            int emptyPositionsAtTheEnd = extractedColumn.Reverse().TakeWhile(x => x == null).Count();

            int difference = positions - emptyPositionsAtTheEnd;

            if (difference > 0)
            {
                elementArray = new ResizedElementArray(elementArray, elementArray.GetLength(0) + difference, elementArray.GetLength(1)).GetArray();
            }

            for (int i = elementArray.GetLength(0) - 1; i >= row; i--)
            {
                if (elementArray[i, column] != null)
                {
                    if (elementArray[i + positions, column] != null)
                    {
                        throw new InvalidOperationException("Cannot move. Space is not empty");
                    }

                    elementArray[i + positions, column] = elementArray[i, column];
                    elementArray[i, column] = null;
                }
            }
        }

        public Element[,] GetNewGrid()
        {
            LowerColumnInGrid();
            return elementArray;
        }

    }
}