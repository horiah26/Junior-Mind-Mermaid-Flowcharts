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
            var distancedGrid = GridOperations.DistanceTwinsAndLinearize(filledGrid2);
            var linearizedGrid2 = GridOperations.Linearize(distancedGrid);
            var distancedGrid2 = GridOperations.DistanceTwinsAndLinearize(linearizedGrid2);
            var trimmedGrid2 = GridOperations.TrimEnds(distancedGrid2);
            var linearizedGrid3 = GridOperations.Linearize(trimmedGrid2);
            var last = GridOperations.ArrangeLastColumn(trimmedGrid2);

            return linearizedGrid3;
        }
    }
}