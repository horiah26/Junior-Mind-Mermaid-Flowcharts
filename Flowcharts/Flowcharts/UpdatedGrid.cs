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
            for (int i = 0; i < newGrid.elementArray.GetLength(0); i++)
            {
                for (int j = 0; j < newGrid.elementArray.GetLength(1); j++)
                {
                    if (newGrid.elementArray[i, j] != null)
                    {
                        newGrid.elementArray[i, j].Row = i;
                        newGrid.elementArray[i, j].Column = j;
                    }
                }
            }
        }

        public Grid Get()
        {
            UpdateGrid();
            return newGrid;
        }
    }
}