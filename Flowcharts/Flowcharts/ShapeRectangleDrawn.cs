using System.Xml;

namespace Flowcharts
{
    class ShapeRectangleDrawn
    {
        readonly XmlWriter xmlWriter = Writer.XmlWriter;
        readonly double xPos;
        readonly double yPos;
        readonly double height;
        readonly double length;
        readonly string color;


        public ShapeRectangleDrawn(double xPos, double yPos, double height, double length, string color)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
            this.color = color;
        }

        public IOPoints Draw()
        {
            xmlWriter.WriteStartElement("rect");

            var InOut = new ShapeRectangleIO(xPos, yPos, height, length).GetIO();

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
