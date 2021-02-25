using System;

namespace Flowcharts
{
    class ShapeHexagonInOutCalculator
    {
        private readonly IOrientation orientation;
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;
        readonly string[] lines;

        public ShapeHexagonInOutCalculator(IOrientation orientation, double xPos, double yPos, double height, double length, string[] lines)
        {
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
            this.lines = lines;
        }

        public EntryExitPoints GetInOut()
        {
            (double x, double y) In;
            (double x, double y) Out;
            double numberOfLines = lines.Length;
            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - numberOfLines * 10 - 3, yPos + height / 2);
                Out = (xPos + length + numberOfLines * 10, yPos + height / 2);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + length + 5, yPos + height / 2);
                Out = (xPos + length / 5, yPos + height / 2);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos - 4);
                Out = (xPos + length / 2, yPos + height);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (xPos + length / 2, yPos + height + 4);
                Out = (xPos + length / 2, yPos);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return new EntryExitPoints(In, Out);
        }
    }
}
