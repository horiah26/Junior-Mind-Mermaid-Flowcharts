﻿using System.Linq;
using System.Xml;

namespace Flowcharts
{
    class ShapeCylinder : IShape
    {
        public int distanceFromEdge;
        public int unitLength;
        public int unitHeight;

        public double xPos;
        public double yPos;

        public double height;
        public double length;

        public XmlWriter xmlWriter = Writer.XmlWriter;
        public IOrientation orientation = StaticOrientation.Orientation;
        public string[] lines;

        IOPoints InOut;
        readonly string text;

        public ShapeCylinder(string text)
        {
            this.text = text;
        }

        public (IOPoints, double textAlignment) Draw()
        {
            (distanceFromEdge, unitLength, unitHeight) = ElementOperations.GetSpacing();

            lines = TextOperations.SplitText(text);
            var numberOfLines = lines.Length;

            (height, length) = GetSize();

            var maxline = lines.Max(x => x.Length);

            var (Column, Row) = orientation.GetColumnRow();

            (xPos, yPos) = CalculatePosition();
            yPos -= height / 2; ;
            DrawFigure();

            InOut = new ShapeCylinderIO(xPos, yPos, height, length, numberOfLines).GetIO();

            return (InOut, length);
        }

        public void DrawFigure()
        {
            new ShapeCylinderDrawn(xPos, yPos, height, length).Draw();
        }

        public (double height, double length) GetSize()
        {
            return new ShapeRectangleSize(text).GetSize();
        }

        public (double xPos, double yPos) CalculatePosition()
        {
            var position = orientation.GetColumnRow();
            return new ShapePolygonPosition(position, lines).GetPosition();
        }
    }
}
