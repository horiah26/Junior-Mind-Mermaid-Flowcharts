using System.Collections.Generic;

namespace Flowcharts
{
    internal class GridAdjustedForArrows : IGrid
    {
        readonly List<IArrow> arrowList;

        public Element[,] ElementArray { get; private set; }

        public GridAdjustedForArrows(IGrid grid, IArrowRegister arrowRegister)
        {
            ElementArray = ArrayOperations.CloneArray(grid);
            arrowList = new PairedArrows(arrowRegister, grid).ArrowList;
            AdjustForArrows();
        }

        private void AdjustForArrows()
        {
            foreach(IArrow arrow in arrowList)
            {
                (Element fromElement, Element toElement) = arrow.GetElementPair();

                if(fromElement.Row == toElement.Row && toElement.Column - toElement.Column != 1)
                {
                    for(int i = fromElement.Column + 1; i < toElement.Column; i++)
                    {                        
                        ElementArray = ArrayOperations.LowerColumns(ElementArray, fromElement.Row, i, 1);
                    }
                }
            }
        }
    }
}