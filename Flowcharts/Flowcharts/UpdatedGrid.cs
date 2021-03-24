namespace Flowcharts
{
    public class UpdatedGrid
    {
        Grid newGrid;

        public UpdatedGrid(Grid grid)
        {
            newGrid = new Grid(grid);
        }

        public void UpdateGrid()
        {
            for (int i = 0; i < newGrid.rowSize; i++)
            {
                for (int j = 0; j < newGrid.columnSize; j++)
                {
                    if (newGrid.elementArray[i, j] != null)
                    {
                        newGrid.elementArray[i, j].Row = i;
                        newGrid.elementArray[i, j].Column = j;
                    }
                }
            }

            (int rowSize, int columnSize) = new GridSize(newGrid).GetSize();
            newGrid.rowSize = rowSize;
            newGrid.columnSize = columnSize;
        }

        public Grid Get()
        {
            UpdateGrid();
            return newGrid;
        }
    }
}