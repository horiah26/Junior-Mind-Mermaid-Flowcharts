using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class GridWithoutNullEnds
    {
        Grid newGrid;
        Element[,] elementArray;

        public GridWithoutNullEnds(Grid grid)
        {
            newGrid = grid;
            elementArray = grid.elementArray;
        }

        public List<int> IdentifyEmptyRows()
        {
            List<int> emptyRows = new List<int>() { };

            for (int i = 0; i < newGrid.rowSize; i++)
            {
                List<Element> rowList = new List<Element>() { };
                
                for (int j = 0; j < newGrid.columnSize; j++)
                {
                    if (elementArray[i, j] != null)
                    {
                        rowList.Add(elementArray[i, j]);
                    }
                }

                if(rowList.Count == 0)
                {
                    emptyRows.Add(i);
                }
            }

            foreach(var v in emptyRows)
            {
                Console.WriteLine(v);
            }
            return emptyRows;
        }
    }
}