using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeParallelogram : ShapePolygon
    {
        private readonly double inclination;

        public ShapeParallelogram(XmlWriter xmlWriter, IOrientation orientation, string text) : base(xmlWriter, orientation, text)
        {
            (string[] lines, _) = new TextSplitter(text).Split();
            inclination = Math.Sqrt(lines.Length) * 15;
        }

        public override string CalculateCornerPoints()
        {
            return new ShapeParallelogramPointsCalculator(xPos, yPos, height, length, lines, inclination).Calculate();
        }

        public override EntryExitPoints CalculateInOut()
        {
            return new ShapeParallelogramInOutCalculator(orientation, xPos, yPos, height, length, lines, inclination).CalculateInOut();
        }
    }
}