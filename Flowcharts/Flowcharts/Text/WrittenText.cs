﻿using System.Linq;
using System.Xml;

namespace Flowcharts
{
    public class WrittenText
    {
        readonly public XmlWriter xmlWriter = Writer.XmlWriter;
        readonly double xPosition;
        readonly double yPosition;
        readonly string[] lines;

        public WrittenText(double xPosition, double yPosition, string[] lines) 
        {
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
            Color();
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

        public virtual void Color()
        {
            xmlWriter.WriteAttributeString("fill", "black");
        }

    }
}
