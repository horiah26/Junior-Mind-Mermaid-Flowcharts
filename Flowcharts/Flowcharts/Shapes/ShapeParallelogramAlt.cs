using System;
using System.Xml;

namespace Flowcharts
{
    class ShapeParallelogramAlt : ShapePolygon
    {
        private readonly double inclination;

        public ShapeParallelogramAlt(string text) : base( text)
        {
            var lines = TextOperations.SplitText(text);
            inclination = Math.Sqrt(lines.Length) * 15;
        }

        public override string CalculateCornerPoints()
        {
            return new ShapeParallelogramAltPoints(xPos, yPos, height, length, inclination).GetPoints();
        }

        public override IOPoints GetIO()
        {
            return new ShapeParallelogramIO(xPos, yPos, height, length, inclination).GetIO();
        }
    }
}