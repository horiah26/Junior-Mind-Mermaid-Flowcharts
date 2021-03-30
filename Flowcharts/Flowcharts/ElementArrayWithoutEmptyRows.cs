namespace Flowcharts
{
    class ElementArrayWithoutEmptyRows
    {
        readonly Element[,] elementArray;
        readonly int rowSize;
        readonly int columnSize;
        readonly int deletedRows;

        public ElementArrayWithoutEmptyRows(Element[,] elementArray, int deletedRows, int rowSize, int columnSize)
        {
            this.elementArray = elementArray;
            this.deletedRows = deletedRows;
            this.rowSize = rowSize;
            this.columnSize = columnSize;
        }

        public Element[,] GetArray()
        {
            var newArray = new Element[rowSize - deletedRows, columnSize];

            for (int i = 0; i < rowSize - deletedRows; i++)
            {
                for (int j = 0; j < columnSize; j++)
                {
                    newArray[i, j] = elementArray[i, j];
                }
            }

            return newArray;
        }
    }
}