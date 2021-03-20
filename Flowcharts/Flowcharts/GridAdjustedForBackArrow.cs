using System.Collections.Generic;

namespace Flowcharts
{
    class GridAdjustedForBackArrow
    {
        Grid grid;
        List<BackArrow> arrows;

        public GridAdjustedForBackArrow(Grid grid, List<IArrow> arrows)
        {
            this.grid = grid;
            this.arrows = ExtractBackArrows(arrows);
        }

        public void AdjustForBackArrows()
        {
            List<(double row, int forwardColum, int backColumn)> backArrowPoints = new List<(double row, int forwardColum, int backColumn)> { };

            UpdateListOfBackArrows(ref backArrowPoints, arrows);

            foreach (var element in grid)
            {
                UpdateListOfBackArrows(ref backArrowPoints, arrows);

                foreach (var (row, forwardColum, backColumn) in backArrowPoints)
                {
                    if (element.Row == row && backColumn < element.Column && element.Column < forwardColum)
                    {
                        var gridWithLoweredColumn = new GridWithLoweredColumn(grid, row, element.Column, 1).GetNewGrid();
                        grid = new UpdatedGrid(gridWithLoweredColumn).Get();
                    }
                }
            }
        }

        private void UpdateListOfBackArrows(ref List<(double row, int forwardColum, int backColumn)> backArrowPoints, List<BackArrow> arrows)
        {
            List<(double row, int forwardColum, int backColumn)> tempPoints = new List<(double row, int forwardColum, int backColumn)> { };

            foreach (var backArrow in arrows)
            {
                if (typeof(BackArrow) == backArrow.GetType() && backArrow.fromElement.Row == backArrow.toElement.Row)
                {
                    tempPoints.Add((backArrow.fromElement.Row, backArrow.fromElement.Column, backArrow.toElement.Column));
                }
            }

            backArrowPoints = tempPoints;
        }

        private List<BackArrow> ExtractBackArrows(List<IArrow> arrows)
        {
            List<BackArrow> backArrows = new List<BackArrow> { };

            foreach (var backArrow in arrows)
            {
                if (typeof(BackArrow) == backArrow.GetType())
                {
                    backArrows.Add((BackArrow)backArrow);
                }
            }

            return backArrows;
        }

        public Grid Get()
        {
            AdjustForBackArrows();
            return grid;
        }
    }
}