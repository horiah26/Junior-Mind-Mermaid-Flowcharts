using System;
using System.Linq;
using System.Xml;

namespace Flowcharts
{
    public class Arrow
    {
        public XmlWriter xmlWriter;
        public Element fromElement;
        public Element toElement;
        public string text = null;
        int rectangleWidth = 0;

        public Arrow(XmlWriter xmlWriter, Element fromElement, Element toElement)
        {
            this.xmlWriter = xmlWriter;
            this.fromElement = fromElement;
            this.toElement = toElement;
        }

        public Arrow(XmlWriter xmlWriter, Element fromElement, Element toElement, string text)
        {
            this.xmlWriter = xmlWriter;
            this.fromElement = fromElement;
            this.toElement = toElement;
            this.text = text;
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
            SetInAndOut();
            xmlWriter.WriteAttributeString("stroke", "#000");
            xmlWriter.WriteAttributeString("stroke-width", "3");
            xmlWriter.WriteAttributeString("marker-end", "url(#arrowhead)");
            xmlWriter.WriteEndElement();

            if (text == null)
            {
                return;
            }

            int linesOfText = 0;
            var lines = SplitWords(text, ref linesOfText);

            DrawBox(linesOfText, lines);
            WriteText(linesOfText, lines);

        }

        public void WriteText(int linesOfText, string[] lines)
        {
            double xPosition = (fromElement.Out.x + toElement.In.x - lines[0].Length) / 2;
            double yPosition = (fromElement.Out.y + toElement.In.y - linesOfText + 10) / 2;

            WriteText textWriter = new WriteText(xmlWriter, xPosition, yPosition, lines);
            textWriter.Write();
        }

        public void DrawBox(int linesOfText, string[] lines)
        {
            int rectangleHeight = 40 + (linesOfText - 1) * 17;
            int rectangleWidth = ResizeBox(text);

            double xPosition = (fromElement.Out.x + toElement.In.x - lines[0].Length * 5) / 2 - 5;
            double yPosition = (fromElement.Out.y + toElement.In.y - linesOfText) / 2 - 20;

            DrawBox boxDrawer = new DrawBox(xmlWriter, xPosition, yPosition, rectangleWidth, rectangleHeight, fromElement.orientation, "gray");
            boxDrawer.Draw();
        }

        string[] SplitWords(string text, ref int textLines)
        {
            var charCount = 0;
            var maxLineLength = 23;

            var split = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .GroupBy(w => (charCount += w.Length + 1) / maxLineLength)
                            .Select(g => string.Join(" ", g)).ToArray();

            textLines = split.Length;
            return split;
        }

        virtual public void SetInAndOut()
        {
            xmlWriter.WriteAttributeString("x1", fromElement.Out.x.ToString());
            xmlWriter.WriteAttributeString("y1", fromElement.Out.y.ToString());
            xmlWriter.WriteAttributeString("x2", toElement.In.x.ToString());
            xmlWriter.WriteAttributeString("y2", toElement.In.y.ToString());
        }
        private int ResizeBox(string text)
        {
            int length = text.Length;

            if (length == 1)
            {
                rectangleWidth = 30;
            }
            else if (length > 1 && length <= 3)
            {
                rectangleWidth = 40;
            }
            else if (length > 3 && length <= 10)
            {
                rectangleWidth = 80;
            }
            else if (length > 10 && length <= 20)
            {
                rectangleWidth = 130;
            }
            else
            {
                rectangleWidth = 150;
            }

            return rectangleWidth;
        }
    }
}