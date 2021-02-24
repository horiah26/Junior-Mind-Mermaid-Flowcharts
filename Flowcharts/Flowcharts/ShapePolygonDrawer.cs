using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapePolygonDrawer
    {
        private XmlWriter xmlWriter;
        private IOrientation orientation;
        private double xPos;
        private double yPos;
        private double height;
        private double length;

        public ShapePolygonDrawer(XmlWriter xmlWriter, IOrientation orientation, double xPos, double yPos, double height, double length)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        public EntryExitPoints Draw(string coordinates)
        {
            xmlWriter.WriteStartElement("polygon");
            EntryExitPoints InOut = new ShapeBannerInOutCalculator(orientation, xPos, yPos, height, length).GetInOut();

            xmlWriter.WriteAttributeString("points", coordinates);
            xmlWriter.WriteAttributeString("style", "fill:white;stroke:black;stroke-width:3");
            xmlWriter.WriteEndElement();

            return InOut;
        }
    }
}
