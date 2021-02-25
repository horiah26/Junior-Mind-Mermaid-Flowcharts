using System.Collections.Generic;

namespace Flowcharts
{
    class GridBackArrowAdjuster
    {
        readonly Grid grid;

        public GridBackArrowAdjuster(Grid grid)
        {
            this.grid = grid;
        }

        public void AdjustForBackArrows(List<Arrow> arrows)
        {
            List<(double row, int forwardColum, int backColumn)> backArrowpoints = new List<(double row, int forwardColum, int backColumn)> { };

            UpdateListOfBackArrows(ref backArrowpoints, arrows);

            foreach (var element in grid)
            {
                UpdateListOfBackArrows(ref backArrowpoints, arrows);

                foreach (var (row, forwardColum, backColumn) in backArrowpoints)
                {
                    if (element.Row == row && backColumn < element.Column && element.Column < forwardColum)
                    {
                        new GridColumnLowerer(grid).LowerColumnInGrid(row, element.Column, 1);
                        new GridElementActualizer(grid).Actualize();
                    }
                }
            }
        }

        private void UpdateListOfBackArrows(ref List<(double row, int forwardColum, int backColumn)> backArrowpoints, List<Arrow> arrows)
        {
            List<(double row, int forwardColum, int backColumn)> temppoints = new List<(double row, int forwardColum, int backColumn)> { };

            foreach (var backArrow in arrows)
            {
                if (typeof(BackArrow) == backArrow.GetType())

                    if (typeof(BackArrow) == backArrow.GetType() && backArrow.fromElement.Row == backArrow.toElement.Row)
                    {
                        temppoints.Add((backArrow.fromElement.Row, backArrow.fromElement.Column, backArrow.toElement.Column));
                    }
            }

            backArrowpoints = temppoints;
        }
    }
}
