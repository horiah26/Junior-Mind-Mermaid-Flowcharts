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
                    if (grid.elementArray[i, j] != null)
                    {
                        grid.elementArray[i, j].Row = i;
                        grid.elementArray[i, j].Column = j;

                        grid.elementArray[i, j].columnSize = grid.columnSize;
                        grid.elementArray[i, j].rowSize = grid.rowSize;
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
