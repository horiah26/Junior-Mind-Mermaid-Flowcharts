using System;
using System.Linq;

namespace Flowcharts
{
    class GridWithArrangedRows
    {
        Grid newGrid;

        public GridWithArrangedRows(Grid grid)
        {
            newGrid = new Grid(grid);
        }

        public void ArrangeRows()
        {
            int lastColumnIndex = new LastColumn(newGrid).Index;

            for (int column = lastColumnIndex; column >= 0; column--)
            {
                for (int row = 0; row < newGrid.Rows; row++)
                {
                    if (newGrid.elementArray[row, column] != null)
                    {
                        MoveColumnInPlace(row, column);
                    }
                }

                newGrid = new UpdatedGrid(newGrid).Get();
            }

            newGrid = new UpdatedGrid(newGrid).Get();
        }

        private void MoveColumnInPlace(int row, int column)
        {
            double average = GetAverageRowOfChildren(newGrid.elementArray[row, column]);
            int difference = (int)average - row;
            if (difference > 0)
            {
                newGrid.elementArray = new ElementArrayWithLoweredColumn(newGrid, row, column, difference).GetNewGrid();
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
            return new UpdatedGrid(newGrid).Get();
        }
    }
}