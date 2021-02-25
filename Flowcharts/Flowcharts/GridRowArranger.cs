using System;
using System.Linq;

namespace Flowcharts
{
    class GridRowArranger
    {
        readonly Grid grid;

        public GridRowArranger(Grid grid)
        {
            this.grid = grid;
        }

        public void ArrangeRows()
        {
            var elementActualizer = new GridElementActualizer(grid);

            for (int column = grid.lastOccupiedColumn; column >= 0; column--)
            {
                for (int row = 0; row < grid.rowSize; row++)
                {
                    if (grid.elementGrid[row, column] != null)
                    {
                        MoveColumnInPlace(row, column);
                    }
                }

                elementActualizer.Actualize();
            }

            elementActualizer.Actualize();
        }

        private void MoveColumnInPlace(int row, int column)
        {
            double average = GetAverageRowOfChildren(grid.elementGrid[row, column]);
            int difference = (int)average - row;
            if (difference > 0)
            {
                new GridColumnLowerer(grid).LowerColumnInGrid(row, column, difference);
            }
        }

        private double GetAverageRowOfChildren(Element element)
        {
            if (element.childElements.Count != 0)
            {
                return (int)Math.Floor(element.childElements.Average(x => x.Row));
            }

            return element.Row;
        }
    }
}