using System.Xml;

namespace Flowcharts
{


    class ArrowDrawer
    {
        public XmlWriter xmlWriter;
        public Element fromElement;
        public Element toElement;
        readonly string[] points;

        public ArrowDrawer(XmlWriter xmlWriter, Element fromElement, Element toElement, string[] points)
        {
            this.xmlWriter = xmlWriter;
            this.fromElement = fromElement;
            this.toElement = toElement;
            this.points = points;
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

            xmlWriter.WriteAttributeString("x1", points[0]);
            xmlWriter.WriteAttributeString("y1", points[1]);
            xmlWriter.WriteAttributeString("x2", points[2]);
            xmlWriter.WriteAttributeString("y2", points[3]);

            xmlWriter.WriteAttributeString("stroke", "#000");
            xmlWriter.WriteAttributeString("stroke-width", "3");
            xmlWriter.WriteAttributeString("marker-end", "url(#arrowhead)");
            xmlWriter.WriteEndElement();
        }

    }
}
