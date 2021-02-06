using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Flowcharts
{
    class GridLastOccupiedColumnFinder
    {
        Element[,] elementGrid;

        public GridLastOccupiedColumnFinder(Grid grid)
        {
            elementGrid = grid.elementGrid;
        }

        public int GetLastColumn()
        {
            List<Element> list = new List<Element> { };

            foreach(Element element in elementGrid)
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