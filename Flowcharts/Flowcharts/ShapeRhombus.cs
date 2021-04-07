using System.Xml;

namespace Flowcharts
{
    class ShapeRhombus : ShapePolygon
    {
        public ShapeRhombus(XmlWriter xmlWriter, IOrientation orientation, string text) : base(xmlWriter, orientation, text)
        {
        }

        public override (IOPoints, double textAlignment) Draw()
        {
            lines = new SplitText(text).GetLines();

            (height, length) = GetSize();

            (xPos, yPos) = CalculatePosition();

            coordinates = CalculateCornerPoints();

            DrawPolygon();


            return (GetIO(), length * 0.9);
        }

        public override string CalculateCornerPoints()
        {
            var numberOfLines = lines.Length;
            return new ShapeRhombusPoints(xPos, yPos, height, length, numberOfLines).GetPoints();
        }

        public override IOPoints GetIO()
        {
            return new ShapeRhombusIO(orientation, xPos, yPos, height, length, lines).GetIO();
        }
    }
}
