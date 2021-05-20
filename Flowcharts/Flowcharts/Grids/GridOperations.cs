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
            return new LinearizedGrid(grid);
        }

        public static IGrid TrimEnds(IGrid grid)
        {
            return new GridWithTrimmedEnds(grid);
        }

        public static IGrid DistanceTwinsAndLinearize(IGrid grid)
        {
            var linearizedGrid = Linearize(grid);
            var distancedGrid = new GridWithEquallyDistanceTwins(linearizedGrid);

            for (int i = 0; i < 2; i++)
            {
                linearizedGrid = Linearize(distancedGrid);
                distancedGrid = new GridWithEquallyDistanceTwins(linearizedGrid);
            }

            return TrimEnds(distancedGrid);
        }        

        public static IGrid ArrangeLastColumn(IGrid grid)
        {
            return new GridWithArrangedLastColumn(grid);
        }

        public static IGrid ArrangeSubsystems(IGrid grid)
        {
            return new GridWithSubsystems(grid);
        }

        public static IGrid LinearizeSubsystems(IGrid grid)
        {
            return new GridWithLinearizedSubsystem(grid);
        }

        public static IGrid DistanceTwinsInSubsystems(IGrid grid)
        {
            return new GridWithDistancedTwinsInSubsystems(grid);
        }
    }
}
