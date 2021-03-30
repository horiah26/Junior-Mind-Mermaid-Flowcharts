namespace Flowcharts
{
    class GridWithTrimmedEnds
    {
        readonly Grid newGrid;
        Element[,] elementArray;

        public GridWithTrimmedEnds(Grid grid)
        {
            newGrid = grid;
            elementArray = grid.elementArray;
        }
 
        public Grid GetWithoutNull()
        {
            var emptyRows = new ListOfEmptyRows(elementArray).GetEmptyRows();

            elementArray = new ElementArrayWithRaisedRows(elementArray, emptyRows).RaiseRows();
            elementArray = new ElementArrayWithoutEmptyRows(elementArray, emptyRows.Count, elementArray.GetLength(0), elementArray.GetLength(1)).GetArray();

            newGrid.elementArray = elementArray;
            
            return new UpdatedGrid(newGrid).Get();
        }
    }
}