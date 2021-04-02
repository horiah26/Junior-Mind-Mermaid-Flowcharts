using System;

namespace Flowcharts
{
    class ShapeHexagonIO
    {
        private readonly IOrientation orientation;
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;
        readonly string[] lines;

        public ShapeHexagonIO(IOrientation orientation, double xPos, double yPos, double height, double length, string[] lines)
        {
            this.orientation = orientation;
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
            (double x, double y) BackArrowEntry;

            double numberOfLines = lines.Length;

            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - numberOfLines * 10 - 3, yPos);
                Out = (xPos + length / 2, yPos);

                BackArrowEntry = (xPos + length + numberOfLines * 10, yPos);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + length + 5 + numberOfLines * 10, yPos);
                Out = (xPos + length / 2, yPos);

                BackArrowEntry = (xPos - numberOfLines * 10 - 10, yPos);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos - height / 2 - 4);
                Out = (xPos + length / 2, yPos + height / 2);

                BackArrowEntry = (xPos + length / 2, yPos);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos + height / 2 + 4);
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
