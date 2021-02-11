using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class GridBackArrowAdjuster
    {
        Grid grid;

        public GridBackArrowAdjuster(Grid grid)
        {
            this.grid = grid;
        }

        public void AdjustForBackArrows(List<Arrow> arrows)
        {
            List<(double row, int forwardColum, int backColumn)> backArrowCoordinates = new List<(double row, int forwardColum, int backColumn)> { };

            UpdateListOfBackArrows(ref backArrowCoordinates, arrows);

            foreach (var element in grid)
            {
                UpdateListOfBackArrows(ref backArrowCoordinates, arrows);

                foreach (var (row, forwardColum, backColumn) in backArrowCoordinates)
                {
                    if (element.Row == row && backColumn < element.Column && element.Column < forwardColum)
                    {
                        new GridColumnLowerer(grid).LowerColumnInGrid(row, element.Column, 1);
                        new GridElementActualizer(grid).Actualize();
                    }
                }
            }
        }

        private void UpdateListOfBackArrows(ref List<(double row, int forwardColum, int backColumn)> backArrowCoordinates, List<Arrow> arrows)
        {
            List<(double row, int forwardColum, int backColumn)> tempCoordinates = new List<(double row, int forwardColum, int backColumn)> { };

            foreach (var backArrow in arrows)
            {
                if (typeof(BackArrow) == backArrow.GetType())

                    if (typeof(BackArrow) == backArrow.GetType() && backArrow.fromElement.Row == backArrow.toElement.Row)
                    {
                        tempCoordinates.Add((backArrow.fromElement.Row, backArrow.fromElement.Column, backArrow.toElement.Column));
                    }
            }

            backArrowCoordinates = tempCoordinates;
        }
    }
}
