using System.Linq;

namespace Flowcharts
{
    class AverageRowOfChildren
    {
        readonly Element element;

        public AverageRowOfChildren(Element element)
        {
            this.element = element;
        }

        public AverageRowOfChildren(Element[,] elementArray, int row, int column)
        {
            element = elementArray[row, column];
        }

        public double Get()
        {
            if (element != null && element.childElements.Count != 0)
            {
                return (element.childElements.Max(x => x.Row) + element.childElements.Min(x => x.Row)) / 2;
            }

            return element.Row;
        }
    }
}
