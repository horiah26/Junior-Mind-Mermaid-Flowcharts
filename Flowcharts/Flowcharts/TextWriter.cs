using System.Linq;
using System.Xml;
using System.Collections.Generic;

namespace Flowcharts
{
    public class TextWriter
    {
        readonly XmlWriter xmlWriter;
        readonly double xPosition;
        readonly double yPosition;
        readonly string[] lines;

        public TextWriter(XmlWriter xmlWriter, double xPosition, double yPosition, string[] lines) 
        {
            this.xmlWriter = xmlWriter;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.lines = lines;
        }

        public void Write()
        {
            int spaceBetweenLines = 17;

            var linePositionList = CalculatePosition(lines);
            var maxDifference = linePositionList.Max(x => x.gap);

            xmlWriter.WriteStartElement("text");
            xmlWriter.WriteAttributeString("x", (xPosition + maxDifference - linePositionList[0].gap).ToString());
            xmlWriter.WriteAttributeString("y", yPosition.ToString());
            xmlWriter.WriteAttributeString("fill", "black");
            xmlWriter.WriteString(lines[0]);

            for (int i = 1; i < linePositionList.Count(); i++)
            {
                xmlWriter.WriteStartElement("tspan");
                xmlWriter.WriteAttributeString("x", (xPosition + maxDifference - linePositionList[i].gap).ToString());
                xmlWriter.WriteAttributeString("y", (yPosition + i * spaceBetweenLines).ToString());
                xmlWriter.WriteString(linePositionList[i].line);
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
        }

        public List<(string line, double gap)> CalculatePosition(string[] lines)
        {
            List<(string line, double gap)> list = new List<(string line, double gap)>() { };

            foreach (var line in lines)
            {
                double gap = new TextSizeCalculator(new string[] { line }).Calculate();
                list.Add((line, gap));
            }

            return list;
        }
    }
}
