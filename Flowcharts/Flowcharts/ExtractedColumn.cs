using System.Collections.Generic;

namespace Flowcharts
{
    public class ExtractedColumn
    {
        readonly Grid grid;
        readonly int column;
        List<Element> extractedColumn;

        public ExtractedColumn(Grid grid, int column)
        {
            this.grid = grid;
            this.column = column;
        }

        public IEnumerable<Element> GetColumn()
        {
            extractedColumn = new List<Element> { };

            for(int i = 0; i < grid.Rows - 1; i++)
            {
                extractedColumn.Add(grid.elementArray[i, column]);
            }

            return extractedColumn;
        }
    }
}