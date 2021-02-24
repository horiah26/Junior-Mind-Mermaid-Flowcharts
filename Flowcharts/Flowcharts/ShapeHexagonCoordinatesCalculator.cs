using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ShapeHexagonCoordinatesCalculator
    {
        private double xPos;
        private double yPos;
        private double height;
        private double length;
        string[] lines;

        public ShapeHexagonCoordinatesCalculator(double xPos, double yPos, double height, double length, string[] lines)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
            this.lines = lines;
        }

        internal string Calculate()
        {
            int numberOfLines = lines.Length;

            string rightUp = (xPos).ToString() + "," + yPos.ToString();
            string rightMiddle = (xPos - numberOfLines * 10).ToString() + "," + (yPos + height / 2).ToString();
            string rightDown = (xPos).ToString() + "," + (yPos + height).ToString();

            string leftUp = (xPos + length).ToString() + "," + yPos.ToString();
            string leftMiddle = (xPos + numberOfLines * 10 + length).ToString() + "," + (yPos + height / 2).ToString();
            string leftDown = (xPos + length).ToString() + "," + (yPos + height).ToString();

            return rightUp + " " + rightMiddle + " " + rightDown + " " + leftDown + " " + leftMiddle + " " + leftUp;
        }
    }
}