using System.Xml;

namespace Flowcharts
{
    class ShapeCircleDrawer
    {
        readonly XmlWriter xmlWriter;
        readonly IOrientation orientation;
        readonly int xPos;
        readonly int yPos;
        readonly int radius;

        public ShapeCircleDrawer(XmlWriter xmlWriter, IOrientation orientation, int xPos, int yPos, int radius)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.radius = radius;
        }

        public EntryExitPoints Draw()
        {
            xmlWriter.WriteStartElement("circle");

            xmlWriter.WriteAttributeString("cx", xPos.ToString());
            xmlWriter.WriteAttributeString("cy", yPos.ToString());

            xmlWriter.WriteAttributeString("r", radius.ToString().ToString());
            xmlWriter.WriteAttributeString("stroke", "black");

            xmlWriter.WriteAttributeString("stroke-width", "3");
            xmlWriter.WriteAttributeString("fill", "white");

            xmlWriter.WriteEndElement();

            return new ShapeCirlceInOutCalculator(orientation, xPos, yPos, radius).CalculateInOut(); ;
        }
    }
}
