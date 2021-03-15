using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class OrganizedGrid
    {
        Grid grid;
        List<Arrow> arrows;

        public OrganizedGrid(Grid grid, List<Arrow> arrows)
        {
            this.grid = grid;
            this.arrows = arrows;
        }

        public Grid GetOrganizedGrid()
        {
            var updatedGrid = new UpdatedGrid(grid).Get();
            var arrangedGrid = new GridWithArrangedRows(updatedGrid).Get();
            updatedGrid = new UpdatedGrid(arrangedGrid).Get();
            var filledGrid = new GridWithFilledSpots(updatedGrid).Get();
            var gridAdjustedForBackArrows = new GridAdjustedForBackArrow(filledGrid, arrows).Get();
            var gridWithArrangedLastColumn = new GridWithArrangedLastColumn(gridAdjustedForBackArrows).Get();
            var finalGrid = new UpdatedGrid(gridWithArrangedLastColumn).Get();

            return finalGrid;
        }
    }
}
