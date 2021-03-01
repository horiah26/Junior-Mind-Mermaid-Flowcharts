using System;
using System.Xml;

namespace Flowcharts
{
    abstract class ShapePolygon : IShape
    {
        public IOrientation orientation;
        public XmlWriter xmlWriter;

        public double xPos;
        public double yPos;

        public double height;
        public double length;

        public string[] lines;
        readonly public string text;

        protected string coordinates;

        public ShapePolygon(XmlWriter xmlWriter, IOrientation orientation, string text)
        {
            this.orientation = orientation;
            this.xmlWriter = xmlWriter;
            this.text = text;
        }

        public (EntryExitPoints, double textAlignment) Draw()
        {
            (lines, _) = new TextSplitter(text).Split();

            (height, length) = GetSize();

            (xPos, yPos) = CalculatePosition();

            coordinates = CalculateCornerPoints();

            DrawPolygon();

            return (CalculateInOut(), length);
        }

        public virtual void DrawPolygon()
        {
            new ShapePolygonDrawer(xmlWriter).Draw(coordinates);
        }

        public (double xPos, double yPos) CalculatePosition()
        {
            var position = orientation.GetColumnRow();
            return new ShapePolygonPositionCalculator(orientation, position, lines).Calculate();
        }

        public virtual (double height, double length) GetSize()
        {
            return new ShapeRectangleSizeCalculator(text).Calculate();
        }

        public virtual string CalculateCornerPoints()
        {
            return new ShapeRectanglePointsCalculator(xPos, yPos, height, length).Calculate();
        }

        public virtual EntryExitPoints CalculateInOut()
        {
            return new ShapeRectangleInOutCalculator(orientation, xPos, yPos, height, length).CalculateInOut();
        }
    }
}