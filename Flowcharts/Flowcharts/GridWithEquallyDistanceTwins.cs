using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class GridWithEquallyDistanceTwins : IGrid
    {
        public Element[,] ElementArray { get; private set; }

        public GridWithEquallyDistanceTwins(IGrid grid)
        {
            ElementArray = grid.ElementArray;
            CheckIfTwins();
            CheckIfTwins2();
        }

        public Element[,] CheckIfTwins()
        {
            int rows = ElementArray.GetLength(0);
            int columns = ElementArray.GetLength(1);
            ArrayOperations.Update(ElementArray);
            for (int i = 0; i < columns - 1; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    if (ElementArray[j, i] != null
                        && ElementArray[j, i].childElements.Count == 2
                        && ElementArray[j, i + 1] != null
                        && ElementArray[j + 1, i + 1] != null
                        && ElementArray[j, i].childElements[0].Key == ElementArray[j, i + 1].Key
                        && ElementArray[j, i].childElements[1].Key == ElementArray[j + 1, i + 1].Key
                        ) 
                    {
                        RaiseUpperTwin(j, i);
                    }
                }
            }

            return ArrayOperations.Update(ElementArray);
        }

        public void CheckIfTwins2()
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
        }

        private void RaiseUpperTwin(int row, int column)
        {
            UpdateChildren();
            if (row == 0)
            {
                ElementArray = CreateArrayWithExtraRow(ElementArray);
                ElementArray[row, column + 1] = ElementArray[row + 1, column + 1];
                ElementArray[row + 1, column + 1] = null;
            }
            if(row != 0 && ElementArray[row - 1, column + 1] == null)
            {
                ElementArray[row - 1, column + 1] = ElementArray[row, column + 1];
                ElementArray[row, column + 1] = null;
            }
            else
            {
                // aici mai trebuie
            }

            ArrayOperations.Update(ElementArray);        
        }

        private Element[,] CreateArrayWithExtraRow(Element[,] elementArray)
        {
            int rows = elementArray.GetLength(0);
            int columns = elementArray.GetLength(1);
            UpdateChildren();
            Element[,] newArray = new Element[rows + 1, columns];

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    newArray[j + 1, i] = elementArray[j, i];
                }
            }

            return newArray;
        }

        private void UpdateChildren()
        {
            foreach(var element1 in ElementArray)
            {
                if(element1 != null)
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