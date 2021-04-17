using System.Linq;

namespace Flowcharts
{
    class AverageRowOfChildren
    {
        readonly Element element;
        readonly Element[,] elementArray;

        public AverageRowOfChildren(Element[,] elementArray, int row, int column)
        {
            this.elementArray = elementArray;
            element = elementArray[row, column];
        }

        public double Get()
        {
            foreach(var child in element.childElements)
            {
                foreach (var element in elementArray)
                {
                    if(element != null && child.Key == element.Key)
                    {
                        child.Row = element.Row;
                    }
                }
            }

            if (element != null && element.childElements.Count != 0)
            {                
                double val = (element.childElements.Max(x => x.Row) + element.childElements.Min(x => x.Row)) / 2;
                return val;
            }

            return element.Row;
        }
    }
}