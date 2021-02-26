using System;
using System.Xml;

namespace Flowcharts
{
    class ShapeParallelogramAlt : ShapePolygon
    {
        private readonly double inclination;

        public ShapeParallelogramAlt(XmlWriter xmlWriter, IOrientation orientation, string text) : base(xmlWriter, orientation, text)
        {
            (string[] lines, _) = new TextSplitter(text).Split();
            inclination = Math.Sqrt(lines.Length) * 15;
        }

        public override string CalculateCornerPoints()
        {
            return new ShapeParallelogramAltPointsCalculator(xPos, yPos, height, length, lines, inclination).Calculate();
        }

        public override EntryExitPoints CalculateInOut()
        {
            return new ShapeParallelogramInOutCalculator(orientation, xPos, yPos, height, length, lines, inclination).CalculateInOut();
        }
    }
}