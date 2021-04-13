using System.Xml;

namespace Flowcharts
{
    class DrawnBackArrow
    {
        public XmlWriter xmlWriter = Writer.XmlWriter;
        public Element fromElement;
        public Element toElement;
        readonly string[] points;

        public DrawnBackArrow(Element fromElement, Element toElement, string[] points)
        {
            this.fromElement = fromElement;
            this.toElement = toElement;
            this.points = points;
        }

        public void Draw()
        {
            DefineArrowHead();
            DrawBentLine();
        }

        public void DefineArrowHead()
        {
            xmlWriter.WriteStartElement("defs");
            xmlWriter.WriteStartElement("marker");
            xmlWriter.WriteAttributeString("id", "backArrowhead");
            xmlWriter.WriteAttributeString("markerWidth", "10");
            xmlWriter.WriteAttributeString("markerHeight", "7");
            xmlWriter.WriteAttributeString("fill", "gray");
            xmlWriter.WriteAttributeString("refX", "3");
            xmlWriter.WriteAttributeString("refY", "3.5");
            xmlWriter.WriteAttributeString("orient", "auto");
            xmlWriter.WriteStartElement("polygon");
            xmlWriter.WriteAttributeString("points", "0 0, 4 3.5, 0 7");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

        }

        public void DrawBentLine()
        {
            xmlWriter.WriteStartElement("polyline");
            string pointsAsCoordinates = points[0] + ", " + points[1] + " " + points[2] + ", " + points[3] + " " + points[4] + ", " + points[5];
            xmlWriter.WriteAttributeString("points", pointsAsCoordinates);

            xmlWriter.WriteAttributeString("stroke", "gray");
            xmlWriter.WriteAttributeString("fill", "none");
            xmlWriter.WriteAttributeString("stroke-width", "3");
            xmlWriter.WriteAttributeString("marker-end", "url(#backArrowhead)");
            xmlWriter.WriteEndElement();
        }
    }
}