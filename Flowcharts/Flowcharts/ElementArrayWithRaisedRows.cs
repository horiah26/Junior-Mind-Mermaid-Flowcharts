using System.Collections.Generic;

namespace Flowcharts
{
    class ElementArrayWithRaisedRows
    {
        readonly Element[,] ElementArray;
        readonly List<int> emptyRows;
        readonly int Rows;
        readonly int Columns;

        public ElementArrayWithRaisedRows(Element[,] ElementArray, List<int> emptyRows)
        {
            this.ElementArray = ElementArray;
            this.emptyRows = emptyRows;

            Rows = ElementArray.GetLength(0);
            Columns = ElementArray.GetLength(1);
        }

        public Element[,] RaiseRows()
        {
            foreach(var emptyRow in emptyRows)
            {
                for(int i = emptyRow; i < Rows - 1; i++)
                {
                    for(int j = 0; j < Columns; j++)
                    {
                        ElementArray[i, j] = ElementArray[i + 1, j];
                    }
                }
            }

            return ElementArray;
        }
    }
}