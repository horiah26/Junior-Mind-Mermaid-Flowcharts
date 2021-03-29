namespace Flowcharts
{
    internal class GridWithRaisedRows
    {
        Grid newGrid;

        public GridWithRaisedRows(Grid grid)
        {
            newGrid = new Grid(grid);
        }

        public void ArrangeRows()
        {
            int lastColumnIndex = new LastColumn(newGrid).Index;

            for (int column = 0; column <= lastColumnIndex; column--)
            {
                for (int row = 0; row < newGrid.Rows; row++)
                {
                    if (newGrid.elementArray[row, column] != null)
                    {
                        //MoveColumnInPlace(row, column);
                    }
                }

                newGrid = new UpdatedGrid(newGrid).Get();
            }

            newGrid = new UpdatedGrid(newGrid).Get();
        }
    }
}