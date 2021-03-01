using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public XmlWriter xmlWriter;
        public IOrientation orientation;
        public string[] lines;

        EntryExitPoints InOut;
        readonly string text;

        public ShapeCylinder(XmlWriter xmlWriter, IOrientation orientation, string text)
        {
            this.orientation = orientation;
            this.xmlWriter = xmlWriter;
            this.text = text;
        }

        public (EntryExitPoints, double textAlignment) Draw()
        {
            (distanceFromEdge, unitLength, unitHeight) = new GridSpacer(orientation).GetSpacing();

            (string[] lines, int numberOfLines) = new TextSplitter(text).Split();
            this.lines = lines;

            (height, length) = GetSize();

            var maxline = lines.Max(x => x.Length);

            var (Column, Row) = orientation.GetColumnRow();

            (xPos, yPos) = CalculatePosition();

            DrawFigure();

            InOut = new ShapeCylinderInOutCalculator(orientation, xPos, yPos, height, length, numberOfLines).CalculateInOut();

            return (InOut, length);
        }

        public void DrawFigure()
        {
            new ShapeCylinderDrawer(xmlWriter, xPos, yPos, height, length).Draw();
        }

        public (double height, double length) GetSize()
        {
            return new ShapeRectangleSizeCalculator(text).Calculate();
        }

        public (double xPos, double yPos) CalculatePosition()
        {
            var position = orientation.GetColumnRow();
            return new ShapePolygonPositionCalculator(orientation, position, lines).Calculate();
        }
    }
}
