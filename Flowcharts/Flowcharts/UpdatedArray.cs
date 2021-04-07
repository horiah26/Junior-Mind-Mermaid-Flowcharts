namespace Flowcharts
{
    class UpdatedArray
    {
        Element[,] elementArray;

        public UpdatedArray(Element[,] elementArray)
        {
            this.elementArray = elementArray;
        }

        public Element[,] Update()
        {
            for (int i = 0; i < elementArray.GetLength(0); i++)
            {
                for (int j = 0; j < elementArray.GetLength(1); j++)
                {
                    if (elementArray[i, j] != null)
                    {
                        elementArray[i, j].Row = i;
                        elementArray[i, j].Column = j;
                    }
                }
            }

            return elementArray;
        }
    }
}
