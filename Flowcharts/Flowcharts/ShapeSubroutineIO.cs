using System;

namespace Flowcharts
{
    internal class ShapeSubroutineIO
    {
        (double x, double y) In;
        (double x, double y) Out;
        (double x, double y) BackArrowLeft;
        (double x, double y) BackArrowRight;

        private readonly IOrientation orientation;
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;

        public ShapeSubroutineIO(IOrientation orientation, double xPos, double yPos, double height, double length)
        {
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        public IOPoints GetIO()
        {
            double gap = 20;

            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - 5 - 7, yPos);
                Out = (xPos + length + 5, yPos);

                BackArrowLeft = (xPos + length / 2, yPos - height / 2);
                BackArrowRight = (xPos + length / 2, yPos + height / 2);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + length + 11, yPos);
                Out = (xPos - 7, yPos);

                BackArrowLeft = (xPos + length / 2, yPos - height / 2);
                BackArrowRight = (xPos + length / 2, yPos + height / 2);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos - height / 2 - 4);
                Out = (xPos + length / 2, yPos + height / 2);

                BackArrowLeft = (xPos - 7, yPos);
                BackArrowRight = (xPos + length + 7, yPos);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos + height / 2+ 4);
                Out = (xPos + length / 2, yPos - height / 2);

                BackArrowLeft = (xPos - 7, yPos);
                BackArrowRight = (xPos + length + 7, yPos);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return new IOPoints(In, Out, BackArrowLeft, BackArrowRight);
        }
    }
}