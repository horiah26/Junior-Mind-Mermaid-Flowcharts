using System.Xml;

namespace Flowcharts
{
    class Arrow
    {
        private readonly XmlWriter xmlWriter;
        public Element fromElement;
        public Element toElement;

        public Arrow(XmlWriter xmlWriter, Element fromElement, Element toElement)
        {
            this.xmlWriter = xmlWriter;
            this.fromElement = fromElement;
            this.toElement = toElement;
        }

        public void Draw()
        {
            xmlWriter.WriteStartElement("defs");
            xmlWriter.WriteStartElement("marker");
            xmlWriter.WriteAttributeString("id", "arrowhead");
            xmlWriter.WriteAttributeString("markerWidth", "10");
            xmlWriter.WriteAttributeString("markerHeight", "7");
            xmlWriter.WriteAttributeString("refX", "3");
            xmlWriter.WriteAttributeString("refY", "3.5");
            xmlWriter.WriteAttributeString("orient", "auto");
            xmlWriter.WriteStartElement("polygon");
            xmlWriter.WriteAttributeString("points", "0 0, 4 3.5, 0 7");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("line");
            xmlWriter.WriteAttributeString("x1", fromElement.Out.x.ToString());
            xmlWriter.WriteAttributeString("y1", fromElement.Out.y.ToString());
            xmlWriter.WriteAttributeString("x2", toElement.In.x.ToString());
            xmlWriter.WriteAttributeString("y2", toElement.In.y.ToString());
            xmlWriter.WriteAttributeString("stroke", "#000");
            xmlWriter.WriteAttributeString("stroke-width", "3");
            xmlWriter.WriteAttributeString("marker-end", "url(#arrowhead)");
            xmlWriter.WriteEndElement();
        }
    }
}