using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class StraightGrid : IGrid
    {
        public Element[,] ElementArray { get; set; }

        public StraightGrid(IGrid grid)
        {
            ElementArray = grid.ElementArray;
            Straigthen();
        }

        private void Straigthen()
        {
            int rows = ElementArray.GetLength(0);
            int columns = ElementArray.GetLength(1);

            for(int i = columns - 1; i>= 0; i--)
            {
                for(int j = 0; j < rows; j++)
                {
                    
                }
            }
        }
    }
}
