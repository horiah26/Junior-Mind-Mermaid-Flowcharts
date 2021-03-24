using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ElementArrayWithTrimmedRow
    {
        Grid newGrid;
        Element[,] elementArray;
        List<int> emptyRows;

        public ElementArrayWithTrimmedRow(Grid grid, List<int> emptyRows)
        {
            newGrid = grid;
        }

        public Element[,] ExtractEmptyColumns(List<int> emptyRows)
        {
            foreach(var v in emptyRows)
            {
                foreach(var element in elementArray)
                {
                    if(element.Row < v)
                    {
                        element.Row--;
                    }
                }
            }

            return elementArray;
        }
    }
}