using System.Collections.Generic;

namespace Flowcharts
{
    public class Grid
    {
        public int Rows 
        { 
            get
            {
                return elementArray.GetLength(0);
            } 
        }
        public int Columns
        {
            get
            {
                return elementArray.GetLength(0);
            }
        }

        public Element[,] elementArray;

        public Grid(int rowSize = 1, int columnSize = 1)
        {
            elementArray = new Element[rowSize, columnSize];
        }

        public Grid(Grid grid)
        {
            elementArray = grid.elementArray;
        }

        public void Add(Element element, int row, int column)
        {
            elementArray = new ArrayWithAddedElement(elementArray, element, row, column).GetArray();
        }

        public (int, int) GetGridSize()
        {
            return (Rows, Columns);
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