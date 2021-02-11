using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{


    class ArrowDrawer
    {
        public XmlWriter xmlWriter;
        public Element fromElement;
        public Element toElement;
        string[] coordinates;

        public ArrowDrawer(XmlWriter xmlWriter, Element fromElement, Element toElement, string[] coordinates)
        {
            this.xmlWriter = xmlWriter;
            this.fromElement = fromElement;
            this.toElement = toElement;
            this.coordinates = coordinates;
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

            xmlWriter.WriteAttributeString("x1", coordinates[0]);
            xmlWriter.WriteAttributeString("y1", coordinates[1]);
            xmlWriter.WriteAttributeString("x2", coordinates[2]);
            xmlWriter.WriteAttributeString("y2", coordinates[3]);

            xmlWriter.WriteAttributeString("stroke", "#000");
            xmlWriter.WriteAttributeString("stroke-width", "3");
            xmlWriter.WriteAttributeString("marker-end", "url(#arrowhead)");
            xmlWriter.WriteEndElement();
        }

    }
}
