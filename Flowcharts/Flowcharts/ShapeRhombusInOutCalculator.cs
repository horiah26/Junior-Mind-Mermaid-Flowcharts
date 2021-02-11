using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ShapeRhombusInOutCalculator
    {
        (double x, double y) In;
        (double x, double y) Out;

        IOrientation orientation;
        double xPos;
        double yPos;
        double rhombusSize;

        public ShapeRhombusInOutCalculator(IOrientation orientation, double xPos, double yPos, double rhombusSize)
        {
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.rhombusSize = rhombusSize;
        }

        public ((double x, double y) In, (double x, double y) Out) GetInOut()
        {
            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - 5, yPos + rhombusSize / 2);
                Out = (xPos + rhombusSize, yPos + rhombusSize / 2);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + rhombusSize + 3, yPos + rhombusSize / 2);
                Out = (xPos, yPos + rhombusSize / 2);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + rhombusSize / 2, yPos - 4);
                Out = (xPos + rhombusSize / 2, yPos + rhombusSize);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + rhombusSize / 2, yPos + rhombusSize + 3);
                Out = (xPos + rhombusSize / 2, yPos);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return (In, Out);
        }
    }
}
