using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class GridSpacer
    {
        private int distanceFromEdge = 50;
        private int unitLength = 400;
        private int unitHeight = 250;

        public GridSpacer() { }

        public (int, int, int) GetSpacing()
        {
            return (distanceFromEdge, unitLength, unitHeight);
        }
    }
}
