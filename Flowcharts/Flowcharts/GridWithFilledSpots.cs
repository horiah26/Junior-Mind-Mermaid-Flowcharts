namespace Flowcharts
{
    class GridWithFilledSpots
    {
        Grid newGrid;

        public GridWithFilledSpots(Grid grid)
        {
            newGrid = new Grid(grid);
        }

        public void FillEmptySpots()
        {
            int lastColumnIndex = new LastColumn(newGrid).Index;

            for (int column = lastColumnIndex - 1; column >= 0; column--)
            {
                for (int row = 0; row < newGrid.Rows; row++)
                {
                    if (newGrid.elementArray[row, column] != null && newGrid.elementArray[row, column + 1] == null && newGrid.elementArray[row, column].MinColumnOfChildren() - 1 > column)
                    {
                        int difference = newGrid.elementArray[row, column].MinColumnOfChildren() - column - 1;

                        newGrid.elementArray[row, column + difference] = newGrid.elementArray[row, column];

                        newGrid.elementArray[row, column] = null;
                        newGrid = new UpdatedGrid(newGrid).Get();
                    }
                }
            }
        }

        public Grid Get()
        {
            FillEmptySpots();
            return new UpdatedGrid(newGrid).Get(); ;
        }
    }
}
