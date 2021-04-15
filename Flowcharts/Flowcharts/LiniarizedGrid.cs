using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    class LiniarizedGrid : IGrid
    {
        public Element[,] ElementArray { get; private set; }

        public LiniarizedGrid(IGrid grid)
        {
            ElementArray = ArrayOperations.CloneArray(grid);
            LevelColumns();
            LinearizeIndividualElements();
            LinearizeInLoweredTwinSituation();
            LinearizeInTwinsSituationForward();
            LinearizeIndividualElements();
        }

        private void LevelColumns()
        {
            int columns = ElementArray.GetLength(1);

            for (int i = 0; i < columns; i++)
            {
                Level(i);
            }

            for (int i = columns - 1; i >= 0; i--)
            {
                AdjustBackwardsColumnsWithOneElement(i);
            }
        }

        public void Level(int columnIndex)
        {
            var column = ArrayOperations.ExtractColumn(ElementArray, columnIndex);

            var averageParentsRow = GetAverageRowOfParents(column);

            var averageRow = (double)column.Where(x => x != null).Average(x => x.Row);

            var difference = Convert.ToInt32(averageParentsRow - averageRow);

            if (difference > 0)
            {
                ElementArray = ArrayOperations.LowerColumns(ElementArray, 0, columnIndex, difference);
            }

            if (difference < 0 && columnIndex < ElementArray.GetLength(1) - 1)
            {
                ElementArray = ArrayOperations.LowerColumns(ElementArray, 0, columnIndex + 1, -difference);
            }

            ArrayOperations.Update(ElementArray);
        }

        public void AdjustBackwardsColumnsWithOneElement(int columnIndex)
        {
            var nonNullColumn = ArrayOperations.ExtractColumn(ElementArray, columnIndex).Where(x => x != null);

            if (nonNullColumn.Count() == 1) 
            {
                var averageRowOfChildren = GetAverageRowOfChildren(nonNullColumn);

                var row = nonNullColumn.First().Row;

                var difference = Convert.ToInt32(averageRowOfChildren - row);

                if (difference > 0)
                {
                    ElementArray = ArrayOperations.LowerColumns(ElementArray, 0, columnIndex, difference);
                }

                ArrayOperations.Update(ElementArray);
            }

        }


        private double GetAverageRowOfParents(IEnumerable<Element> column)
        {
            var rows = new List<double>() { };

            foreach(var element in column)
            {
                if (element != null && element.parentElements.Count != 0)
                {
                    rows.Add(element.parentElements.Average(x => x.Row));
                }
            }

            if(rows.Count != 0)
            {
                return rows.Average();
            }

            return 0;
        }

        private double GetAverageRowOfChildren(IEnumerable<Element> column)
        {
            var rows = new List<double>() { };

            foreach (var element in column)
            {
                if (element != null && element.childElements.Count != 0)
                {
                    rows.Add(element.childElements.Average(x => x.Row));
                }
            }

            if (rows.Count != 0)
            {
                return rows.Average();
            }

            return 0;
        }

        private void LinearizeIndividualElements()
        {
            var rows = ElementArray.GetLength(0);
            var columns = ElementArray.GetLength(1);


            for (int i = 1; i < rows; i++)
            {
                for (int j = 0; j < columns ; j++)
                {
                    bool moved = true;

                    while (ElementArray[i, j] != null
                        && ElementArray[i, j].parentElements.Count() == 1
                        && ElementArray[i, j].parentElements.First().childElements.Count() == 1
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

        private void LinearizeInLoweredTwinSituation()
        {
            var rows = ElementArray.GetLength(0);
            var columns = ElementArray.GetLength(1);

            for (int i = 1; i < rows; i++)
            {
                for (int j = columns - 1; j >= 0; j--)
                {
                    if (ElementArray[i, j] != null
                        && ElementArray[i, j].childElements.Count() == 2)
                    {
                        int difference = Convert.ToInt32(ElementArray[i, j].childElements.Average(x => x.Row)) - i;

                        if (ElementArray[i + difference, j] == null)
                        {
                            ElementArray[i + difference, j] = ElementArray[i, j];
                            ElementArray[i, j] = null;
                            ArrayOperations.Update(ElementArray);
                        }
                    }
                }
            }
        }

        private void LinearizeInTwinsSituationForward()
        {
            var rows = ElementArray.GetLength(0);
            var columns = ElementArray.GetLength(1);

            ElementArray = new ResizedElementArray(ElementArray, rows + 1, columns).GetArray();

            for (int i = 1; i < rows - 1; i++)
            {
                for (int j = 0; j < columns - 1; j++)
                {
                    if (ElementArray[i, j] != null
                        && ElementArray[i, j].childElements.Count() == 2
                        && ElementArray[i, j].parentElements.Count() == 1
                        && ElementArray[i, j].parentElements.First().childElements.Count() == 1
                        && ElementArray[i - 1, j + 1] == ElementArray[i, j].childElements[0]
                        && ElementArray[i + 1, j + 1] == ElementArray[i, j].childElements[1]
                        && ElementArray[i, j].parentElements.First().Row > i
                        )
                    {                     
                        if(ElementArray[i + 1, j] == null
                            && ElementArray[i, j + 1] == null
                            && ElementArray[i + 2, j + 1] == null)
                        {
                            ElementArray[i + 1, j] = ElementArray[i, j];
                            ElementArray[i, j] = null;

                            ElementArray[i, j + 1] = ElementArray[i - 1, j + 1];
                            ElementArray[i - 1, j + 1] = null;

                            ElementArray[i + 2, j + 1] = ElementArray[i + 1, j + 1];
                            ElementArray[i + 1, j + 1] = null;
                        }
                    }
                }
            }            
        }
    }
}