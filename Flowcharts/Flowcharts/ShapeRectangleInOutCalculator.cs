using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ShapeRectangleInOutCalculator
    {
        (double x, double y) In;
        (double x, double y) Out;
        readonly IOrientation orientation;
        readonly double xPos;
        readonly double yPos;
        readonly int rectangleHeight;
        readonly int rectangleLength;

        public ShapeRectangleInOutCalculator(IOrientation orientation, double xPos, double yPos, int rectangleHeight, int rectangleLength)
        {
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.rectangleHeight = rectangleHeight;
            this.rectangleLength = rectangleLength;
        }

        public ((double x, double y) In, (double x, double y) Out) GetInOut()
        {
            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - 5, yPos + rectangleHeight / 2);
                Out = (xPos + rectangleLength, yPos + 20);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + rectangleLength, yPos + 20);
                Out = (xPos - 5, yPos + rectangleHeight / 2);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + rectangleLength / 2, yPos - 4);
                Out = (xPos + rectangleLength / 2, yPos + rectangleHeight);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + rectangleLength / 2, yPos + rectangleHeight);
                Out = (xPos + rectangleLength / 2, yPos - 4);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return (In, Out);
        }
    }
}
