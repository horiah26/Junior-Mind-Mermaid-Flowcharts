using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ShapeRectanglePositionCalculator
    {
        IOrientation orientation;
        string[] lines;

        (int Column, int Row) position;

        public ShapeRectanglePositionCalculator(IOrientation orientation, (int Column, int Row) position, string[] lines)
        {
            this.orientation = orientation;
            this.position = position;
            this.lines = lines;
        }

        public virtual (double rectangleXPos, double rectangleYPos) Calculate()
        {
            (int distanceFromEdge, int unitLength, int unitHeight) = new GridSpacer(orientation).GetSpacing();
            var length = new ShapeRectangleLengthCalculator(lines).Calculate();

            double rectangleXPos = distanceFromEdge + position.Column * unitLength + (unitLength - length)/2 + 3;
            double rectangleYPos = distanceFromEdge + position.Row * unitHeight - 17;

            return (rectangleXPos, rectangleYPos);
        }
    }
}
