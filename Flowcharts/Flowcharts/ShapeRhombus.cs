using System;
using System.Linq;
using System.Xml;

namespace Flowcharts
{
    class ShapeRhombus : IShape
    {
        readonly int rectangleLength = 0;
        private int distanceFromEdge;
        private int unitLength;
        private int unitHeight;

        (double x, double y) In;
        (double x, double y) Out;

        double rhombusXPos;
        double rhombusYPos;
        double rhombusSize;

        public ShapeRhombus()
        {
        }

        public ((double x, double y) In, (double x, double y) Out, int boxWidth) Draw(XmlWriter xmlWriter, IOrientation orientation, string Text)
        {
            (distanceFromEdge, unitLength, unitHeight) = new GridSpacer(orientation).GetSpacing();

            (string[] lines, int numberOfLines) = new TextSplitter(Text).Split();

            rhombusSize = new ShapeRhombusSizeCalculator(lines).Calculate();

            var maxline = lines.Max(x => x.Length);

            var (Column, Row) = orientation.GetColumnRow(); 

            rhombusXPos = distanceFromEdge + Column * unitLength + (unitLength - rhombusSize/3) / 2 + maxline * 4/3 - (numberOfLines - 1) * 7;
            rhombusYPos = distanceFromEdge + Row * unitHeight - rhombusSize/2 +  numberOfLines * 5;

            (In, Out) = new ShapeRhombusDrawer(xmlWriter, orientation, rhombusXPos, rhombusYPos, rhombusSize).Draw();

            return (In, Out, rectangleLength);
        }
    }
}