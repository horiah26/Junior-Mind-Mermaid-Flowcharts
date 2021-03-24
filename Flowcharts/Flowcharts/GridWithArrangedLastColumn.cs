using System;
using System.Linq;

namespace Flowcharts
{
    class GridWithArrangedLastColumn
    {
        Grid newGrid;

        public GridWithArrangedLastColumn(Grid grid)
        {
            newGrid = new Grid(grid);
        }

        public void Level()
        {
            var lastColumn = new LastColumn(newGrid);
             
            int indexOfLastColumn = lastColumn.Index;

            var averageParents = (double)lastColumn.Column.Average(x => GetAverageRowOfParents(x));
            var averageThis = (double)lastColumn.Column.Average(x => x.Row);

            var difference = Convert.ToInt32(averageParents - averageThis); 

            if (difference > 0)
            {
                newGrid.elementArray = new ElementArrayWithLoweredColumn(newGrid, 0, indexOfLastColumn, difference).GetNewGrid();
            }

            newGrid = new UpdatedGrid(newGrid).Get();
        }

        private double GetAverageRowOfParents(Element element)
        {
            if (element.parentElements.Count != 0)
            {
                return element.parentElements.Average(x => x.Row);
            }

            return element.Row;
        }

        public Grid Get()
        {
            Level();
            return newGrid;
        }
    }
}