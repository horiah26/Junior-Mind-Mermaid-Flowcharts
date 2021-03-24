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
            var arrangedGrid = new GridWithArrangedRows(grid).Get();
            var filledGrid = new GridWithFilledSpots(arrangedGrid).Get();
            var gridAdjustedForBackArrows = new GridAdjustedForBackArrow(filledGrid, arrows).Get();
            var gridWithArrangedLastColumn = new GridWithArrangedLastColumn(gridAdjustedForBackArrows).Get();
            var trimmedGrid = new GridWithTrimmedEnds(gridWithArrangedLastColumn).GetWithoutNull();
            return trimmedGrid;
        }
    }
}
