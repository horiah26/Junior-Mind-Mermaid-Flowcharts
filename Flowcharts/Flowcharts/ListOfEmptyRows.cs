using System.Collections.Generic;

namespace Flowcharts
{
    class ListOfEmptyRows
    {
        readonly Element[,] elementArray;

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

            return emptyRows;
        }

    }
}