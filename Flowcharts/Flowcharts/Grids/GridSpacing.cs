using System;

namespace Flowcharts
{
    static class GridSpacing
    {
        static int distanceFromEdgeHorizontal = 150;
        static int unitLengthHorizontal = 200;
        static int unitHeightHorizontal = 150;

        static int distanceFromEdgeVertical = 150;
        static int unitLengthVertical = 200;
        static int unitHeightVertical = 200;


        public static (int distanceFromEdge, int unitLength, int unitHeight) GetSpacing()
        {
            IOrientation orientation = StaticOrientation.Orientation;

            if (typeof(OrientationRightLeft) == orientation.GetType() || typeof(OrientationLeftRight) == orientation.GetType())
            {
                return (distanceFromEdgeHorizontal, unitLengthHorizontal, unitHeightHorizontal);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType() || typeof(OrientationDownTop) == orientation.GetType())
            {
                return (distanceFromEdgeVertical, unitLengthVertical, unitHeightVertical);
            }
            else
            {
                throw new ArgumentException("Orientation must be one of the following: RightLeft | LeftRight | TopDown | DownTop");
            }
        }

        public static void SetHorizontal(int distanceFromEdgeHorizontal, int unitLengthHorizontal, int unitHeightHorizontal)
        {
            GridSpacing.distanceFromEdgeHorizontal = distanceFromEdgeHorizontal;
            GridSpacing.unitLengthHorizontal = unitLengthHorizontal;
            GridSpacing.unitHeightHorizontal = unitHeightHorizontal;
        }

        public static void SetVertical(int distanceFromEdgeVertical, int unitLengthVertical, int unitHeightVertical)
        {
            GridSpacing.distanceFromEdgeVertical = distanceFromEdgeVertical;
            GridSpacing.unitLengthVertical = unitLengthVertical;
            GridSpacing.unitHeightVertical = unitHeightVertical;
        }

        public static void SetLarge()
        {
            SetHorizontal(300, 250, 250);
            SetVertical(300, 250, 250);
        }
    }
}