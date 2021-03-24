using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class OrganizedGrid
    {
        Grid grid;
        List<IArrow> arrows;

        public OrganizedGrid(Grid grid, List<IArrow> arrows)
        {
            this.grid = grid;
            this.arrows = arrows;
        }

        public Grid GetOrganizedGrid()
        {
            var arrangedGrid = new GridWithArrangedRows(grid).Get(); // !makes extra dimension for arranged grid
            var filledGrid = new GridWithFilledSpots(arrangedGrid).Get();
            var gridAdjustedForBackArrows = new GridAdjustedForBackArrow(filledGrid, arrows).Get();
            var gridWithArrangedLastColumn = new GridWithArrangedLastColumn(gridAdjustedForBackArrows).Get();
            var trimmedGrid = new GridWithTrimmedEnds(gridWithArrangedLastColumn).GetWithoutNull();
            return trimmedGrid;
        }
    }
}
