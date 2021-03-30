namespace Flowcharts
{
    internal class CompactGrid
    {
        Grid newGrid;

        public CompactGrid(Grid grid)
        {
            newGrid = new Grid(grid);
        }

        public void MakeColumnsCompact()
        {
            int lastColumnIndex = new LastColumn(newGrid).Index;

            for (int i = 0; i <= lastColumnIndex; i++)
            {
                CompactColumn(i);
            }
        }

        private void CompactColumn(int i)
        {
            bool moved;
            do
            {
                moved = false;

                for (int j = 1; j < newGrid.Rows; j++)
                {
                    if (newGrid.elementArray[j, i] != null && newGrid.elementArray[j - 1, i] == null)
                    {
                        newGrid.elementArray[j - 1, i] = newGrid.elementArray[j, i];
                        newGrid.elementArray[j, i] = null;
                        moved = true;
                    }
                }

                newGrid = new UpdatedGrid(newGrid).Get();

            } while (moved == true);
        }

        internal Grid Get()
        {
            MakeColumnsCompact();
            return newGrid; 
        }
    }
}