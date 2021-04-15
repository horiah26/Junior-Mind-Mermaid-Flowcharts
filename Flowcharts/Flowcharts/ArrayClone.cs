namespace Flowcharts
{
    class ArrayClone
    {
        readonly Element[,] originalArray;

        public ArrayClone(Element[,] ElementArray) 
        {
            originalArray = ElementArray;
        }

        public Element[,] GetClone()
        {
            int Rows = originalArray.GetLength(0);
            int Columns = originalArray.GetLength(1);

            Element[,] newArray = ArrayOperations.CreateArray(Rows, Columns);
                
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if(originalArray[i,j] != null)
                    {
                        newArray[i, j] = Factory.Element(originalArray[i, j]);
                    }
                }
            }

            return newArray;
        }
    }
}
