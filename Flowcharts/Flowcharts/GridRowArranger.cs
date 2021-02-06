using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    class GridRowArranger
    {
        Grid grid;
        int rowSize;
        int lastOccupiedColumn;
        Element[,] elementGrid;

        public GridRowArranger(Grid grid)
        {
            this.grid = grid;
            rowSize = grid.rowSize;
            lastOccupiedColumn = grid.lastOccupiedColumn;
            elementGrid = grid.elementGrid;
        }

        public void ArrangeRows()
        {
            var elementActualizer = new GridElementActualizer(grid);

            for (int column = lastOccupiedColumn; column >= 0; column--)
            {
                for (int row = 0; row < rowSize; row++)
                {
                    if (elementGrid[row, column] != null)
                    {
                        MoveColumnInPlace(row, column);
                    }
                }

                elementActualizer.Actualize();
            }

            new GridLastColumnLeveler(grid).Level();
            elementActualizer.Actualize();
        }

        private void MoveColumnInPlace(int row, int column)
        {
            double average = GetAverageRowOfChildren(elementGrid[row, column]);
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
