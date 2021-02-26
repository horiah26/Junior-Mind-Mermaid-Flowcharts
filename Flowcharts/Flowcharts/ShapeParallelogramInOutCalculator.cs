using System;

namespace Flowcharts
{
    class ShapeParallelogramInOutCalculator
    {
        (double x, double y) In;
        (double x, double y) Out;
        readonly IOrientation orientation;
        readonly double xPos;
        readonly double yPos;
        readonly double length;
        readonly double height;
        private readonly double gap;

        public ShapeParallelogramInOutCalculator(IOrientation orientation, double xPos, double yPos, double height, double length, string[] lines, double gap)
        {
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.length = length;
            this.height = height;
            this.gap = gap;
        } 
        public EntryExitPoints CalculateInOut()
        {

            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - 5 - gap/2, yPos + height / 2);
                Out = (xPos + length + gap / 2, yPos + height / 2);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + length + gap / 2 + 4, yPos + height / 2);
                Out = (xPos - 5 - gap / 2 + 4, yPos + height / 2);
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