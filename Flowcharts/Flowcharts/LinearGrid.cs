using System.Linq;

namespace Flowcharts
{
    internal class LinearGrid
    {
        private Grid newGrid;

        public LinearGrid(Grid grid)
        {
            newGrid = new Grid(grid);
        }

        public void Linearize()
        {
            for(int i = 0; i < newGrid.Columns; i++)
            {
                for(int j = 0; j < newGrid.Rows; j++)
                {
                    if (newGrid.elementArray[j,i] != null && newGrid.elementArray[j, i].parentElements.Count == 1 && newGrid.elementArray[j, i].parentElements.First().childElements.Count == 1)
                    {
                        var element = newGrid.elementArray[j, i];
                        var newRow = element.parentElements.First().Row;
                        newGrid.elementArray[newRow, i] = newGrid.elementArray[j, i];                       
                    }
                    newGrid = new UpdatedGrid(newGrid).Get();
                }              
            }
        }

        internal Grid Get()
        {
            Linearize();
            return new UpdatedGrid(newGrid).Get();
        }
    }
}