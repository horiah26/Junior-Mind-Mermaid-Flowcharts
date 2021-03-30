using System.Linq;

namespace Flowcharts
{
    class AverageRowOfChildren
    {
        Element element;

        public AverageRowOfChildren(Element element)
        {
            this.element = element;
        }

        public AverageRowOfChildren(Grid grid, int row, int column)
        {
            element = grid.elementArray[row, column];
        }

        public double GetAverage()
        {
            if (element != null && element.childElements.Count != 0)
            {
                return (element.childElements.Max(x => x.Row) + element.childElements.Min(x => x.Row)) / 2;
            }

            return element.Row;
        }
    }
}
