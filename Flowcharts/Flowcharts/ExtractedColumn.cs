using System.Collections.Generic;

namespace Flowcharts
{
    public class ExtractedColumn
    {
        readonly Grid grid;
        readonly int column;

        public ExtractedColumn(Grid grid, int column)
        {
            this.grid = grid;
            this.column = column;
        }

        public IEnumerable<Element> GetColumn()
        {
            List<Element> extractedColumn = new List<Element> { };

            for(int i = 0; i < grid.rowSize - 1; i++)
            {
                extractedColumn.Add(grid.elementArray[i, column]);
            }

            return extractedColumn;
        }
    }
}