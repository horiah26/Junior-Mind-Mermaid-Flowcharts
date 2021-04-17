using System.Xml;

namespace Flowcharts
{
    class ShapeCircleDrawn
    {
        readonly XmlWriter xmlWriter = Writer.XmlWriter;
        readonly double xPos;
        readonly double yPos;
        readonly double radius;

        public ShapeCircleDrawn(double xPos, double yPos, double radius)
        {
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

            return new ShapeCircleIO(xPos, yPos, radius).GetIO(); ;
        }
    }
}
