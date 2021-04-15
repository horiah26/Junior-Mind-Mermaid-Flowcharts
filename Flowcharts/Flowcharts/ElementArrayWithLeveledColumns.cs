using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    public class ElementArrayWithLeveledColumns : IElementArray
    {
        public Element[,] ElementArray { get; private set; }

        public ElementArrayWithLeveledColumns(Element[,] ElementArray)
        {
            this.ElementArray = ElementArray;
            LevelColumns();
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

            foreach (var element in column)
            {
                if (element != null && element.parentElements.Count != 0)
                {
                    rows.Add(element.parentElements.Average(x => x.Row));
                }
            }

            if (rows.Count != 0)
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
    }
}
