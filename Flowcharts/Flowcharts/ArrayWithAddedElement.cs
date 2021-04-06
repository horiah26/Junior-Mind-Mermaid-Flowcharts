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
               ElementArray = new ResizedElementArray(ElementArray, row + 1, Columns).GetArray();
            }
            if (column > Columns - 1)
            {
                ElementArray = new ResizedElementArray(ElementArray, Rows, column + 1).GetArray();
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