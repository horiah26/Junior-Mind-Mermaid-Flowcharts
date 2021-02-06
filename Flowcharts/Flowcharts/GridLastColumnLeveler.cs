using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    class GridLastColumnLeveler
    {
        Grid grid;
        int rowSize;
        Element[,] elementGrid;
        public GridLastColumnLeveler(Grid grid)
        {
            this.grid = grid;
            rowSize = grid.rowSize;
            elementGrid = grid.elementGrid;
        }

        public void Level()
        {
            int lastOccupiedColumn = grid.lastOccupiedColumn;
            var lastColumn = new GridColumnExtractor(grid).Extract(lastOccupiedColumn).Where(x => x != null);

            var averageParents = lastColumn.Average(x => GetAverageRowOfParents(x));
            var averageThis = lastColumn.Average(x => x.Row);

            for (int i = (int)Math.Floor(averageParents); i < rowSize; i++)
            {
                if (elementGrid[i, lastOccupiedColumn] != null)
                {
                    int difference = (int)averageParents - i;
                    if (difference > 0)
                    {
                        new GridColumnLowerer(grid).LowerColumnInGrid(i, lastOccupiedColumn, difference);
                    }
                }
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
    }
}
