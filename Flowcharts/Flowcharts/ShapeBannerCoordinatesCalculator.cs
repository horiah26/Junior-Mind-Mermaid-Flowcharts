using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ShapeBannerCoordinatesCalculator
    {
        private double xPos;
        private double yPos;
        private double height;
        private double length;

        public ShapeBannerCoordinatesCalculator(double xPos, double yPos, double height, double length)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        internal string Calculate()
        {
            string arrowUp = (xPos).ToString() + "," + yPos.ToString();
            string arrowMiddle = (xPos + length/5).ToString() + "," + (yPos + height / 2).ToString();
            string arrowDown = (xPos ).ToString() + "," + (yPos + height).ToString();
            string down = (xPos + length).ToString() + "," + (yPos + height).ToString();
            string up = (xPos + length).ToString() + "," + (yPos).ToString();

            return arrowUp + " " + arrowMiddle + " " + arrowDown + " " + down + " " + up;
        }
    }
}
