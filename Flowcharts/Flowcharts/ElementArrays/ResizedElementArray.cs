﻿using System;

namespace Flowcharts
{
    class ResizedElementArray
    {
        readonly Element[,] originalArray;
        readonly Element[,] newArray;
        readonly int rows;
        readonly int columns;

        public ResizedElementArray(Element[,] ElementArray, int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            originalArray = ElementArray;
            newArray = ArrayOperations.CreateArray(rows, columns);
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

        public Element[,] GetArray()
        {
            Resize();
            return newArray;
        }
    }
}