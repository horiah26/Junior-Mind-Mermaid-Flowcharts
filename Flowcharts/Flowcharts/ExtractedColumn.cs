using System.Collections.Generic;

namespace Flowcharts
{
    public class ExtractedColumn
    {
        readonly int column;
        readonly int Rows;
        Element[,] elementArray;
        List<Element> extractedColumn;

        //public ExtractedColumn(IGrid grid, int column)
        //{
        //    this.column = column;
        //    elementArray = grid.ElementArray;
        //    Rows = elementArray.GetLength(0);
        //}

        public ExtractedColumn(Element[,] elementArray, int column)
        {
            this.column = column;
            this.elementArray = elementArray;
            Rows = elementArray.GetLength(0);
        }

        public IEnumerable<Element> GetColumn()
        {
            extractedColumn = new List<Element> { };

            for(int i = 0; i < Rows; i++)
            {
                extractedColumn.Add(elementArray[i, column]);
            }

            return extractedColumn;
        }
    }
}