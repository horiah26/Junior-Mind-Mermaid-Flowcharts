using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ElementArrayWithoutEmptyRows
    {
        Element[,] elementArray;
        int rowSize;
        int columnSize;
        int deletedRows;

        public ElementArrayWithoutEmptyRows(Element[,] elementArray, int deletedRows, int rowSize, int columnSize)
        {
            this.elementArray = elementArray;
            this.deletedRows = deletedRows;
            this.rowSize = rowSize;
            this.columnSize = columnSize;
        }

        public Element[,] GetArray()
        {
            var newArray = new Element[rowSize - deletedRows, columnSize];

            for (int i = 0; i < rowSize - deletedRows; i++)
            {
                for (int j = 0; j < columnSize; j++)
                {
                    newArray[i, j] = elementArray[i, j];
                }
            }

            return newArray;
        }
    }
}