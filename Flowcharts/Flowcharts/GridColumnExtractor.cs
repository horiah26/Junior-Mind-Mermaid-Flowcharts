using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public class GridColumnExtractor
    {
        Grid grid;

        public GridColumnExtractor(Grid grid)
        {
            this.grid = grid;
        }

        public IEnumerable<Element> Extract(int column)
        {
            List<Element> extractedColumn = new List<Element> { };

            for(int i = 0; i < grid.rowSize - 1; i++)
            {
                extractedColumn.Add(grid.elementGrid[i, column]);
            }

            return extractedColumn;
        }
    }
}