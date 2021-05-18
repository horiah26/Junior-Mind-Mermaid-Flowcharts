using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    class GridWithSubsystems : IGrid
    {
        int lowestRow;
        int lowestColumn;
        int highestRow;
        int highestColumn;

        public Element[,] ElementArray { get; private set; }

        public GridWithSubsystems(IGrid grid)
        {
            ElementArray = ArrayOperations.CloneArray(grid);
            ArrangeSubsystems();
        }

        public void ArrangeSubsystems()
        {
            List<Subsystem> subsystems = IdentifySubsystems();

            foreach (var subsystem in subsystems)
            {
                MoveOtherElementsOutOfSubsystem(subsystem);
            }
        }

        private void MoveOtherElementsOutOfSubsystem(Subsystem subsystem)
        {
            bool moved = true;

            while (moved)
            {
                moved = false;
                UpdateSystemLocation(subsystem);

                double medRow = (highestRow + lowestRow) / 2.0;

                for (int column = highestColumn; column >= lowestColumn; column--)
                {
                    for (int row = highestRow; row >= lowestRow; row--)
                    {
                        UpdateSystemLocation(subsystem);
                        if (ElementArray[row, column] != null && ElementArray[row, column].Subsystem != subsystem)
                        {
                            moved = true;

                            if (row <= medRow)
                            {
                                if (lowestRow == 0)
                                {
                                    ElementArray = AddRowUp(ElementArray);
                                    ElementArray[0, column] = ElementArray[row + 1, column];
                                    ElementArray[row + 1, column] = null;
                                }
                                else
                                {
                                    if (ElementArray[lowestRow - 1, column] == null)
                                    {
                                        ElementArray[lowestRow - 1, column] = ElementArray[row, column];
                                        ElementArray[row, column] = null;
                                    }
                                    else
                                    {
                                        for(int i = 0; i <= ElementArray.GetLength(1) && i != column; i++)
                                        {
                                            ElementArray = ArrayOperations.LowerColumns(ElementArray, 0, i, 1);
                                        }

                                        ElementArray = ArrayOperations.LowerColumns(ElementArray, row, column, 1);
                                    }
                                }

                                ElementArray = ArrayOperations.Update(ElementArray);
                            }
                            else
                            {
                                if (highestRow == ElementArray.GetLength(0))
                                {
                                    ElementArray = ArrayOperations.Resize(ElementArray, highestRow + 1, ElementArray.GetLength(1));
                                    ElementArray[row + 1, column] = ElementArray[row, column];
                                    ElementArray[row, column] = null;
                                }
                                else
                                {
                                    MakeRoomForNewElement(row, column);
                                    UpdateSystemLocation(subsystem);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void MakeRoomForNewElement(int row, int column)
        {
            if(ElementArray.GetLength(0) <= highestRow + 1)
            {
                ElementArray = ArrayOperations.Resize(ElementArray, highestRow + 2, ElementArray.GetLength(1));
            }
            if (ElementArray[highestRow + 1, column] != null)
            {
                ElementArray = ArrayOperations.LowerColumns(ElementArray, highestRow + 1, column, 1);

                ElementArray[highestRow + 1, column] = ElementArray[row, column];
                ElementArray[row, column] = null;
            }
            else
            {
                ElementArray[highestRow + 1, column] = ElementArray[row, column];
                ElementArray[row, column] = null;
            }

            ArrayOperations.Update(ElementArray);
        }

        public Element[,] AddRowUp(Element[,] originalArray)
        {
            int minRows = originalArray.GetLength(0);
            int minCols =  originalArray.GetLength(1);

            Element[,] newArray = ArrayOperations.CreateArray(minRows + 1, minCols);

            for (int i = 0; i < minRows; i++)
            {
                for (int j = 0; j < minCols; j++)
                {
                    newArray[i + 1, j] = originalArray[i, j];
                }
            }

            return newArray;
        }

        public List<Subsystem> IdentifySubsystems()
        {
            List<Subsystem> subsystems = new List<Subsystem> { };

            foreach(var element in ElementArray)
            {
                if (element != null && element.Subsystem != null) 
                {
                    subsystems.Add(element.Subsystem);
                }
            }

            return subsystems.Distinct().ToList();
        }

        private void UpdateSystemLocation(Subsystem subsystem)
        {
            (int lowestRow, int lowestColumn, int highestRow, int highestColumn) = subsystem.GetSubsystemLocation(ElementArray);

            this.lowestRow = lowestRow;
            this.lowestColumn = lowestColumn;
            this.highestRow = highestRow;
            this.highestColumn = highestColumn;
        }
    }
}