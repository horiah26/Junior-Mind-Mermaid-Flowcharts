using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class ArrowTextPositionCalculator
    {
        readonly IOrientation orientation;
        readonly string[] lines;

        (int Column, int Row) position;

        public ArrowTextPositionCalculator(IOrientation orientation, (int Column, int Row) position, string[] lines)
        {
            this.orientation = orientation;
            this.position = position;
            this.lines = lines;
        }

        public virtual (double xPos, double yPos) Calculate()
        {
            (int distanceFromEdge, int unitLength, int unitHeight) = new GridSpacer(orientation).GetSpacing();
            var rectangleLength =  new TextSizeCalculator(lines).Calculate();
            double xPos = distanceFromEdge + position.Column * unitLength + (unitLength - rectangleLength) / 2;
            double yPos = distanceFromEdge + position.Row * unitHeight - 17;

            return (xPos, yPos);
        }

    }
}
