using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class GridSpacer
    {
        IOrientation orientation;

        public GridSpacer(IOrientation orientation)
        {
            this.orientation = orientation;
        }

        public (int distanceFromEdge, int unitLength, int unitHeight) GetSpacing()
        {
            if (typeof(OrientationRightLeft) == orientation.GetType() || typeof(OrientationLeftRight) == orientation.GetType())
            {
                return (75, 400, 125);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType() || typeof(OrientationDownTop) == orientation.GetType())
            {
                return (75, 200, 275);
            }
            else
            {
                throw new ArgumentException("Orientation must be one of the following: RightLeft | LeftRight | TopDown | DownTop");
            }
        }
    }
}
