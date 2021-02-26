using System;

namespace Flowcharts
{
    internal class ShapeTrapezoidAltPointsCalculator
    {
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;
        readonly double gap;

        public ShapeTrapezoidAltPointsCalculator(double xPos, double yPos, double height, double length, string[] lines, double gap)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
            this.gap = gap;
        }

        internal string Calculate()
        {
            string leftUp = (xPos - gap).ToString() + "," + yPos.ToString();
            string leftDown = (xPos).ToString() + "," + (yPos + height).ToString();

            string rightUp = (xPos + length + gap).ToString() + "," + yPos.ToString();
            string rightDown = (xPos + length).ToString() + "," + (yPos + height).ToString();

            return rightUp + " " + rightDown + " " + leftDown + " " + leftUp;
        }
    }
}