using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ShapeCirlceInOutCalculator
    {
        (double x, double y) In;
        (double x, double y) Out;

        IOrientation orientation;
        int xPos;
        int yPos;
        int radius;

        public ShapeCirlceInOutCalculator(IOrientation orientation, int xPos, int yPos, int radius)
        {
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.radius = radius;
        }

        public ((double x, double y) In, (double x, double y) Out) GetInOut()
        {
            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - radius - 3, yPos);
                Out = (xPos + radius, yPos);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + radius + 5, yPos);
                Out = (xPos - radius, yPos);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos, yPos - radius - 4);
                Out = (xPos, yPos + radius);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                Out = (xPos, yPos - radius);
                In = (xPos, yPos + radius + 4);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return (In, Out);
        }
    }
}
