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

        public static Element[,] LowerColumns(Element[,] ElementArray, double row, int column, int positions)
        {
            var array = new ElementArrayWithLoweredColumn(ElementArray, row, column, positions).Get();
            return Update(array);
        }

        public static IArrowRegister CreatePairedArrows(IArrowRegister arrowRegister, IGrid grid)
        {
            return new PairedArrows(arrowRegister, grid);
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

        public static Element[,] AddElement(Element[,] ElementArray, Element element, int row, int column)
        {
            return new ArrayWithAddedElement(ElementArray, element, row, column).GetArray();
        }

        public static Element[,] LevelColumns(Element[,] ElementArray)
        {
            return new ElementArrayWithLeveledColumns(ElementArray).ElementArray;
        }

        public static Element[,] LevelElementsIndividually(Element[,] ElementArray)
        {
            return new ElementArrayWithIndividualLinearizedElements(ElementArray).ElementArray;
        }

        public static Element[,] ArrangeTwinSituations(Element[,] ElementArray)
        {
            return new ElementArrayWithArrangedTwins(ElementArray).ElementArray;
        }
    }
}
