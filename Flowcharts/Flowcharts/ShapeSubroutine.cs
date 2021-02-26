using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeSubroutine : ShapePolygon
    {
        public ShapeSubroutine(XmlWriter xmlWriter, IOrientation orientation, string text) : base(xmlWriter, orientation, text)
        {
        }


        public override string CalculateCornerPoints()
        {
            return new ShapeSubroutinePointsCalculator(xPos, yPos, height, length).Calculate();
        }

        public override EntryExitPoints CalculateInOut()
        {
            return new ShapeSubroutineInOutCalculator(orientation, xPos, yPos, height, length).CalculateInOut();
        }
    }
}