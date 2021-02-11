using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Flowcharts
{
    class GridLastOccupiedColumnFinder
    {
        readonly Grid grid;

        public GridLastOccupiedColumnFinder(Grid grid)
        {
            this.grid = grid;
        }

        public int GetLastColumn()
        {
            List<Element> list = new List<Element> { };

            foreach(Element element in grid.elementGrid)
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