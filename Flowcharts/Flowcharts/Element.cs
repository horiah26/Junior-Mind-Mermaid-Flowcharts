using System;
using System.Linq;
using System.Xml;
using System.Collections.Generic;

namespace Flowcharts
{
    public class Element
    {
        public (double x, double y) In;
        public (double x, double y) Out;

        private readonly int distanceFromEdge = 50;
        private readonly int unitWIdth = 300;
        private readonly int unitHeight = 150;

        readonly XmlWriter xmlWriter;
        public int X { get; set; }
        public double Y { get; set; }
        public string Text { get; private set; }

        public List<Element> parentElements = new List<Element> { };
        public List<Element> childElements = new List<Element> { };

        public int Column = 0;
        public int Row = 0;

        public Element(XmlWriter xmlWriter, string Text)
        {
            CheckLength(Text);

            this.xmlWriter = xmlWriter;
            this.Text = Text;

            X = Column;
        }

        public void AddPrevious(Element previous)
        {
            parentElements.Add(previous);
            UpdateColumn();
            UpdateRow();
            X = Column;
        }
        public void AddFollowing(Element next)
        {
            childElements.Add(next);
            UpdateRow();
        }

        public void ShowPN()
        {
            if (parentElements.Count != 0)
            {
                Console.WriteLine("Previous");
                foreach (var v in parentElements)
                {
                    Console.WriteLine(v.Text);
                }
            }
            if (childElements.Count != 0)
            {
                Console.WriteLine("Following");
                foreach (var v in childElements)
                {
                    Console.WriteLine(v.Text);
                }
            }
        }

        public void SetRow(int Row)
        {
            this.Row = Row;
        }

        public void UpdateRow()
        {
            Y = Row;
        }

        public void UpdateColumn()
        {
            var maxPreviousColumn = parentElements.Max(x => x.Column);
            Column = maxPreviousColumn + 1;
        }

        public void Draw()
        {
            int linesOfText = 0;

            string[] splitLines = SplitWords(Text, ref linesOfText);

            DrawBox(xmlWriter, X, Y, Text, linesOfText);
            WriteText(xmlWriter, X, Y, splitLines);
        }

        private void DrawBox(XmlWriter xmlWriter, int x, double y, string text, int linesOfText)
        {
            xmlWriter.WriteStartElement("rect");
            var rectangleHeight = 40 + (linesOfText - 1) * 17;
            int rectangleWidth = default;            
            ResizeBox(text, ref rectangleWidth);

            double rectangleXPos = distanceFromEdge + x * unitWIdth + 2;
            double rectangleYPos = distanceFromEdge + y * unitHeight - 17;

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

        void WriteText(XmlWriter xmlWriter, int x, double y, string[] lines)
        {
            (int x, int y) fitInBox = (10, 7);
            int spaceBetweenLines = 17;

            int xPosition = distanceFromEdge + (x * unitWIdth + fitInBox.x);
            double yPosition = distanceFromEdge + (y * unitHeight + fitInBox.y);

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
            var maxLineLength = 23;

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