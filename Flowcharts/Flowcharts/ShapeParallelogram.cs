using System;
using System.Xml;

namespace Flowcharts
{
    class ShapeParallelogram : ShapePolygon
    {
        private readonly double inclination;

        public ShapeParallelogram(string text) : base(text)
        {
            var lines = TextOperations.SplitText(text);
            inclination = Math.Sqrt(lines.Length) * 15;
        }

        public override string CalculateCornerPoints()
        {
            return new ShapeParallelogramPoints(xPos, yPos, height, length, inclination).GetPoints();
        }

        public override IOPoints GetIO()
        {
            return new ShapeParallelogramIO(orientation, xPos, yPos, height, length, inclination).GetIO();
        }
    }
}