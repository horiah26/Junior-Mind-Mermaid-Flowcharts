using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    static class GridOperations
    {
        public static Grid CreateGrid(ElementRegister elementRegister)
        {
            return new GridFromDictionary(elementRegister).GetGrid();
        }

        public static Grid CreateOrganizedGrid(Grid grid, ArrowRegister arrowRegister)
        {
            return new OrganizedGrid(grid, arrowRegister.GetList()).GetOrganizedGrid();
        }
    }
}
