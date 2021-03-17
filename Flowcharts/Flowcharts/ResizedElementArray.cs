using System;

namespace Flowcharts
{
    class ResizedElementArray
    {
        Element[,] originalArray;
        Element[,] newArray;
        int rows;
        int columns;

        public ResizedElementArray(Element[,] elementArray, int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            originalArray = elementArray;
            newArray = new Element[rows, columns];
        }

        private void Resize()
        {
            int minRows = Math.Min(rows, originalArray.GetLength(0));
            int minCols = Math.Min(columns, originalArray.GetLength(1));

            for (int i = 0; i < minRows; i++)
            {
                for (int j = 0; j < minCols; j++)
                {
                    newArray[i, j] = originalArray[i, j];
                }
            }
        }

        public Element[,] Get()
        {
            Resize();
            return newArray;
        }
    }
}