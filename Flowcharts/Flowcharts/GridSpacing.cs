using System;

namespace Flowcharts
{
    class GridSpacing
    {
        readonly IOrientation orientation;

        public GridSpacing(IOrientation orientation)
        {
            this.orientation = orientation;
        }

        public (int distanceFromEdge, int unitLength, int unitHeight) GetSpacing()
        {
            if (typeof(OrientationRightLeft) == orientation.GetType() || typeof(OrientationLeftRight) == orientation.GetType())
            {
                return (150, 300, 150);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType() || typeof(OrientationDownTop) == orientation.GetType())
            {
                return (150, 200, 275);
            }
            else
            {
                throw new ArgumentException("Orientation must be one of the following: RightLeft | LeftRight | TopDown | DownTop");
            }
        }
    }
}
