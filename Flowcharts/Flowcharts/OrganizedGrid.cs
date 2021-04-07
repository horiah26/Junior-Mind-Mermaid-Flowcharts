using System.Collections.Generic;

namespace Flowcharts
{
    class OrganizedGrid
    {
        readonly IGrid grid;
        readonly List<IArrow> arrows;

        public OrganizedGrid(IGrid grid, List<IArrow> arrows)
        {
            this.grid = grid;
            this.arrows = arrows;
        }

        public IGrid GetOrganizedGrid()
        {
            var a = grid;
            var filledGrid = GridOperations.FillSpots(grid);
            var compactGrid = GridOperations.MakeRowsCompact(filledGrid);
            var arrangedGrid = GridOperations.ArrangeRows(compactGrid);
            var equalizedGrid = GridOperations.Equalize(arrangedGrid);
            var trimmedGrid = GridOperations.TrimEnds(equalizedGrid);
            var gridAdjustedForArrows = GridOperations.AdjustForArrows(trimmedGrid, arrows);
            var filledGrid2 = GridOperations.FillSpots(gridAdjustedForArrows);

            return filledGrid2;
        }
    }
}