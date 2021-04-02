using System;
using System.Xml;

namespace Flowcharts
{
    class ShapeParallelogramAlt : ShapePolygon
    {
        private readonly double inclination;

        public ShapeParallelogramAlt(XmlWriter xmlWriter, IOrientation orientation, string text) : base(xmlWriter, orientation, text)
        {
            lines = new SplitText(text).GetLines();
            inclination = Math.Sqrt(lines.Length) * 15;
        }

        public override string CalculateCornerPoints()
        {
            return new ShapeParallelogramAltPoints(xPos, yPos, height, length, lines, inclination).GetPoints();
        }

        public override IOPoints GetIO()
        {
            return new ShapeParallelogramIO(orientation, xPos, yPos, height, length, inclination).GetIO();
        }
    }
}