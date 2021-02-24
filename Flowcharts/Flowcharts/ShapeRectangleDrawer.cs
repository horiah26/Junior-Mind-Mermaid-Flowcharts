using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeRectangleDrawer
    {
        readonly XmlWriter xmlWriter;

        (double x, double y) In;
        (double x, double y) Out;
        readonly IOrientation orientation;
        readonly double xPos;
        readonly double yPos;
        readonly int rectangleHeight;
        readonly int rectangleLength;
        readonly string color;


        public ShapeRectangleDrawer(XmlWriter xmlWriter, IOrientation orientation, double xPos, double yPos, int rectangleHeight, int rectangleLength, string color)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.rectangleHeight = rectangleHeight;
            this.rectangleLength = rectangleLength;
            this.color = color;
        }
        public EntryExitPoints Draw()
        {
            xmlWriter.WriteStartElement("rect");

            (In, Out) = new ShapeRectangleInOutCalculator(orientation, xPos, yPos, rectangleHeight, rectangleLength).GetInOut();

            xmlWriter.WriteAttributeString("x", xPos.ToString());
            xmlWriter.WriteAttributeString("y", yPos.ToString());

            RoundCorners();

            xmlWriter.WriteAttributeString("width", rectangleLength.ToString());
            xmlWriter.WriteAttributeString("height", rectangleHeight.ToString());

            xmlWriter.WriteAttributeString("style", color);

            xmlWriter.WriteEndElement();

            return new EntryExitPoints(In, Out);
        }

        public virtual void RoundCorners()
        {
        }
    }
}
