using System.Collections.Generic;

namespace Flowcharts
{
    internal class GridAdjustedForArrows
    {
        private Grid newGrid;
        List<IArrow> arrows;

        public GridAdjustedForArrows(Grid grid, List<IArrow> arrows)
        {
            newGrid = new Grid(grid);
            this.arrows = arrows;
        }

        private void AdjustForArrows()
        {
            foreach(IArrow arrow in arrows)
            {
                (Element fromElement, Element toElement) = arrow.GetElementPair();

                if(fromElement.Row == toElement.Row && toElement.Column - toElement.Column != 1)
                {
                    for(int i = fromElement.Column + 1; i < toElement.Column; i++)
                    {
                        newGrid.elementArray = new ElementArrayWithLoweredColumn(newGrid, fromElement.Row, i, 1).GetNewArray();
                    }
                }
            }
        }

        internal Grid Get()
        {
            AdjustForArrows();
            return newGrid;
        }
    }
}