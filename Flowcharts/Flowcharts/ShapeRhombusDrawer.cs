using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeRhombusDrawer
    {
        XmlWriter xmlWriter;
        (double x, double y) In;
        (double x, double y) Out;

        IOrientation orientation;
        double xPos;
        double yPos;
        double rhombusSize;

        public ShapeRhombusDrawer(XmlWriter xmlWriter, IOrientation orientation, double xPos, double yPos, double rhombusSize)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.rhombusSize = rhombusSize;
        }

        public ((double x, double y) In, (double x, double y) Out) Draw()
        {
            xmlWriter.WriteStartElement("polygon");

            (In, Out) = new ShapeRhombusInOutCalculator(orientation, xPos, yPos, rhombusSize).GetInOut();

            string coordinates = new ShapeRhombusCoordinatesCalculator(xPos, yPos, rhombusSize).Calculate();

            xmlWriter.WriteAttributeString("points", coordinates);
            xmlWriter.WriteAttributeString("style", "fill:white;stroke:black;stroke-width:3");
            xmlWriter.WriteEndElement();

            return (In, Out);
        }
    }
}
