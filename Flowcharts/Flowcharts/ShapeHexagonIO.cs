using System;

namespace Flowcharts
{
    class ShapeHexagonIO
    {
        private readonly IOrientation orientation = StaticOrientation.Orientation;
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;
        readonly string[] lines;

        public ShapeHexagonIO(double xPos, double yPos, double height, double length, string[] lines)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
            this.lines = lines;
        }

        public IOPoints GetIO()
        {
            (double x, double y) In;
            (double x, double y) Out;
            (double x, double y) BackArrowLeft;
            (double x, double y) BackArrowRight;

            double numberOfLines = lines.Length;

            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - numberOfLines * 10 - 3, yPos);
                Out = (xPos + length + numberOfLines * 10, yPos);

                BackArrowLeft = (xPos + length / 2, yPos - height / 2);
                BackArrowRight = (xPos + length / 2, yPos + height / 2);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + length + 5 + numberOfLines * 10, yPos);
                Out = (xPos - numberOfLines * 10, yPos);

                BackArrowLeft = (xPos + length / 2, yPos - height / 2);
                BackArrowRight = (xPos + length / 2, yPos + height / 2);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos - height / 2 - 4);
                Out = (xPos + length / 2, yPos + height / 2);

                BackArrowLeft = (xPos - numberOfLines * 10, yPos);
                BackArrowRight = (xPos + length + numberOfLines * 10, yPos);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos + height / 2 + 4);
                Out = (xPos + length / 2, yPos - height / 2);

                BackArrowLeft = (xPos - numberOfLines * 10, yPos);
                BackArrowRight = (xPos + length + numberOfLines * 10, yPos);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return ElementOperations.CreateIO(In, Out, BackArrowLeft, BackArrowRight);
        }
    }
}
