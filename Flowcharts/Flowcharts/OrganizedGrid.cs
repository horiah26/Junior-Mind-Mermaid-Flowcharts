namespace Flowcharts
{
    class OrganizedGrid
    {
        readonly IGrid grid;
        readonly IArrowRegister arrowRegister;

        public OrganizedGrid(IGrid grid, IArrowRegister arrowRegister)
        {
            this.grid = grid;
            this.arrowRegister = arrowRegister;
        }

        public IGrid GetOrganizedGrid()
        {
            var filledGrid = GridOperations.FillSpots(grid);
            var compactGrid = GridOperations.MakeRowsCompact(filledGrid);
            var arrangedGrid = GridOperations.ArrangeRows(compactGrid);
            var equalizedGrid = GridOperations.Equalize(arrangedGrid);
            var trimmedGrid = GridOperations.TrimEnds(equalizedGrid);
            //var gridAdjustedForArrows = GridOperations.AdjustForArrows(trimmedGrid, arrowRegister);
            var filledGrid2 = GridOperations.FillSpots(trimmedGrid);
            var distancedGrid = GridOperations.DistanceTwins(filledGrid2);
            var last = new GridWithArrangedLastColumn(distancedGrid);
            return last;
        }
    }
}