using System.Xml;

namespace Flowcharts
{
    class ShapeRectangleDrawn
    {
        readonly XmlWriter xmlWriter;

        readonly IOrientation orientation;
        readonly double xPos;
        readonly double yPos;
        readonly double height;
        readonly double length;
        readonly string color;


        public ShapeRectangleDrawn(XmlWriter xmlWriter, IOrientation orientation, double xPos, double yPos, double height, double length, string color)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
            this.color = color;
        }

        public IOPoints Draw()
        {
            xmlWriter.WriteStartElement("rect");

            var InOut = new ShapeRectangleIO(orientation, xPos, yPos, height, length).GetIO();

            xmlWriter.WriteAttributeString("x", xPos.ToString());
            xmlWriter.WriteAttributeString("y", yPos.ToString());

            xmlWriter.WriteAttributeString("width", length.ToString());
            xmlWriter.WriteAttributeString("height", height.ToString());

            xmlWriter.WriteAttributeString("style", color);

            xmlWriter.WriteEndElement();

            return InOut;
        }
    }
}
