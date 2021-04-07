using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    static class GridOperations
    {
        public static IGrid DictionaryToGrid(ElementRegister elementRegister)
        {
            return new GridFromDictionary(elementRegister).GetGrid();
        }

        public static IGrid CreateGrid(Element[,] elementArray)
        {
            return new Grid(elementArray);
        }

        public static IGrid CreateOrganizedGrid(IGrid grid, IArrowRegister arrowRegister)
        {
            return new OrganizedGrid(grid, arrowRegister).GetOrganizedGrid();
        }

        public static IGrid FillSpots(IGrid grid)
        {
            return new GridWithFilledSpots(grid);
        }

        public static IGrid MakeRowsCompact(IGrid grid)
        {
            return new CompactGrid(grid).Get();
        }

        public static IGrid ArrangeRows(IGrid grid)
        {
            return new GridWithArrangedRows(grid);
        }

        public static IGrid Equalize(IGrid grid)
        {
            return new EqualizedGrid(grid);
        }

        public static IGrid TrimEnds(IGrid grid)
        {
            return new GridWithTrimmedEnds(grid);
        }

        public static IGrid AdjustForArrows(IGrid grid, IArrowRegister arrowRegister)
        {
            return new GridAdjustedForArrows(grid, arrowRegister);
        }
    }
}
