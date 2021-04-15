using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Flowcharts
{
    class GridWithEquallyDistanceTwins : IGrid
    {
        public Element[,] ElementArray { get; private set; }

        public GridWithEquallyDistanceTwins(IGrid grid)
        {
            ElementArray = grid.ElementArray;
            HandleSituation1();
            HandleSituation2();
        }

        public void HandleSituation1()
        {          
            ArrayOperations.Update(ElementArray);

            bool moved;

            do
            {
                moved = false;
                int columns = ElementArray.GetLength(1);
                for (int i = 0; i < columns - 1; i++)
                {
                    int rows = ElementArray.GetLength(0);

                    for (int j = 0; j < rows - 1; j++)
                    {
                        if (ElementArray[j, i] != null
                            && ElementArray[j, i].childElements.Where(x=>x.Column == i + 1).Count() == 2
                            && ElementArray[j, i + 1] != null
                            && ElementArray[j + 1, i + 1] != null
                            && ElementArray[j, i].childElements[0].Key == ElementArray[j, i + 1].Key
                            && ElementArray[j, i].childElements[1].Key == ElementArray[j + 1, i + 1].Key
                            ||
                            ElementArray[j, i] != null
                            && ElementArray[j, i].childElements.Where(x => x.Column == i + 1).Count() == 2
                            && ElementArray[j, i + 1] != null
                            && ElementArray[j + 1, i + 1] != null
                            && ElementArray[j, i].childElements[0].Key == ElementArray[j, i + 1].Key
                            && ElementArray[j, i].childElements[1].Key == ElementArray[j + 1, i + 1].Key)
                        {
                            LowerPreviousColumns(i);
                            LowerColumnFromRow(i, j);
                            moved = true;
                            ArrayOperations.Update(ElementArray);
                        }           
                    }
                }
            }
            while (moved);

            do
            {
                moved = false;
                int columns = ElementArray.GetLength(1);
                for (int i = columns - 2; i >= 0; i--)
                {
                    var rows = ElementArray.GetLength(0);
                    for (int j = 1; j < rows ; j++)
                    {
                        if (ElementArray[j, i] != null
                            && ElementArray[j, i + 1] != null
                            && ElementArray[j - 1, i + 1] != null
                            && ElementArray[j, i].childElements.Where(x => x.Column == i + 1).Count() == 2
                            && ElementArray[j, i].childElements[0].Key == ElementArray[j - 1, i + 1].Key
                            && ElementArray[j, i].childElements[1].Key == ElementArray[j, i + 1].Key
                            )

                        {
                            LowerPreviousColumns(i);
                            LowerColumnFromRow(i , j - 1);
                            moved = true;                            
                        }
                    }
                }
            }
            while (moved);

            ArrayOperations.Update(ElementArray);
        }

        private void LowerColumnFromRow(int column, int row)
        {
            ElementArray = ArrayOperations.LowerColumns(ElementArray, row + 1, column + 1, 1);
        }

        public void HandleSituation2()
        {
            int rows = ElementArray.GetLength(0);
            int columns = ElementArray.GetLength(1);
            ArrayOperations.Update(ElementArray);

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows - 2; j++)
                {
                    if (ElementArray[j, i] != null
                        && ElementArray[j, i].childElements.Count == 2
                        && ElementArray[j, i + 1] != null
                        && ElementArray[j + 2, i + 1] != null
                        && ElementArray[j, i].childElements[0].Key == ElementArray[j, i + 1].Key
                        && ElementArray[j, i].childElements[1].Key == ElementArray[j + 2, i + 1].Key)
                    {
                        LowerPreviousColumns(i);
                    }
                }
            }
        }

        private void LowerPreviousColumns(int column)
        {
            for (int i = 0; i <= column; i++)
            {
                ElementArray = ArrayOperations.LowerColumns(ElementArray, 0, i, 1);
            }

            ArrayOperations.Update(ElementArray);
            UpdateChildren();
        }

        private void UpdateChildren()
        {
            foreach (var element1 in ElementArray)
            {
                if (element1 != null)
                {
                    foreach (var child in element1.childElements)
                    {
                        foreach (var element in ElementArray)
                        {
                            if (element != null && child.Key == element.Key)
                            {
                                child.Row = element.Row;
                            }
                        }
                    }
                }
            }
        }
    }
}