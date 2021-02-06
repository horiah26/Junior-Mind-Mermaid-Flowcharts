using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public class GridColumnExtractor
    {
        Element[,] elementGrid;
        int rowSize;

        public GridColumnExtractor(Element[,] elementGrid, int rowSize)
        {
            this.elementGrid = elementGrid;
            this.rowSize = rowSize;
        }

        public IEnumerable<Element> Extract(int column)
        {
            List<Element> extractedColumn = new List<Element> { };


            while()
            for (int i = 0; i < rowSize; i++)
            {
                extractedColumn.Add(elementGrid[i, column]);
            }

            return extractedColumn;
        }
    }
}
