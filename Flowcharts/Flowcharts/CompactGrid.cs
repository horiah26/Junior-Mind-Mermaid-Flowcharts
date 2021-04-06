using System.Collections.Generic;

namespace Flowcharts
{
    internal class CompactGrid : IGrid
    {
        public Element[,] ElementArray { get; private set; }

        public CompactGrid(IGrid grid)
        {
            ElementArray = ArrayOperations.CloneArray(grid);
            MakeColumnsCompact();
        }

        public void MakeColumnsCompact()
        {
            int lastColumnIndex = new LastColumn(ElementArray).Index;

            for (int i = 0; i <= lastColumnIndex; i++)
            {
                CompactColumn(i);
            }
        }

        private void CompactColumn(int i)
        {
            bool moved;
            do
            {
                moved = false;
                int Rows = ElementArray.GetLength(0);

                for (int j = 1; j < Rows; j++)
                {
                    if (ElementArray[j, i] != null && ElementArray[j - 1, i] == null)
                    {
                        ElementArray[j - 1, i] = ElementArray[j, i];
                        ElementArray[j, i] = null;
                        moved = true;
                    }
                }

                ArrayOperations.Update(ElementArray);

            } while (moved == true);
        }
    }
}