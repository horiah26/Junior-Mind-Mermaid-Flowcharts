namespace Flowcharts
{
    public class GridElementActualizer
    {
        readonly Grid grid;

        public GridElementActualizer(Grid grid)
        {
            this.grid = grid;
        }

        public void Actualize()
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
    }
}
