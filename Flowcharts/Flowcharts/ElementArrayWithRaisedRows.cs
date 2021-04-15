using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    class ElementArrayWithRaisedRows
    {
        readonly Element[,] ElementArray;
        readonly List<int> emptyRows;
        readonly int Rows;
        readonly int Columns;

        public ElementArrayWithRaisedRows(Element[,] ElementArray, List<int> emptyRows)
        {
            this.ElementArray = ElementArray;
            this.emptyRows = emptyRows;
            emptyRows.Reverse();
            Rows = ElementArray.GetLength(0);
            Columns = ElementArray.GetLength(1);
        }

        public Element[,] RaiseRows()
        {
            foreach(var emptyRow in emptyRows)
            {
                if(emptyRow < GetFirstOccupiedRow())
                {
                    for (int i = emptyRow; i < Rows - 1; i++)
                    {
                        for (int j = 0; j < Columns; j++)
                        {
                            ElementArray[i, j] = ElementArray[i + 1, j];
                            ElementArray[i + 1, j] = null;
                            ArrayOperations.Update(ElementArray);
                        }
                    }
                }
            }

            return ArrayOperations.Update(ElementArray);
        }

        public int GetFirstOccupiedRow()
        {
            int rows = ElementArray.GetLength(0);
            int columns = ElementArray.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                List<Element> elementsInRow = new List<Element>() { };

                for (int column = 0; column < columns; column++)
                {
                    elementsInRow.Add(ElementArray[row, column]);
                }

                if (elementsInRow.Any(x => x != null)) 
                {
                    return row;
                }
            }

            return 0;
        }
    }
}