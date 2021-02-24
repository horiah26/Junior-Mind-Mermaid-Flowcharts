using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeHexagon : IShape
    {
        public IOrientation orientation;
        public XmlWriter xmlWriter;

        public double xPos;
        public double yPos;
        public double height;
        public double length;

        string[] lines;

        public ShapeHexagon(){}

        public (EntryExitPoints, int textAlignment) Draw(XmlWriter xmlWriter, IOrientation orientation, string Text)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;

            (lines, _) = new TextSplitter(Text).Split();

            (height, length) = GetSize();

            (xPos, yPos) = CalculatePosition();

            Draw();

            return (GetInOut(), Convert.ToInt32(length));
        }

        private (double height, double length) GetSize()
        {
            return new ShapeHexagonSizeCalculator(lines).Calculate();
        }

        private EntryExitPoints Draw()
        {
            string coorinates = CalculateCornerPoints();
            return new ShapePolygonDrawer(xmlWriter, orientation, xPos, yPos, height, length).Draw(coorinates);
        }

        private (double xPos, double yPos) CalculatePosition()
        {
            var position = orientation.GetColumnRow();
            return new ShapePolygonPositionCalculator(orientation, position, lines).Calculate();
        }

        protected virtual string CalculateCornerPoints()
        {
            return new ShapeHexagonCoordinatesCalculator(xPos, yPos, height, length, lines).Calculate();
        }

        public EntryExitPoints GetInOut()
        {
           return new ShapeHexagonInOutCalculator(orientation, xPos, yPos, height, length, lines).GetInOut();
        }
    }
}