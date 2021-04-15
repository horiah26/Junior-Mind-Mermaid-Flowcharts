using System.Xml;

namespace Flowcharts
{
    class ShapeHexagon : ShapePolygon
    {
        public ShapeHexagon(string text) : base(text)
        {
        }

        public override (double height, double length) GetSize()
        {
            return new ShapeRectangleSize(text).GetSize();
        }

        public override string CalculateCornerPoints()
        {
            return new ShapeHexagonPoints(xPos, yPos, height, length, lines).GetPoints();
        }

        public override IOPoints GetIO()
        {
            return new ShapeHexagonIO(xPos, yPos, height, length, lines).GetIO();
        }
    }
}