namespace Flowcharts
{
    class GridWithFilledSpots
    {
        Grid grid;

        public GridWithFilledSpots(Grid grid)
        {
            this.grid = grid;
        }

        public void FillEmptySpots()
        {
            for (int column = grid.lastOccupiedColumn - 2; column >= 0; column--)
            {
                for (int row = 0; row < grid.rowSize; row++)
                {
                    if (grid.elementGrid[row, column] != null && grid.elementGrid[row, column + 1] == null && grid.elementGrid[row, column].MinColumnOfChildren() - 1 > column)
                    {
                        grid.elementGrid[row, column].MinColumnOfChildren();
                        grid.elementGrid[row, column + 1] = grid.elementGrid[row, column];

                        grid.elementGrid[row, column] = null;
                        grid = new UpdatedGrid(grid).Get();
                    }
                }
            }

            grid = new UpdatedGrid(grid).Get();
        }

        public Grid Get()
        {
            FillEmptySpots();
            return grid;
        }
    }
}
