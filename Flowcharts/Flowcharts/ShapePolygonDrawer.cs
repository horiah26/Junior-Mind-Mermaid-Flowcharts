using System.Xml;

namespace Flowcharts
{
    class ShapePolygonDrawer
    {
        private readonly XmlWriter xmlWriter;

        public ShapePolygonDrawer(XmlWriter xmlWriter)
        {
            this.xmlWriter = xmlWriter;
        }

        public void Draw(string points)
        {
            xmlWriter.WriteStartElement("polygon");
            xmlWriter.WriteAttributeString("points", points);
            xmlWriter.WriteAttributeString("style", "fill:white;stroke:black;stroke-width:3");
            xmlWriter.WriteEndElement();
        }
    }
}