using System;
using System.Xml;

namespace Flowcharts
{
    class ShapeParallelogram : ShapePolygon
    {
        private readonly double inclination;

        public ShapeParallelogram(XmlWriter xmlWriter, IOrientation orientation, string text) : base(xmlWriter, orientation, text)
        {
            var lines = new SplitText(text).GetLines();
            inclination = Math.Sqrt(lines.Length) * 15;
        }

        public override string CalculateCornerPoints()
        {
            return new ShapeParallelogramPoints(xPos, yPos, height, length, lines, inclination).GetPoints();
        }

        public override IOPoints GetIO()
        {
            return new ShapeParallelogramIO(orientation, xPos, yPos, height, length, lines, inclination).GetIO();
        }
    }
}