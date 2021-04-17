using System;
using System.Xml;

namespace Flowcharts
{
    class ShapeTrapezoidAlt : ShapePolygon
    {    
        private readonly double inclination;

        public ShapeTrapezoidAlt(string text) : base(text)
        {
            lines = TextOperations.SplitText(text);
            inclination = Math.Sqrt(lines.Length) * 20;
        }

        public override string CalculateCornerPoints()
        {
            return new ShapeTrapezoidAltPoints(xPos, yPos, height, length, lines, inclination).GetPoints();
        }

        public override IOPoints GetIO()
        {
            return new ShapeParallelogramIO(xPos, yPos, height, length, inclination).GetIO();
        }
    }
}