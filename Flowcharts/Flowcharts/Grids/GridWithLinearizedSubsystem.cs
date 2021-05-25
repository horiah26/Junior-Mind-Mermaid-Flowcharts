using System;
using System.Linq;

namespace Flowcharts
{
    class GridWithLinearizedSubsystem : IGrid
    {
        public Element[,] ElementArray { get; private set; }

        public GridWithLinearizedSubsystem(IGrid grid)
        {
            ElementArray = ArrayOperations.CloneArray(grid);
            LinearizeIndividualElements();
            LinearizeWithinSystem();
            LinearizeIndividualElementsIfOutOfSystem();
        }

        private void LinearizeWithinSystem()
        {
            var rows = ElementArray.GetLength(0);
            var columns = ElementArray.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    bool moved = true;
                    if (ElementArray[i, j] != null)
                    {
                        var txt = ElementArray[i, j].Text;
                    }

                    while (ElementArray[i, j] != null
                        && ElementArray[i, j].parentElements.Count() == 1
                        && ElementArray[i, j].parentElements.First().childElements.Count() == 1
                        && ElementArray[i, j].parentElements.First().Subsystems == ElementArray[i, j].Subsystems
                        && ElementArray[i, j].parentElements.First().Row != i
                        && ElementArray[i, j].childElements.Count() < 3
                        && moved)
                    {
                        int difference = Convert.ToInt32(ElementArray[i, j].parentElements.Average(x => x.Row)) - i;

                        if (ElementArray[i + difference, j] == null)
                        {
                            ElementArray[i + difference, j] = ElementArray[i, j];
                            moved = true;
                            ElementArray[i, j] = null;
                            ArrayOperations.Update(ElementArray);
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                }
            }
        }

        private void LinearizeIndividualElements()
        {
            var rows = ElementArray.GetLength(0);
            var columns = ElementArray.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    bool moved = true;
                    if (ElementArray[i, j] != null)
                    {
                        var txt = ElementArray[i, j].Text;
                    }

                    while (ElementArray[i, j] != null
                        && ElementArray[i, j].parentElements.Count() == 1
                        && ElementArray[i, j].parentElements.First().childElements.Count() == 1
                        && ElementArray[i, j].parentElements.First().Row != i
                        && ElementArray[i, j].childElements.Count() == 0
                        && ElementArray[i, j].parentElements.First().Subsystems.Equals(ElementArray[i, j].Subsystems)
                        && moved)
                    {
                        int difference = Convert.ToInt32(ElementArray[i, j].parentElements.Average(x => x.Row)) - i;

                        if (ElementArray[i + difference, j] == null)
                        {
                            ElementArray[i + difference, j] = ElementArray[i, j];
                            moved = true;
                            ElementArray[i, j] = null;
                            ArrayOperations.Update(ElementArray);
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                }
            }
        }

        private void LinearizeIndividualElementsIfOutOfSystem()
        {
            var rows = ElementArray.GetLength(0);
            var columns = ElementArray.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    bool moved = true;
                    if (ElementArray[i, j] != null)
                    {
                        var txt = ElementArray[i, j].Text;

                        while (ElementArray[i, j] != null
                            && ElementArray[i, j].parentElements.Count() == 1
                            && ElementArray[i, j].parentElements.First().childElements.Count() == 1
                            && ElementArray[i, j].parentElements.First().Row != i
                            && ElementArray[i, j].childElements.Count() == 0
                            && ElementArray[i, j].parentElements.First().Subsystems.Count() != 0
                            && moved)
                        {
                            (int lowestRow, int lowestColumn, int highestRow, int highestColumn)  = ElementArray[i, j].parentElements.First().Subsystems.First().GetSubsystemLocation(ElementArray);
                            if (highestColumn < j)
                            {
                                int difference = Convert.ToInt32(ElementArray[i, j].parentElements.Average(x => x.Row)) - i;

                                if (ElementArray[i + difference, j] == null)
                                {
                                    ElementArray[i + difference, j] = ElementArray[i, j];
                                    moved = true;
                                    ElementArray[i, j] = null;
                                    ArrayOperations.Update(ElementArray);
                                }
                                else
                                {
                                    moved = false;
                                }
                            }
                            else
                            {
                                moved = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
