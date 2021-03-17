using System.Collections.Generic;

namespace Flowcharts
{
    public class Grid
    {
        public int rowSize;
        public int columnSize;
        public int lastOccupiedColumn;

        public Element[,] elementArray;

        public Grid(int rowSize = 1, int columnSize = 1)
        {
            elementArray = new Element[rowSize, columnSize];
            this.rowSize = rowSize;
            this.columnSize = columnSize;
        }

        public void Add(Element element, int row, int column)
        {
            elementArray = new ArrayWithAddedElement(elementArray, element, row, column).GetArray();
            rowSize = elementArray.GetLength(0);
            columnSize = elementArray.GetLength(1);
        }

        public (int, int) GetGridSize()
        {
            return (rowSize, columnSize);
        }

        public Element ElementAt(int row, int column)
        {
            return elementArray[row, column];
        }

        public IEnumerator<Element> GetEnumerator()
        {
            foreach (Element element in elementArray)
            {
                if (element != null)
                {
                    yield return element;
                }
            }
        }
    }
}