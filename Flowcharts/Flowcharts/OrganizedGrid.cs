namespace Flowcharts
{
    class OrganizedGrid
    {
        readonly IGrid grid;

        public OrganizedGrid(IGrid grid)
        {
            this.grid = grid;
        }

        public IGrid GetOrganizedGrid()
        {
            var filledGrid = GridOperations.FillSpots(grid);
            var compactGrid = GridOperations.MakeRowsCompact(filledGrid);
            var arrangedGrid = GridOperations.ArrangeRows(compactGrid);
            var linearizedGrid = GridOperations.Linearize(arrangedGrid);
            var trimmedGrid = GridOperations.TrimEnds(linearizedGrid);
            var filledGrid2 = GridOperations.FillSpots(trimmedGrid);
            var distancedGrid = GridOperations.DistanceTwins(filledGrid2);
            var linearizedGrid2 = GridOperations.Linearize(distancedGrid);
            var last = GridOperations.ArrangeLastColumn(linearizedGrid2);

            return last;
        }
    }
}