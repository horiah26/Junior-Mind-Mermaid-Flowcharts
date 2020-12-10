using System;
using System.Linq;
using System.Xml;

namespace Flowcharts
{
    public class Element
    {
        public (int x, int y) In;
        public (int x, int y) Out;

        private readonly int distanceFromEdge = 50;
        private readonly int unitWIdth = 300;
        private readonly int unitHeight = 150;

        readonly XmlWriter xmlWriter;
        public int X { get; private set; }
        public int Y { get; private set; }
        public string Text { get; private set; }

        public Element(XmlWriter xmlWriter, int X, int Y, string Text)
        {
            CheckLength(Text);

            this.xmlWriter = xmlWriter;
            this.X = X;
            this.Y = Y;
            this.Text = Text;
        }

        public void Draw()
        {
            int linesOfText = 0;

            string[] splitLines = SplitWords(Text, ref linesOfText);

            DrawBox(xmlWriter, X, Y, Text, linesOfText);
            WriteText(xmlWriter, X, Y, splitLines);
        }

        private void DrawBox(XmlWriter xmlWriter, int x, int y, string text, int linesOfText)
        {
            xmlWriter.WriteStartElement("rect");
            var rectangleHeight = 40 + (linesOfText - 1) * 17;
            int rectangleWidth = default;            
            ResizeBox(text, ref rectangleWidth);   

            int rectangleXPos = distanceFromEdge + x * unitWIdth + 2;
            int rectangleYPos = distanceFromEdge + y * unitHeight - 17;

            In = (rectangleXPos - 5 , rectangleYPos + 20);
            Out = (rectangleXPos + rectangleWidth, rectangleYPos + 20);

            xmlWriter.WriteAttributeString("x", rectangleXPos.ToString());
            xmlWriter.WriteAttributeString("y", rectangleYPos.ToString());

            xmlWriter.WriteAttributeString("rx", 7.ToString());
            xmlWriter.WriteAttributeString("ry", 7.ToString());

            xmlWriter.WriteAttributeString("width", rectangleWidth.ToString());
            xmlWriter.WriteAttributeString("height", rectangleHeight.ToString());

            xmlWriter.WriteAttributeString("style", "fill:rgb(255,255,255);stroke-width:2;stroke:rgb(0,0,0)");
            xmlWriter.WriteEndElement();
        }

        void WriteText(XmlWriter xmlWriter, int x, int y, string[] lines)
        {
            (int x, int y) fitInBox = (10, 7);
            int spaceBetweenLines = 17;

            int xPosition = distanceFromEdge + (x * unitWIdth + fitInBox.x);
            int yPosition = distanceFromEdge + (y * unitHeight + fitInBox.y);

            xmlWriter.WriteStartElement("text");
            xmlWriter.WriteAttributeString("x", xPosition.ToString());
            xmlWriter.WriteAttributeString("y", yPosition.ToString());
            xmlWriter.WriteAttributeString("fill", "black");
            xmlWriter.WriteString(lines[0]);

            for (int i = 1; i < lines.Count(); i++)
            {
                xmlWriter.WriteStartElement("tspan");
                xmlWriter.WriteAttributeString("x", xPosition.ToString());
                xmlWriter.WriteAttributeString("y", (yPosition + i * spaceBetweenLines).ToString());
                xmlWriter.WriteString(lines[i]);
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
        }

        string[] SplitWords(string text, ref int textLines)
        {
            var charCount = 0;
            var maxLineLength = 25;

            var split = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .GroupBy(w => (charCount += w.Length + 1) / maxLineLength)
                            .Select(g => string.Join(" ", g)).ToArray();

            textLines = split.Length;
            return split;
        }

        private void ResizeBox(string text, ref int rectangleWidth)
        {
            int length = text.Length;

            if(length == 1)
            {
                rectangleWidth = 30;               
            }
            else if(length > 1 && length <= 3)
            {
                rectangleWidth = 45;
            }
            else if (length > 3 && length <= 10)
            {
                rectangleWidth = 90;
            }
            else if (length > 10 && length <= 20)
            {
                rectangleWidth = 150;
            }
            else
            {
                rectangleWidth = 200;
            }
        }

        private void CheckLength(string text)
        {
            int limit = 85;

            if (text.Length > limit)
            {
                throw new ArgumentException("Text length cannot exceed {0} characters" + limit);
            }
        }
    }
}