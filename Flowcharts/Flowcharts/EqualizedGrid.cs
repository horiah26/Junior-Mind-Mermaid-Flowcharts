using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    class EqualizedGrid : IGrid
    {
        public Element[,] ElementArray { get; private set; }

        public EqualizedGrid(IGrid grid)
        {
            ElementArray = ArrayOperations.CloneArray(grid);
            LevelColumns();
        }

        private void LevelColumns()
        {
            int columns = ElementArray.GetLength(1);

            for (int i = 1; i < columns; i++)
            {
                Level(i);
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

            ArrayOperations.Update(ElementArray);
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
    }
}