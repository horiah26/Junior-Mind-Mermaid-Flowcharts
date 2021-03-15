using System.Collections.Generic;

namespace Flowcharts
{
    public class Grid
    {
        public int rowSize;
        public int columnSize;
        public int lastOccupiedColumn;

        public Element[,] elementGrid;

        public Grid(int rowSize = 1, int columnSize = 1)
        {
            elementGrid = new Element[rowSize, columnSize];
            this.rowSize = rowSize;
            this.columnSize = columnSize;
        }

        public void Add(Element element, int row, int column)
        {
            new GridElementAdder(this).Add(element, row, column);
        }

        public (int, int) GettextAlignments()
        {
            return (rowSize, columnSize);
        }

        public Element ElementAt(int row, int column)
        {
            return elementGrid[row, column];
        }

        public void LowerColumnInGrid(double row, int column, int positions)
        {
            new GridColumnLowerer(this).LowerColumnInGrid(row, column, positions);
        }

        public IEnumerator<Element> GetEnumerator()
        {
            foreach (Element element in elementGrid)
            {
                if (element != null)
                {
                    yield return element;
                }
            }
        }
    }
}