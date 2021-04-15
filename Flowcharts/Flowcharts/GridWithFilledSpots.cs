namespace Flowcharts
{
    class GridWithFilledSpots : IGrid
    {
        public Element[,] ElementArray { get; private set; }

        public GridWithFilledSpots(IGrid grid)
        {
            ElementArray = ArrayOperations.CloneArray(grid);
            FillEmptySpots();
        }

        public void FillEmptySpots()
        {
            int lastColumnIndex = ArrayOperations.GetIndexOfLastColumn(ElementArray);                
            int Rows = ElementArray.GetLength(0);

            for (int column = lastColumnIndex - 1; column >= 0; column--)
            {
                for (int row = 0; row < Rows; row++)
                {
                    if (ElementArray[row, column] != null && ElementArray[row, column + 1] == null && ElementOperations.MinColumnOfChildren(ElementArray[row, column]) - 1 > column && ElementArray[row, column].parentElements.Count == 0)
                    {
                        int difference = ElementOperations.MinColumnOfChildren(ElementArray[row, column]) - column - 1;

                        ElementArray[row, column + difference] = ElementArray[row, column];

                        ElementArray[row, column] = null;
                        ArrayOperations.Update(ElementArray);
                    }
                }
            }

            ArrayOperations.Update(ElementArray);
        }
    }
}
