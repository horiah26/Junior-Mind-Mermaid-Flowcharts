using System.Collections.Generic;

namespace Flowcharts
{
    public class Grid : IGrid
    {
        public Element[,] ElementArray { get; private set; }

        public Grid(int Rows = 1, int Columns = 1)
        {
            ElementArray = ArrayOperations.CreateArray(Rows, Columns);
        }

        public Grid(Element[,] elementArray)
        {
            ElementArray = elementArray;
        }

        public void Add(Element element, int row, int column)
        {
            ElementArray = ArrayOperations.AddElement(ElementArray, element, row, column);                
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