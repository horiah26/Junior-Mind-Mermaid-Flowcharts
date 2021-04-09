using System;

namespace Flowcharts
{
    internal class ShapeBannerIO
    {
        private readonly IOrientation orientation;
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;

        public ShapeBannerIO(IOrientation orientation, double xPos, double yPos, double height, double length)
        {
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        public IOPoints GetIO()
        {
            (double x, double y) In;
            (double x, double y) Out;
            (double x, double y) BackArrowLeft;
            (double x, double y) BackArrowRight;

            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - 20, yPos);
                Out = (xPos + length / 1.25 + 1, yPos);

                BackArrowLeft = (xPos + length / 2.5, yPos - height / 2);
                BackArrowRight = (xPos + length / 2.5, yPos + height / 2);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + length - length / 5 + 3, yPos);
                Out = (xPos - 10, yPos);

                BackArrowLeft = (xPos + length / 2.5, yPos - height / 2);
                BackArrowRight = (xPos + length / 2.5, yPos + height / 2);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + length / 2 - length / 10 - 15, yPos - height / 2 - 5);
                Out = (xPos + length / 2 - length / 10  - 15, yPos + height/2);

                BackArrowLeft = (xPos - 20, yPos);
                BackArrowRight = (xPos + length - length / 10 - 15, yPos);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + length / 2 - length / 10 - 15, yPos + height / 2 + 4);
                Out = (xPos + length / 2 - length / 10 - 15, yPos - height / 2);

                BackArrowLeft = (xPos - 20, yPos);
                BackArrowRight = (xPos + length - length / 10 - 15, yPos);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return new IOPoints(In, Out, BackArrowLeft, BackArrowRight);
        }
    }
}