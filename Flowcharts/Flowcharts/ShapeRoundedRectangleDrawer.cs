using System.Xml;

namespace Flowcharts
{
    internal class ShapeRoundedRectangleDrawer
    {
        private readonly XmlWriter xmlWriter;

        public double xPos;
        public double yPos;

        public double height;
        public double length;

        public ShapeRoundedRectangleDrawer(XmlWriter xmlWriter, double xPos, double yPos, double height, double length)
        {
            this.xmlWriter = xmlWriter;
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        public void Draw(string points)
        {
            xmlWriter.WriteStartElement("rect");

            xmlWriter.WriteAttributeString("x", xPos.ToString());
            xmlWriter.WriteAttributeString("y", yPos.ToString());

            xmlWriter.WriteAttributeString("rx", 10.ToString());
            xmlWriter.WriteAttributeString("ry", 10.ToString());

            xmlWriter.WriteAttributeString("width", length.ToString());
            xmlWriter.WriteAttributeString("height", height.ToString());

            Color();

            xmlWriter.WriteEndElement();
        }

        virtual public void Color()
        {
            xmlWriter.WriteAttributeString("style", "fill:rgb(255,255,255);stroke-width:2;stroke:rgb(0,0,0)");
        }
    }
}