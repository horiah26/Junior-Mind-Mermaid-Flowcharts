using System.Collections.Generic;

namespace Flowcharts
{
    class ListOfEmptyRows
    {
        readonly Element[,] ElementArray;

        public ListOfEmptyRows(Element[,] ElementArray)
        {
            this.ElementArray = ElementArray;
        }

        public List<int> GetEmptyRows()
        {
            List<int> emptyRows = new List<int>() { };

            for (int i = 0; i < ElementArray.GetLength(0); i++)
            {
                List<Element> rowList = new List<Element>() { };

                for (int j = 0; j < ElementArray.GetLength(1); j++)
                {
                    if (ElementArray[i, j] != null)
                    {
                        rowList.Add(ElementArray[i, j]);
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