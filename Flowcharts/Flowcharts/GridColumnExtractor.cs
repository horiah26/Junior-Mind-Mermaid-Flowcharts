using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public class GridColumnExtractor
    {
        readonly Grid grid;

        public GridColumnExtractor(Grid grid)
        {
            this.grid = grid;
        }

        public IEnumerable<Element> Extract(int column)
        {
            List<Element> extractedColumn = new List<Element> { };

            for(int i = 0; i < grid.columnSize - 1; i++)
            {
                extractedColumn.Add(grid.elementGrid[i, column]);
            }

            return extractedColumn;
        }
    }
}