namespace Flowcharts
{
    public class UpdatedGrid
    {
        readonly IGrid newGrid;

        public UpdatedGrid(IGrid grid)
        {
            newGrid = new Grid(grid);
        }

        public void UpdateGrid()
        {
            for (int i = 0; i < newGrid.ElementArray.GetLength(0); i++)
            {
                for (int j = 0; j < newGrid.ElementArray.GetLength(1); j++)
                {
                    if (newGrid.ElementArray[i, j] != null)
                    {
                        newGrid.ElementArray[i, j].Row = i;
                        newGrid.ElementArray[i, j].Column = j;
                    }
                }
            }
        }

        public IGrid Get()
        {
            UpdateGrid();
            return newGrid;
        }
    }
}