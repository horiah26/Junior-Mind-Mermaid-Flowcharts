using System.Collections.Generic;

namespace Flowcharts
{
    class GridAdjustedForBackArrow : IGrid
    {
        readonly List<BackArrow> arrows;
        public Element[,] ElementArray { get; private set; }

        public GridAdjustedForBackArrow(Grid grid, List<IArrow> arrows)
        {
            this.arrows = ExtractBackArrows(arrows);
            ElementArray = ArrayOperations.CloneArray(grid);
        }

        public void AdjustForBackArrows()
        {
            if(arrows.Count == 0)
            {
                return;
            }

            List<(double row, int forwardColum, int backColumn)> backArrowPoints = new List<(double row, int forwardColum, int backColumn)> { };

            UpdateListOfBackArrows(ref backArrowPoints, arrows);

            foreach (var element in ElementArray)
            {
                if(element != null)
                {
                    UpdateListOfBackArrows(ref backArrowPoints, arrows);

                    foreach (var (row, forwardColum, backColumn) in backArrowPoints)
                    {
                        if (element.Row == row && backColumn < element.Column && element.Column < forwardColum)
                        {
                            ElementArray = ArrayOperations.LowerColumns(ElementArray, row, element.Column, 1);
                            ArrayOperations.Update(ElementArray);
                        }
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
    }
}