using System.Collections.Generic;

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

        public static List<IArrow> PairArrows(IArrowRegister arrowRegister, IGrid grid)
        {
            return new PairedArrows(arrowRegister, grid).ArrowList;
        }

        public static int GetIndexOfLastColumn(Element[,] ElementArray)
        {
            return new LastColumn(ElementArray).Index;
        }
        public static IEnumerable<Element> GetLastColumn(Element[,] ElementArray)
        {
            return new LastColumn(ElementArray).Column;
        }

        public static IEnumerable<Element> ExtractColumn(Element[,] ElementArray, int index)
        {
            return new ExtractedColumn(ElementArray, index).GetColumn();
        }

        public static Element[,] EliminateEmptyRows(Element[,] ElementArray, int deletedRows)
        {
            return new ElementArrayWithoutEmptyRows(ElementArray, deletedRows).GetArray();
        }

        public static Element[,] CreateArray(int rows, int columns)
        {
            return new Element[rows, columns];
        }

        public static Element[,] Resize(Element[,] ElementArray, int rows, int columns)
        {
            return new ResizedElementArray(ElementArray, rows, columns).GetArray();
        }
    }
}
