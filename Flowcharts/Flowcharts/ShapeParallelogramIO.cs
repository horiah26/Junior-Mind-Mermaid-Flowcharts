using System;

namespace Flowcharts
{
    class ShapeParallelogramIO
    {
        (double x, double y) In;
        (double x, double y) Out;
        (double x, double y) BackArrowEntry;

        readonly IOrientation orientation;
        readonly double xPos;
        readonly double yPos;
        readonly double length;
        readonly double height;
        private readonly double gap;

        public ShapeParallelogramIO(IOrientation orientation, double xPos, double yPos, double height, double length, double gap)
        {
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.length = length;
            this.height = height;
            this.gap = gap;
        } 

        public IOPoints GetIO()
        {
            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - 5 - gap / 2, yPos);
                Out = (xPos + length + gap / 2, yPos);

                BackArrowEntry = (xPos + length + gap / 2, yPos);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + length + gap / 2 + 4, yPos);
                Out = (xPos - 5 - gap / 2 + 4, yPos);

                BackArrowEntry = (xPos - 20 - gap / 2, yPos);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos - height / 2 - 4);
                Out = (xPos + length / 2, yPos + height / 2);

                BackArrowEntry = (xPos + length / 2, yPos + height / 2);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos + height / 2 + 4);
                Out = (xPos + length / 2, yPos - height / 2);

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