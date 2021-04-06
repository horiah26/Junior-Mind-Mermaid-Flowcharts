using System.Collections.Generic;

namespace Flowcharts
{
    public class Grid : IGrid
    {
        public int Rows 
        { 
            get
            {
                return ElementArray.GetLength(0);
            } 
        }

        public int Columns
        {
            get
            {
                return ElementArray.GetLength(1);
            }
        }

        public Element[,] ElementArray { get; private set; }

        public Grid(int Rows = 1, int Columns = 1)
        {
            ElementArray = new Element[Rows, Columns];
        }

        public Grid(IGrid grid)
        {
            ElementArray = new ResizedElementArray(grid.ElementArray, grid.ElementArray.GetLength(0), grid.ElementArray.GetLength(1)).GetArray();
        }

        public Grid(Element[,] elementArray)
        {
            ElementArray = elementArray;
        }

        public void Add(Element element, int row, int column)
        {
            ElementArray = new ArrayWithAddedElement(ElementArray, element, row, column).GetArray();
        }

        public (int, int) GetSize()
        {
            return (ElementArray.GetLength(0), ElementArray.GetLength(1));
        }

        public IEnumerator<Element> GetEnumerator()
        {
            foreach (Element element in ElementArray)
            {
                if (element != null)
                {
                    yield return element;
                }
            }
        }
    }
}