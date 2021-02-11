using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeRectangleDrawer
    {
        XmlWriter xmlWriter;

        (double x, double y) In;
        (double x, double y) Out;

        IOrientation orientation;
        double xPos;
        double yPos;

        int rectangleHeight;
        int rectangleLength;

        string color;


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
        public ((double x, double y) In, (double x, double y) Out) Draw()
        {
            xmlWriter.WriteStartElement("rect");

            (In, Out) = new ShapeRectangleInOutCalculator(orientation, xPos, yPos, rectangleHeight, rectangleLength).GetInOut();

            xmlWriter.WriteAttributeString("x", xPos.ToString());
            xmlWriter.WriteAttributeString("y", yPos.ToString());

            xmlWriter.WriteAttributeString("rx", 7.ToString());
            xmlWriter.WriteAttributeString("ry", 7.ToString());

            xmlWriter.WriteAttributeString("width", rectangleLength.ToString());
            xmlWriter.WriteAttributeString("height", rectangleHeight.ToString());

            xmlWriter.WriteAttributeString("style", color);

            xmlWriter.WriteEndElement();

            return (In, Out);
        }
    }
}
