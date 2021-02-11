using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;

namespace Flowcharts
{
    class ShapeArrowRectangle : ShapeRectangle
    {
        private XmlWriter xmlWriter;
        Element fromElement;
        Element toElement;
        int numberOfLines;
        string[] lines;
        IOrientation orientation;

        public ShapeArrowRectangle(XmlWriter xmlWriter, IOrientation orientation, Element fromElement, Element toElement, int numberOfLines, string[] lines) 
        {
            this.xmlWriter = xmlWriter;
            this.fromElement = fromElement;
            this.toElement = toElement;
            this.numberOfLines = numberOfLines;
            this.orientation = orientation;
            this.lines = lines;
        }

        public (double rectangleXPos, double rectangleYPos) GetPosition((int Column, int Row) position)
        {
            var maxLengthOfLine = new RectangleLengthCalculator(lines).Calculate();

            double xPosition = (fromElement.Out.x + toElement.In.x - (maxLengthOfLine) * 9.2) / 2;
            double yPosition = (fromElement.Out.y + toElement.In.y - (numberOfLines + 3) * 12)  / 2 ;

            return (xPosition, yPosition);
        }

        public override (double, double) CalculatePosition(string[] lines, (int Column, int Row) position)
        {
            return new ArrowTextPositionCalculator(orientation, position, lines).Calculate();
        }

        public override string Color()
        {
            return "fill:rgb(230,230,230);stroke-width:2;stroke:rgb(230,230,230)";
        }
    }
}
