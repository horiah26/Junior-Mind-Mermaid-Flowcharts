using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    class EqualizedGrid
    {
        Grid newGrid;

        public EqualizedGrid(Grid grid)
        {
            newGrid = new Grid(grid);
        }

        public void LevelColumns()
        {
            for(int i = 1; i < newGrid.Columns; i++)
            {
                Level(i);
            }
        }

        public void Level(int columnIndex)
        {
            var column = new ExtractedColumn(newGrid, columnIndex).GetColumn();

            var averageParentsRow = GetAverageRowOfParents(column);

            var averageRow = (double)column.Where(x => x != null).Average(x => x.Row);

            var difference = Convert.ToInt32(averageParentsRow - averageRow);

            if (difference > 0)
            {
                newGrid.elementArray = new ElementArrayWithLoweredColumn(newGrid, 0, columnIndex, difference).GetNewArray();
            }

            newGrid = new UpdatedGrid(newGrid).Get();
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

        public Grid Get()
        {
            LevelColumns();
            return newGrid;
        }
    }
}