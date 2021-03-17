using System;
using System.Xml;

namespace Flowcharts
{
    class ShapeTrapezoidAlt : ShapePolygon
    {    
        private readonly double inclination;

        public ShapeTrapezoidAlt(XmlWriter xmlWriter, IOrientation orientation, string text) : base(xmlWriter, orientation, text)
        {
            lines = new SplitText(text).GetLines();
            inclination = Math.Sqrt(lines.Length) * 20;
        }

        public override string CalculateCornerPoints()
        {
            return new ShapeTrapezoidAltPoints(xPos, yPos, height, length, lines, inclination).GetPoints();
        }

        public override IOPoints GetIO()
        {
            return new ShapeParallelogramIO(orientation, xPos, yPos, height, length, lines, inclination).GetIO();
        }
    }
}