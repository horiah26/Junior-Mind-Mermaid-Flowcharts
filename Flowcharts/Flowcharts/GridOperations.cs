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

        public static IGrid OrganizedGrid(IGrid grid)
        {
            return new OrganizedGrid(grid).GetOrganizedGrid();
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

        public static IGrid Linearize(IGrid grid)
        {
            return new LiniarizedGrid(grid);
        }

        public static IGrid TrimEnds(IGrid grid)
        {
            return new GridWithTrimmedEnds(grid);
        }

        public static IGrid AdjustForArrows(IGrid grid, IArrowRegister arrowRegister)
        {
            return new GridAdjustedForArrows(grid, arrowRegister);
        }

        public static IGrid DistanceTwins(IGrid grid)
        {
            var linearizedGrid = GridOperations.Linearize(grid);
            return new GridWithEquallyDistanceTwins(linearizedGrid);
        }

        public static IGrid ArrangeLastColumn(IGrid grid)
        {
            return new GridWithArrangedLastColumn(grid);
        }
    }
}
