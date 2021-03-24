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

            var averageParents = (int)lastColumn.Column.Average(x => GetAverageRowOfParents(x));
            var averageThis = (int)lastColumn.Column.Average(x => x.Row);

            int difference = averageParents - averageThis;

            if (difference > 0)
            {
                var newGridWithLoweredColumn = new GridWithLoweredColumn(newGrid, 0, indexOfLastColumn, difference).GetNewGrid();
                newGrid = new UpdatedGrid(newGridWithLoweredColumn).Get();
            }
            else
            {
                newGrid = new UpdatedGrid(newGrid).Get();
            }
        }

        private double GetAverageRowOfParents(Element element)
        {
            if (element.parentElements.Count != 0)
            {
                return (int)Math.Round(element.parentElements.Average(x => x.Row));
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