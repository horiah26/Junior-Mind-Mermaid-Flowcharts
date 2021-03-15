namespace Flowcharts
{
    public class UpdatedGrid
    {
        readonly Grid grid;

        public UpdatedGrid(Grid grid)
        {
            this.grid = grid;
        }

        public void UpdateGrid()
        {
            for (int i = 0; i < grid.rowSize; i++)
            {
                for (int j = 0; j < grid.columnSize; j++)
                {
                    if (grid.elementGrid[i, j] != null)
                    {
                        grid.elementGrid[i, j].Row = i;
                        grid.elementGrid[i, j].Column = j;

                        grid.elementGrid[i, j].columnSize = grid.columnSize;
                        grid.elementGrid[i, j].rowSize = grid.rowSize;
                    }
                }
            }
        }

        public Grid Get()
        {
            UpdateGrid();
            return grid;
        }
    }
}
