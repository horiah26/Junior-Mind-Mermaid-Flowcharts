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
            int lastOccupiedColumn = grid.lastOccupiedColumn;
            var lastColumn = new ExtractedColumn(grid, lastOccupiedColumn).GetColumn().Where(x => x != null);

            var averageParents = (int)lastColumn.Average(x => GetAverageRowOfParents(x));
            var averageThis = (int)lastColumn.Average(x => x.Row);

            int difference = averageParents - averageThis;

            if (difference > 0)
            {
                var gridWithLoweredColumn = new GridWithLoweredColumn(grid, 0, lastOccupiedColumn, difference).GetNewGrid();
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
