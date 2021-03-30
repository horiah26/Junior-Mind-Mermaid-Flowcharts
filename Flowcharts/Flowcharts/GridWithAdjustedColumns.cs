using System;
using System.Linq;

namespace Flowcharts
{
    internal class GridWithAdjustedColumns
    {
        private Grid newGrid;

        public GridWithAdjustedColumns(Grid grid)
        {
            newGrid = grid;
        }

        private void BringElementsDown()
        {
            for (int i = 0; i < newGrid.Columns; i++)
            {
                var column = new ExtractedColumn(newGrid, i).GetColumn();
                int averageRow = Convert.ToInt32(Math.Ceiling(column.Average(x => x.Row)));
                //fac un program care sa ridice in sus sau sa coboare coloanele astfel incat sa se potriveasca. Pot sa abstractizez si sa fac un while nu se misca nimic
                //if(averageRow)
            }
        }

        internal Grid Get()
        {
            BringElementsDown();
            return newGrid;
        }
    }
}