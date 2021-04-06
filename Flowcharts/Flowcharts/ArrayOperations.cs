using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public static class ArrayOperations
    {
        public static Element[,] CloneArray(IGrid grid)
        {
            return new ArrayClone(grid.ElementArray).GetClone();
        }

        public static Element[,] Update(Element[,] ElementArray)
        {
            return new UpdatedArray(ElementArray).Update();
        }

        public static double GetAverageRowOfChildren(Element[,] elementArray, int row, int column)
        {
           return new AverageRowOfChildren(elementArray, row, column).Get();
        }

        public static List<int> GetEmptyRows(Element[,] ElementArray)
        {
            return new ListOfEmptyRows(ElementArray).GetEmptyRows();
        }

        public static Element[,] RaiseAllRows(Element[,] elementArray, List<int> emptyRows)
        {
            return new ElementArrayWithRaisedRows(elementArray, emptyRows).RaiseRows();
        }

        public static Element[,] LowerColumns(IGrid grid, double row, int column, int positions)
        {
            return new ElementArrayWithLoweredColumn(grid, row, column, positions).Get();
        }

        public static Element[,] LowerColumns(Element[,] ElementArray, double row, int column, int positions)
        {
            return new ElementArrayWithLoweredColumn(ElementArray, row, column, positions).Get();
        }
    }
}
