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
                return elementArray.GetLength(1);
            }
        }

        public Element[,] elementArray;

        public Grid(int Rows = 1, int Columns = 1)
        {
            elementArray = new Element[Rows, Columns];
        }

        public Grid(Grid grid)
        {
            elementArray = new ResizedElementArray(grid.elementArray, grid.elementArray.GetLength(0), grid.elementArray.GetLength(1)).GetArray();
        }

        public void Add(Element element, int row, int column)
        {
            elementArray = new ArrayWithAddedElement(elementArray, element, row, column).GetArray();
        }

        public (int, int) GetSize()
        {
            return (elementArray.GetLength(0), elementArray.GetLength(1));
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