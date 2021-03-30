﻿using System;

namespace Flowcharts
{
    class ShapeCircleIO
    {
        (double x, double y) In;
        (double x, double y) Out;
        readonly IOrientation orientation;
        readonly double xPos;
        readonly double yPos;
        readonly double radius;

        public ShapeCircleIO(IOrientation orientation, double xPos, double yPos, double radius)
        {
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.radius = radius;
        }

        public IOPoints GetIO()
        {
            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - radius - 3, yPos);
                Out = (xPos, yPos);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + radius + 5, yPos);
                Out = (xPos, yPos);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos, yPos - radius - 4);
                Out = (xPos, yPos );
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                Out = (xPos, yPos);
                In = (xPos, yPos + radius + 4);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return new IOPoints(In, Out);
        }
    }
}
