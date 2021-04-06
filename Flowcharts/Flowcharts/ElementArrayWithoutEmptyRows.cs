namespace Flowcharts
{
    class ElementArrayWithoutEmptyRows
    {
        readonly Element[,] ElementArray;
        readonly int Rows;
        readonly int Columns;
        readonly int deletedRows;

        public ElementArrayWithoutEmptyRows(Element[,] ElementArray, int deletedRows, int Rows, int Columns)
        {
            this.ElementArray = ElementArray;
            this.deletedRows = deletedRows;
            this.Rows = Rows;
            this.Columns = Columns;
        }

        public Element[,] GetArray()
        {
            var newArray = new Element[Rows - deletedRows, Columns];

            for (int i = 0; i < Rows - deletedRows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    newArray[i, j] = ElementArray[i, j];
                }
            }

            return newArray;
        }
    }
}