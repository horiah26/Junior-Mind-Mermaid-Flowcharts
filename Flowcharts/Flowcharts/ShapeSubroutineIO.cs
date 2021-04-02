using System;

namespace Flowcharts
{
    internal class ShapeSubroutineIO
    {
        (double x, double y) In;
        (double x, double y) Out;

        (double x, double y) BackArrowEntry;

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
                Out = (xPos + length + 7, yPos);

                BackArrowEntry = (xPos + length + gap / 2, yPos);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + length + 11, yPos);
                Out = (xPos - 9, yPos);

                BackArrowEntry = (xPos - 20 - gap / 2, yPos);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos - 4);
                Out = (xPos + length / 2, yPos + height);

                BackArrowEntry = (xPos + length / 2, yPos + height / 2);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos + height + 4);
                Out = (xPos + length / 2, yPos);
                
                BackArrowEntry = (xPos + length / 2, yPos - height / 2 - 20);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return new IOPoints(In, Out, BackArrowEntry);
        }
    }
}