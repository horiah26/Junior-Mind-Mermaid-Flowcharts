using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;

namespace Flowcharts
{
    class ShapeArrowRectangle : ShapeRectangle
    {
        readonly Element fromElement;
        readonly Element toElement;
        readonly int numberOfLines;
        readonly string[] lines;

        public ShapeArrowRectangle(IOrientation orientation, Element fromElement, Element toElement, int numberOfLines, string[] lines) 
        {
            this.fromElement = fromElement;
            this.toElement = toElement;
            this.numberOfLines = numberOfLines;
            this.orientation = orientation;
            this.lines = lines;
        }

        public (double xPos, double yPos) GetPosition()
        {
            var maxLengthOfLine = new TextSizeCalculator(lines).Calculate();

            double xPosition = (fromElement.Out.x + toElement.In.x - (maxLengthOfLine) * 9.2) / 2;
            double yPosition = (fromElement.Out.y + toElement.In.y - (numberOfLines + 3) * 12)  / 2 ;

            return (xPosition, yPosition);
        }

        public override (double xPos, double yPos) CalculatePosition(string[] lines, (int Column, int Row) position)
        {
            return new ArrowTextPositionCalculator(orientation, position, lines).Calculate();
        }

        public override string Color()
        {
            return "fill:rgb(230,230,230);stroke-width:2;stroke:rgb(230,230,230)";
        }
    }
}
