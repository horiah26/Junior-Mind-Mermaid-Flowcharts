using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ArrayClone
    {
        Element[,] originalArray;

        public ArrayClone(Element[,] ElementArray) 
        {
            originalArray = ElementArray;
        }

        public Element[,] GetClone()
        {
            int Rows = originalArray.GetLength(0);
            int Columns = originalArray.GetLength(1);

            Element[,] newArray = new Element[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if(originalArray[i,j] != null)
                    {
                        newArray[i, j] = new Element(originalArray[i, j].Key, originalArray[i, j].Text, originalArray[i, j].shapeName);
                    }
                }
            }

            return newArray;
        }
    }
}
