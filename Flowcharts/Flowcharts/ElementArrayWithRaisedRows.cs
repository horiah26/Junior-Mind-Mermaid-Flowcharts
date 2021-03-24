using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ElementArrayWithRaisedRows
    {
        Element[,] elementArray;
        List<int> emptyRows;
        int rowSize;
        int columnSize;

        public ElementArrayWithRaisedRows(Element[,] elementArray, List<int> emptyRows)
        {
            this.elementArray = elementArray;
            this.emptyRows = emptyRows;

            rowSize = elementArray.GetLength(0);
            columnSize = elementArray.GetLength(1);
        }

        public Element[,] RaiseRows()
        {
            foreach(var emptyRow in emptyRows)
            {
                for(int i = emptyRow; i < rowSize - 1; i++)
                {
                    for(int j = 0; j < columnSize; j++)
                    {
                        elementArray[i, j] = elementArray[i + 1, j];
                    }
                }
            }

            return elementArray;
        }
    }
}