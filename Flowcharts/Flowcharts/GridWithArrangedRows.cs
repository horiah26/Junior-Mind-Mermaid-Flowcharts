using System;

namespace Flowcharts
{
    class GridWithArrangedRows : IGrid
    {
        public Element[,] ElementArray { get; private set; }

        public GridWithArrangedRows(IGrid grid)
        {
            ElementArray = ArrayOperations.CloneArray(grid);
            ArrangeRows();
        }

        public void ArrangeRows()
        {
            int lastColumnIndex = new LastColumn(ElementArray).Index;
            int Rows = ElementArray.GetLength(0);

            for (int column = lastColumnIndex; column >= 0; column--)
            {
                for (int row = 0; row < Rows; row++)
                {
                    if (ElementArray[row, column] != null)
                    {
                        MoveColumnInPlace(row, column);
                    }
                }

                ArrayOperations.Update(ElementArray);
            }

            ArrayOperations.Update(ElementArray);
        }

        private void MoveColumnInPlace(int row, int column)
        {
            double averageRowOfChildren = ArrayOperations.GetAverageRowOfChildren(ElementArray, row, column);

            int difference = (int)Math.Ceiling(averageRowOfChildren - row);

            if (difference > 0)
            {
                ElementArray = ArrayOperations.LowerColumns(ElementArray, row, column, difference);
            }
        }
    }
}