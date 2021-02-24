using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeRoundedRectangleDrawer : ShapeRectangleDrawer
    {
        XmlWriter xmlWriter;
        public ShapeRoundedRectangleDrawer(XmlWriter xmlWriter, IOrientation orientation, double xPos, double yPos, int rectangleHeight, int rectangleLength, string color) : base(xmlWriter, orientation, xPos, yPos, rectangleHeight, rectangleLength, color)
        {
            this.xmlWriter = xmlWriter;
        }

        public override void RoundCorners()
        {
            xmlWriter.WriteAttributeString("rx", 8.ToString());
            xmlWriter.WriteAttributeString("ry", 8.ToString());
        }
    }
}
