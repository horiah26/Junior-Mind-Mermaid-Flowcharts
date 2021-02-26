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
            return new ShapeHexagonSizeCalculator(lines).Calculate();
        }

        public override string CalculateCornerPoints()
        {
            return new ShapeHexagonPointsCalculator(xPos, yPos, height, length, lines).Calculate();
        }

        public override EntryExitPoints CalculateInOut()
        {
            return new ShapeHexagonInOutCalculator(orientation, xPos, yPos, height, length, lines).CalculateInOut();
        }
    }
}