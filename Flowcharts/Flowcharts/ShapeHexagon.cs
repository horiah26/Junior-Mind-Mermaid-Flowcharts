using System;
using System.Xml;

namespace Flowcharts
{
    class ShapeHexagon : ShapePolygon
    {
        public ShapeHexagon(XmlWriter xmlWriter, IOrientation orientation, string text) : base(xmlWriter, orientation, text)
        {
        }

        public override (double height, double length) GetSize()
        {
            return new ShapeHexagonSize(lines).Calculate();
        }

        public override string CalculateCornerPoints()
        {
            return new ShapeHexagonPoints(xPos, yPos, height, length, lines).GetPoints();
        }

        public override IOPoints GetIO()
        {
            return new ShapeHexagonIO(orientation, xPos, yPos, height, length, lines).GetIO();
        }
    }
}