using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    class LastOccupiedColumnOfGrid
    {
        readonly Grid grid;

        public LastOccupiedColumnOfGrid(Grid grid)
        {
            this.grid = grid;
        }

        public int GetColumn()
        {
            List<Element> list = new List<Element> { };

            foreach(Element element in grid.elementArray)
            {
                if(element != null)
                {
                    list.Add(element);
                }
            }

            return list.Max(x => x.Column);
        }
    }
}