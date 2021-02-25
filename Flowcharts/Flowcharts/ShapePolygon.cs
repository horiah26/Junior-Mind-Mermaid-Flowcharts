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

        string text;

        public ShapePolygon(XmlWriter xmlWriter, IOrientation orientation, string text)
        {
            this.orientation = orientation;
            this.xmlWriter = xmlWriter;
            this.text = text;
        }

        public (EntryExitPoints, int textAlignment) Draw()
        {
            (lines, _) = new TextSplitter(text).Split();

            (height, length) = GetSize();

            (xPos, yPos) = CalculatePosition();

            DrawPolygon();

            return (GetInOut(), Convert.ToInt32(length));
        }

        public void DrawPolygon()
        {
            string coorinates = CalculateCornerPoints();
            new ShapePolygonDrawer(xmlWriter).Draw(coorinates);
        }

        public (double xPos, double yPos) CalculatePosition()
        {
            var position = orientation.GetColumnRow();
            return new ShapePolygonPositionCalculator(orientation, position, lines).Calculate();
        }

        public virtual (double height, double length) GetSize()
        {
            return new ShapeHexagonSizeCalculator(lines).Calculate();
        }

        public virtual string CalculateCornerPoints()
        {
            return new ShapeHexagonPointsCalculator(xPos, yPos, height, length, lines).Calculate();
        }

        public virtual EntryExitPoints GetInOut()
        {
            return new ShapeHexagonInOutCalculator(orientation, xPos, yPos, height, length, lines).GetInOut();
        }
    }
}