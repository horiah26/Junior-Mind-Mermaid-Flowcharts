using System.Xml;

namespace Flowcharts
{
    class ShapeCircleDrawn
    {
        readonly XmlWriter xmlWriter;
        readonly IOrientation orientation;
        readonly int xPos;
        readonly int yPos;
        readonly int radius;

        public ShapeCircleDrawn(XmlWriter xmlWriter, IOrientation orientation, int xPos, int yPos, int radius)
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
