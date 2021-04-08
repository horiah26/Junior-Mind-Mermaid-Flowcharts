using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    class GridWithArrangedLastColumn : IGrid
    {
        public Element[,] ElementArray { get; set; }

        public GridWithArrangedLastColumn(IGrid grid)
        {
            ElementArray = grid.ElementArray;
            Level();
        }

        public void Level()
        {
            var lastColumn = ArrayOperations.GetLastColumn(ElementArray);

            if (lastColumn.Count() == 1)
            {
                int min = lastColumn.First().parentElements.Min(x => x.Row);
                int max = lastColumn.First().parentElements.Max(x => x.Row);

                lastColumn.First().Row = (min + max) / 2;

                return;
            }
        }
    }
}