using System;

namespace Flowcharts
{
    internal class ShapeCylinderIO
    {
        private readonly IOrientation orientation;
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;
        private readonly int numberOfLines;

        public ShapeCylinderIO(IOrientation orientation, double xPos, double yPos, double height, double length, int numberOfLines)
        {
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
            this.numberOfLines = numberOfLines;
        }

        public IOPoints GetIO()
        {
            (double x, double y) In;
            (double x, double y) Out;
            (double x, double y) BackArrowEntry;

            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - 5, yPos + height / 2);
                Out = (xPos + length / 2, yPos + height / 2);

                BackArrowEntry = (xPos + length, yPos + height / 2);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + length + 5, yPos + height / 2);
                Out = (xPos + length / 2, yPos + height / 2);

                BackArrowEntry = (xPos - 20, yPos + height / 2);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos - 23 - numberOfLines * 4);
                Out = (xPos + length / 2, yPos + height / 2);

                BackArrowEntry = (xPos + length / 2, yPos + height + 10);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos + height + 15);
                Out = (xPos + length / 2, yPos);

                BackArrowEntry = (xPos + length / 2, yPos - height + numberOfLines * 15 - 20);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return new IOPoints(In, Out, BackArrowEntry);
        }
    }
}