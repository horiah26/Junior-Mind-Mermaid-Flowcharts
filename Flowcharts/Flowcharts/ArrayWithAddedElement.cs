using System;

namespace Flowcharts
{
    class ArrayWithAddedElement
    {
        Element[,] elementArray;
        readonly Element element;
        readonly int row;
        readonly int column;
        readonly int columnSize;
        readonly int rowSize;

        public ArrayWithAddedElement(Element[,] elementArray, Element element, int row, int column)
        {
            this.elementArray = elementArray;
            this.element = element;
            this.row = row;
            this.column = column;
            rowSize = elementArray.GetLength(0);
            columnSize = elementArray.GetLength(1);
        }

        public void Add()
        {
            if (row > rowSize - 1)
            {
               elementArray = new ResizedElementArray(elementArray, row + 1, columnSize).Get();
            }
            if (column > columnSize - 1)
            {
                elementArray = new ResizedElementArray(elementArray, rowSize, column + 1).Get();
            }

            if (elementArray[row, column] != null)
            {
                throw new InvalidOperationException("Element occupied");
            }

            elementArray[row, column] = element;
        }

        public Element[,] GetArray()
        {
            Add();
            return elementArray;
        }
    }
}