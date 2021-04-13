using System;
using System.Xml;

namespace Flowcharts
{
    class ShapeTrapezoid : ShapePolygon
    {    
        private readonly double inclination;

        public ShapeTrapezoid(string text) : base(text)
        {
            lines = TextOperations.SplitText(text);
            inclination = Math.Sqrt(lines.Length) * 20;
        }

        public override string CalculateCornerPoints()
        {
            return new ShapeTrapezoidPoints(xPos, yPos, height, length, lines, inclination).GetPoints();
        }

        public override IOPoints GetIO()
        {
            return new ShapeParallelogramIO(orientation, xPos, yPos, height, length, inclination).GetIO();
        }
    }
}