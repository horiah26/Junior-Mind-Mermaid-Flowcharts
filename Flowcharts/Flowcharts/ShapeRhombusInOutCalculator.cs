using System;

namespace Flowcharts
{
    class ShapeRhombusInOutCalculator
    {
        (double x, double y) In;
        (double x, double y) Out;
        readonly IOrientation orientation;
        readonly double xPos;
        readonly double yPos;
        readonly double rhombusSize;

        public ShapeRhombusInOutCalculator(IOrientation orientation, double xPos, double yPos, double rhombusSize)
        {
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.rhombusSize = rhombusSize;
        }

        public ((double x, double y) In, (double x, double y) Out) CalculateInOut()
        {
            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - rhombusSize / 2 - 5, yPos + rhombusSize / 2);
                Out = (xPos + rhombusSize / 2, yPos + rhombusSize / 2);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + rhombusSize / 2 + 3, yPos + rhombusSize / 2);
                Out = (xPos - rhombusSize / 2, yPos + rhombusSize / 2);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos, yPos - 4);
                Out = (xPos, yPos + rhombusSize);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos, yPos + rhombusSize + 3);
                Out = (xPos, yPos);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return (In, Out);
        }
    }
}
