namespace Flowcharts
{
    class ElementArrayWithoutEmptyRows : IElementArray
    {
        public Element[,] ElementArray { get; private set; }
        readonly int Rows;
        readonly int Columns;
        readonly int deletedRows;

        public ElementArrayWithoutEmptyRows(Element[,] ElementArray, int deletedRows)
        {
            this.ElementArray = ArrayOperations.Update(ElementArray);
            this.deletedRows = deletedRows;
            Rows = ElementArray.GetLength(0);
            Columns = ElementArray.GetLength(1);
        }

        public Element[,] GetArray()
        {
            var newArray = ArrayOperations.CreateArray(Rows - deletedRows, Columns);

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