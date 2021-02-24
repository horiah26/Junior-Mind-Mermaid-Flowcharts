﻿using System.Xml;

namespace Flowcharts
{
    internal class ShapeBannerDrawer
    {
        private XmlWriter xmlWriter;
        private IOrientation orientation;
        private double xPos;
        private double yPos;
        private double height;
        private double length;

        public ShapeBannerDrawer(XmlWriter xmlWriter, IOrientation orientation, double xPos, double yPos, double height, double length)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        public EntryExitPoints Draw()
        {
            xmlWriter.WriteStartElement("polygon");
            EntryExitPoints InOut = new ShapeBannerInOutCalculator(orientation, xPos, yPos, height, length).GetInOut();
            string coordinates = GetCoordinates();

            xmlWriter.WriteAttributeString("points", coordinates);
            xmlWriter.WriteAttributeString("style", "fill:white;stroke:black;stroke-width:3");
            xmlWriter.WriteEndElement();

            return InOut;
        }

        public string GetCoordinates()
        {
            return new ShapeBannerCoordinatesCalculator(xPos, yPos, height, length).Calculate();
        }
    }
}