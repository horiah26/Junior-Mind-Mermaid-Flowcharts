using System;

namespace Flowcharts
{
    class ShapeRectangleIO
    {
        (double x, double y) In;
        (double x, double y) Out;
        (double x, double y) BackArrowLeft;
        (double x, double y) BackArrowRight;

        readonly IOrientation orientation = StaticOrientation.Orientation;
        readonly double xPos;
        readonly double yPos;
        readonly double height;
        readonly double length;

        public ShapeRectangleIO(double xPos, double yPos, double height, double length)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        public IOPoints GetIO()
        {
            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - 5, yPos);
                Out = (xPos + length, yPos);

                BackArrowLeft = (xPos + length / 2, yPos - height / 2);
                BackArrowRight = (xPos + length / 2, yPos + height / 2);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + length + 5, yPos);
                Out = (xPos, yPos);

                BackArrowLeft = (xPos + length / 2, yPos - height / 2);
                BackArrowRight = (xPos + length / 2, yPos + height / 2);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos - height / 2 - 4);
                Out = (xPos + length / 2, yPos + height / 2);

                BackArrowLeft = (xPos, yPos);
                BackArrowRight = (xPos + length, yPos);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos + height / 2+ 4);
                Out = (xPos + length / 2, yPos - height / 2);

                BackArrowLeft = (xPos, yPos);
                BackArrowRight = (xPos + length, yPos);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return ElementOperations.CreateIO(In, Out, BackArrowLeft, BackArrowRight);
        }
    }
}