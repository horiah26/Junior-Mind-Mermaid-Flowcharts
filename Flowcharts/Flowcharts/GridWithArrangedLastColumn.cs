using System;
using System.Linq;

namespace Flowcharts
{
    class GridWithArrangedLastColumn
    {
        Grid grid;

        public GridWithArrangedLastColumn(Grid grid)
        {
            this.grid = grid;
        }

        public void Level()
        {
            int lastOccupiedColumn = grid.lastOccupiedColumn;
            var lastColumn = new GridColumnExtractor(grid).Extract(lastOccupiedColumn).Where(x => x != null);

            var averageParents = (int)lastColumn.Average(x => GetAverageRowOfParents(x));
            var averageThis = (int)lastColumn.Average(x => x.Row);

            int difference = averageParents - averageThis;

            if (difference > 0)
            {
                new GridColumnLowerer(grid).LowerColumnInGrid(0, lastOccupiedColumn, difference);
            }

            grid = new UpdatedGrid(grid).Get();
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
            return grid;
        }
    }
}
