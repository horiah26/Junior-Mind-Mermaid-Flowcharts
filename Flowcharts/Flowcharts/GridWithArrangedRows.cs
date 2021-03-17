using System;
using System.Linq;

namespace Flowcharts
{
    class GridWithArrangedRows
    {
        Grid grid;

        public GridWithArrangedRows(Grid grid)
        {
            this.grid = grid;
        }

        public void ArrangeRows()
        {

            for (int column = grid.lastOccupiedColumn; column >= 0; column--)
            {
                for (int row = 0; row < grid.rowSize; row++)
                {
                    if (grid.elementArray[row, column] != null)
                    {
                        MoveColumnInPlace(row, column);
                    }
                }

                grid = new UpdatedGrid(grid).Get();
            }

            grid = new UpdatedGrid(grid).Get();
        }

        private void MoveColumnInPlace(int row, int column)
        {
            double average = GetAverageRowOfChildren(grid.elementArray[row, column]);
            int difference = (int)average - row;
            if (difference > 0)
            {
                new GridWithLoweredColumn(grid, row, column, difference).GetNewGrid();
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

        public Grid Get()
        {
            ArrangeRows();
            return grid;
        }
    }
}