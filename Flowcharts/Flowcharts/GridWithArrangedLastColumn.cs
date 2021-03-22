using System;
using System.Linq;

namespace Flowcharts
{
    class GridWithArrangedLastColumn
    {
        Grid grid;
        Grid updatedGrid;

        public GridWithArrangedLastColumn(Grid grid)
        {
            this.grid = grid;
        }

        public void Level()
        {
            var lastColumn = new LastColumn(grid);
            int indexOfLastColumn = lastColumn.Index;

            var averageParents = (int)lastColumn.Column.Average(x => GetAverageRowOfParents(x));
            var averageThis = (int)lastColumn.Column.Average(x => x.Row);

            int difference = averageParents - averageThis;

            if (difference > 0)
            {
                var gridWithLoweredColumn = new GridWithLoweredColumn(grid, 0, indexOfLastColumn, difference).GetNewGrid();
                updatedGrid = new UpdatedGrid(gridWithLoweredColumn).Get();
            }
            else
            {
                updatedGrid = new UpdatedGrid(grid).Get();
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
            return updatedGrid;
        }


    }
}
