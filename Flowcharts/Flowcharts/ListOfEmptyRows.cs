using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ListOfEmptyRows
    {
        Element[,] elementArray;

        public ListOfEmptyRows(Element[,] elementArray)
        {
            this.elementArray = elementArray;
        }

        public List<int> GetEmptyRows()
        {
            List<int> emptyRows = new List<int>() { };

            for (int i = 0; i < elementArray.GetLength(0); i++)
            {
                List<Element> rowList = new List<Element>() { };

                for (int j = 0; j < elementArray.GetLength(1); j++)
                {
                    if (elementArray[i, j] != null)
                    {
                        rowList.Add(elementArray[i, j]);
                    }
                }

                if (rowList.Count == 0)
                {
                    emptyRows.Add(i);
                }
            }

            foreach (var v in emptyRows)
            {
                Console.WriteLine(v);
            }
            return emptyRows;
        }

    }
}