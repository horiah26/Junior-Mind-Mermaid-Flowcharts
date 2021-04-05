using System.Linq;

namespace Flowcharts
{
    public class GridFromDictionary
    {
        readonly Grid grid = new Grid();
        readonly ElementRegister elementList;

        public GridFromDictionary(ElementRegister elementList)
        {
            this.elementList = elementList;
        }

        public Grid GetGrid()
        {
            var columns = elementList.GroupBy(x => x.Column);

            foreach (var column in columns)
            {
                int i = 0;

                foreach (var element in column)
                {
                    grid.Add(element, i++, column.Key);
                }
            }

            return grid;
        }
    }
}
