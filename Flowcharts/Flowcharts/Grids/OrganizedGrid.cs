﻿namespace Flowcharts
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
            var distancedGrid = GridOperations.DistanceTwinsAndLinearize(trimmedGrid);
            var trimmedGrid2 = GridOperations.TrimEnds(distancedGrid);
            var linearizedGrid3 = GridOperations.Linearize(trimmedGrid2);
            var last = GridOperations.ArrangeLastColumn(linearizedGrid3);
            var trimmed = GridOperations.TrimEnds(last);
   
            return trimmed;
        }
    }
}