using System;

namespace Flowcharts
{
    class ShapeParallelogramIO
    {
        (double x, double y) In;
        (double x, double y) Out;
        (double x, double y) BackArrowLeft;
        (double x, double y) BackArrowRight;

        readonly IOrientation orientation = StaticOrientation.Orientation;
        readonly double xPos;
        readonly double yPos;
        readonly double length;
        readonly double height;
        private readonly double gap;

        public ShapeParallelogramIO(double xPos, double yPos, double height, double length, double gap)
        {
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

                BackArrowLeft = (xPos + length / 2, yPos - height / 2);
                BackArrowRight = (xPos + length / 2, yPos + height / 2);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + length + gap / 2 + 4, yPos);
                Out = (xPos - gap / 2, yPos);

                BackArrowLeft = (xPos + length / 2, yPos - height / 2);
                BackArrowRight = (xPos + length / 2, yPos + height / 2);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos - height / 2 - 4);
                Out = (xPos + length / 2, yPos + height / 2);

                BackArrowLeft = (xPos - gap / 2, yPos);
                BackArrowRight = (xPos + length + gap / 2, yPos);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos + height / 2 + 4);
                Out = (xPos + length / 2, yPos - height / 2);

                BackArrowLeft = (xPos - gap / 2, yPos);
                BackArrowRight = (xPos + length + gap / 2, yPos);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return ElementOperations.CreateIO(In, Out, BackArrowLeft, BackArrowRight);
        }
    }
}