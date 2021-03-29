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
            var gridWithArrangedLastColumn = new GridWithArrangedLastColumn(gridAdjustedForBackArrows).Get();
            var trimmedGrid = new GridWithTrimmedEnds(gridWithArrangedLastColumn).GetWithoutNull();
            //Grid raisedGrid = new GridWithRaisedRows(trimmedGrid).
            return trimmedGrid;
        }
    }
}
