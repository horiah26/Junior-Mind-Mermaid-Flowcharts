using System.Collections.Generic;

namespace Flowcharts
{
    class OrganizedGrid
    {
        readonly Grid grid;
        readonly List<IArrow> arrows;

        public OrganizedGrid(Grid grid, List<IArrow> arrows)
        {
            this.grid = grid;
            this.arrows = arrows;
        }

        public Grid GetOrganizedGrid()
        {
            var filledGrid = new GridWithFilledSpots(grid).Get();
            var compactGrid = new CompactGrid(filledGrid).Get();
            var arrangedGrid = new GridWithArrangedRows(compactGrid).Get();
            var gridAdjustedForBackArrows = new GridAdjustedForBackArrow(arrangedGrid, arrows).Get();
            var equalizedGrid = new EqualizedGrid(arrangedGrid).Get();
            var trimmedGrid = new GridWithTrimmedEnds(equalizedGrid).GetWithoutNull();
            var gridAdjustedForArrows = new GridAdjustedForArrows(trimmedGrid, arrows).Get();
            filledGrid = new GridWithFilledSpots(gridAdjustedForArrows).Get();

            //var compactGrid2 = new CompactGrid(filledGrid).Get();

            //var gridAdjustedForBackArrows2 = new GridAdjustedForBackArrow(compactGrid2, arrows).Get();
            //var equalizedGrid2 = new EqualizedGrid(gridAdjustedForBackArrows2).Get();
            //var trimmedGrid2 = new GridWithTrimmedEnds(equalizedGrid2).GetWithoutNull();
            //var gridAdjustedForArrows2 = new GridAdjustedForArrows(trimmedGrid2, arrows).Get();
            //var filledGrid2 = new GridWithFilledSpots(gridAdjustedForArrows2).Get();

            //var adjustedColumnsGrid = new GridWithAdjustedColumns(filledGrid2).Get();

            return filledGrid;

        }
    }
}
