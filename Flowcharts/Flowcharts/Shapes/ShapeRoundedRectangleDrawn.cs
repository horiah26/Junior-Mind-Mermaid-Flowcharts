﻿using System.Xml;

namespace Flowcharts
{
    internal class ShapeRoundedRectangleDrawn
    {
        private readonly XmlWriter xmlWriter;

        public double xPos;
        public double yPos;

        public double height;
        public double length;

        public ShapeRoundedRectangleDrawn(XmlWriter xmlWriter, double xPos, double yPos, double height, double length)
        {
            this.xmlWriter = xmlWriter;
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        public void Draw()
        {
            xmlWriter.WriteStartElement("rect");

            xmlWriter.WriteAttributeString("x", xPos.ToString());
            xmlWriter.WriteAttributeString("y", (yPos - height / 2).ToString());

            xmlWriter.WriteAttributeString("rx", 7.ToString());
            xmlWriter.WriteAttributeString("ry", 7.ToString());

            xmlWriter.WriteAttributeString("width", length.ToString());
            xmlWriter.WriteAttributeString("height", height.ToString());

            xmlWriter.WriteAttributeString("style", "fill:rgb(255,255,255);stroke-width:2;stroke:rgb(0,0,0)");

            xmlWriter.WriteEndElement();
        }
    }
}