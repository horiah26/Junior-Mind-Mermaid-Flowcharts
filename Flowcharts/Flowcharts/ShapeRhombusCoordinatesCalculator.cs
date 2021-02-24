using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ShapeRhombusCoordinatesCalculator
    {
        readonly double xPos;
        readonly double yPos;
        readonly double rhombusSize;

        public ShapeRhombusCoordinatesCalculator(double xPos, double yPos, double rhombusSize)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.rhombusSize = rhombusSize;
        }

        public string Calculate()
        {
            string left = xPos.ToString() + "," + (yPos + rhombusSize / 2).ToString();
            string down = (xPos + rhombusSize / 2).ToString() + "," + (yPos + rhombusSize).ToString();
            string up = (xPos + rhombusSize / 2).ToString() + "," + yPos.ToString();
            string right = (xPos + rhombusSize).ToString() + "," + (yPos + rhombusSize / 2).ToString();

            return up + " " + left + " " + down + " " + right;
        }
    }
}
