using System.Collections.Generic;

namespace Flowcharts
{
    class PairedArrows : IArrowRegister
    {
        public List<IArrow> ArrowList { get; private set; }

        readonly Element[,] elementArray;

        public PairedArrows(IArrowRegister arrowRegister, IGrid grid)
        {
            ArrowList = arrowRegister.ArrowList;
            elementArray = grid.ElementArray;
            PairArrows();
        }

        public void PairArrows()
        {
            foreach(var arrow in ArrowList)
            {
                (Element toElement, Element fromElement) = arrow.GetElementPair();

                foreach(Element element in elementArray)
                {
                    if(element != null)
                    {
                        if (element.Key == toElement.Key)
                        {
                            arrow.FromElement = element;
                        }
                        if (element.Key == fromElement.Key)
                        {
                            arrow.ToElement = element;
                        }
                    }
                }
            }
        }
    }
}