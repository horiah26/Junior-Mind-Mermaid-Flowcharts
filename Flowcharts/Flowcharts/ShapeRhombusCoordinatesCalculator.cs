using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ShapeRhombusCoordinatesCalculator
    {
        readonly double rhombusXPos;
        readonly double rhombusYPos;
        readonly double rhombusSize;

        public ShapeRhombusCoordinatesCalculator(double rhombusXPos, double rhombusYPos, double rhombusSize)
        {
            this.rhombusXPos = rhombusXPos;
            this.rhombusYPos = rhombusYPos;
            this.rhombusSize = rhombusSize;
        }

        public string Calculate()
        {
            string left = rhombusXPos.ToString() + "," + (rhombusYPos + rhombusSize / 2).ToString();
            string down = (rhombusXPos + rhombusSize / 2).ToString() + "," + (rhombusYPos + rhombusSize).ToString();
            string up = (rhombusXPos + rhombusSize / 2).ToString() + "," + rhombusYPos.ToString();
            string right = (rhombusXPos + rhombusSize).ToString() + "," + (rhombusYPos + rhombusSize / 2).ToString();

            return up + " " + left + " " + down + " " + right;
        }
    }
}
