namespace Flowcharts
{
    class GridWithTrimmedEnds : IGrid
    {
        public Element[,] ElementArray { get; private set; }

        public GridWithTrimmedEnds(IGrid grid)
        {
            ElementArray = ArrayOperations.CloneArray(grid);
            RemoveNullColumnsAndRowsAtTheEnds();
        }

        public void RemoveNullColumnsAndRowsAtTheEnds()
        {
            var emptyRows = ArrayOperations.GetEmptyRows(ElementArray);

            ElementArray = ArrayOperations.RaiseAllRows(ElementArray, emptyRows);
            ElementArray = new ElementArrayWithoutEmptyRows(ElementArray, emptyRows.Count, ElementArray.GetLength(0), ElementArray.GetLength(1)).GetArray();                      
        }
    }
}