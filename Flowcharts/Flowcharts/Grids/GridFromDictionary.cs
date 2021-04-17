using System.Linq;

namespace Flowcharts
{
    public class GridFromDictionary
    {
        readonly Grid grid = new Grid();
        readonly ElementRegister elementRegister;

        public GridFromDictionary(ElementRegister elementRegister)
        {
            this.elementRegister = elementRegister;
        }

        public Grid GetGrid()
        {
            var columns = elementRegister.GroupBy(x => x.Column);

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
