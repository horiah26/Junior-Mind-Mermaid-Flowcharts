using System.Xml;

namespace Flowcharts
{
    class ShapeCircleDrawn
    {
        readonly XmlWriter xmlWriter;
        readonly IOrientation orientation;
        readonly double xPos;
        readonly double yPos;
        readonly double radius;

        public ShapeCircleDrawn(XmlWriter xmlWriter, IOrientation orientation, double xPos, double yPos, double radius)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.radius = radius;
        }

        public IOPoints Draw()
        {
            xmlWriter.WriteStartElement("circle");

            xmlWriter.WriteAttributeString("cx", xPos.ToString());
            xmlWriter.WriteAttributeString("cy", yPos.ToString());

            xmlWriter.WriteAttributeString("r", radius.ToString().ToString());
            xmlWriter.WriteAttributeString("stroke", "black");

            xmlWriter.WriteAttributeString("stroke-width", "3");
            xmlWriter.WriteAttributeString("fill", "white");

            xmlWriter.WriteEndElement();

            return new ShapeCircleIO(orientation, xPos, yPos, radius).GetIO(); ;
        }
    }
}
