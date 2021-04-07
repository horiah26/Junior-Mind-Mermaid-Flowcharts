using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    class GridWithArrangedLastColumn : IGrid
    {
        public Element[,] ElementArray { get; set; }

        public GridWithArrangedLastColumn(IGrid grid)
        {
            ElementArray = grid.ElementArray;
            Level();
        }

        public void Level()
        {
            var lastColumn = ArrayOperations.GetLastColumn(ElementArray);
            int indexOfLastColumn = ArrayOperations.GetIndexOfLastColumn(ElementArray);

            if (lastColumn.Count() == 1)
            {
                List<int> indexOfParentsFromLastColumn = new List<int>() { };

                foreach (var parent in lastColumn.First().parentElements)
                {
                    if (parent.Column == indexOfLastColumn - 1)
                    {
                        indexOfParentsFromLastColumn.Add(parent.Row);
                    }
                }

                int averageRowOfParentsFromPreviousColumn = (int)Math.Floor(indexOfParentsFromLastColumn.Average(x => x));
                lastColumn.First().Row = averageRowOfParentsFromPreviousColumn;
                return;
            }

            var averageParents = (double)lastColumn.Average(x => GetAverageRowOfParents(x));
            var averageThis = (double)lastColumn.Average(x => x.Row);

            var difference = Convert.ToInt32(averageParents - averageThis);

            if (difference > 0)
            {
                ElementArray = ArrayOperations.LowerColumns(ElementArray, 0, indexOfLastColumn, difference);
            }

            ArrayOperations.Update(ElementArray);
        }

        private double GetAverageRowOfParents(Element element)
        {
            if (element.parentElements.Count != 0)
            {
                return element.parentElements.Average(x => x.Row);
            }

            return element.Row;
        }
    }
}