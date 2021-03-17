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
            return new ShapeSubroutinePoints(xPos, yPos, height, length).GetPoints();
        }

        public override IOPoints GetIO()
        {
            return new ShapeSubroutineIO(orientation, xPos, yPos, height, length).GetIO();
        }
    }
}