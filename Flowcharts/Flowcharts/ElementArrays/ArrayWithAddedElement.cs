using System;

namespace Flowcharts
{
    class ArrayWithAddedElement
    {
        Element[,] ElementArray;
        readonly Element element;
        readonly int row;
        readonly int column;
        readonly int Columns;
        readonly int Rows;

        public ArrayWithAddedElement(Element[,] ElementArray, Element element, int row, int column)
        {
            this.ElementArray = ElementArray;
            this.element = element;
            this.row = row;
            this.column = column;
            Rows = ElementArray.GetLength(0);
            Columns = ElementArray.GetLength(1);
        }

        public void Add()
        {
            if (row > Rows - 1)
            {
                ElementArray = ArrayOperations.Resize(ElementArray, row + 1, ElementArray.GetLength(1));
            }
            if (column > Columns - 1)
            {
                ElementArray = ArrayOperations.Resize(ElementArray, ElementArray.GetLength(0), column + 1);
            }

            if (ElementArray[row, column] != null)
            {
                throw new InvalidOperationException("Element occupied");
            }

            ElementArray[row, column] = element;
        }

        public Element[,] GetArray()
        {
            Add();
            return ElementArray;
        }
    }
}