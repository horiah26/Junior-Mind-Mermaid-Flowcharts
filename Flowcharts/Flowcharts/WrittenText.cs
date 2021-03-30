using System.Linq;
using System.Xml;
using System.Collections.Generic;

namespace Flowcharts
{
    public class WrittenText
    {
        readonly XmlWriter xmlWriter;
        readonly double xPosition;
        readonly double yPosition;
        readonly string[] lines;

        public WrittenText(XmlWriter xmlWriter, double xPosition, double yPosition, string[] lines) 
        {
            this.xmlWriter = xmlWriter;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.lines = lines;
        }

        public void Write()
        {
            int spaceBetweenLines = 17;

            xmlWriter.WriteStartElement("text");
            xmlWriter.WriteAttributeString("x", (xPosition).ToString());
            xmlWriter.WriteAttributeString("y", yPosition.ToString());
            xmlWriter.WriteAttributeString("fill", "black");
            xmlWriter.WriteString(lines[0]);

            for (int i = 1; i < lines.Count(); i++)
            {
                xmlWriter.WriteStartElement("tspan");
                xmlWriter.WriteAttributeString("x", (xPosition).ToString());
                xmlWriter.WriteAttributeString("y", (yPosition + i * spaceBetweenLines).ToString());
                xmlWriter.WriteString(lines[i]);
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
        }

    }
}
