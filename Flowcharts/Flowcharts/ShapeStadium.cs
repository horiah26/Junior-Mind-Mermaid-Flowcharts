using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeStadium : ShapeParallelogram
    {
        public ShapeStadium(XmlWriter xmlWriter, IOrientation orientation, string text) : base(xmlWriter, orientation, text)
        {

        }

        public override void DrawPolygon()
        {
            new ShapeStadiumDrawer(xmlWriter).Draw(xPos, yPos, height, length);
        }

        public override EntryExitPoints CalculateInOut()
        {
            return new ShapeStadiumInOutCalculator(orientation, xPos, yPos, height, length, lines).CalculateInOut();
        }
    }
}