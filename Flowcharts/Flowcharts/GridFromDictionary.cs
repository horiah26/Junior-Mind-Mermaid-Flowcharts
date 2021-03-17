using System.Linq;

namespace Flowcharts
{
    public class GridFromDictionary
    {
        readonly Grid grid = new Grid();
        readonly ElementRegister elementManager;

        public GridFromDictionary(ElementRegister elementManager)
        {
            this.elementManager = elementManager;
        }

        public Grid GetGrid()
        {
            var columns = elementManager.GroupBy(x => x.Column);

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
