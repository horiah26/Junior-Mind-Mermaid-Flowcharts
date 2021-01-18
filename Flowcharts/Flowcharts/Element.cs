using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Flowcharts
{
    public class Element
    {
        public (double x, double y) In;
        public (double x, double y) Out;

        public int rowSize = 10;
        public int columnSize = 10;

        private readonly int distanceFromEdge = 50;
        private readonly int unitWIdth = 300;
        private readonly int unitHeight = 150;

        private double rectangleWidth;

        readonly string orientationString;

        readonly XmlWriter xmlWriter;
        public string Text { get; private set; }

        public List<Element> parentElements = new List<Element> { };
        public List<Element> childElements = new List<Element> { };
        public List<Element> backElements = new List<Element> { };

        public int Column = 0;
        public int  Row = 0;

        public Element(XmlWriter xmlWriter, string Text, string orientationString)
        {
            CheckLength(Text);

            this.xmlWriter = xmlWriter;
            this.Text = Text;
            this.orientationString = orientationString;
        }

        public void AddParent(Element previous)
        {
            parentElements.Add(previous);
            UpdateColumn();
        }
        public void AddChild(Element next)
        {
            childElements.Add(next);
        }

        public void SetRow(int Row)
        {
            this.Row = Row;
        }

        public void UpdateColumn()
        {
            var maxPreviousColumn = parentElements.Max(x => x.Column);
            Column = maxPreviousColumn + 1;
        }

        public void Draw(int lastOccupiedColumn)
        {
            int linesOfText = 0;

            string[] splitLines = SplitWords(Text, ref linesOfText);

            var orient = new SelectOrientation(orientationString, Column, Row, In, Out, columnSize, rowSize, lastOccupiedColumn);

            DrawBox(xmlWriter, Text, linesOfText, orient);
            WriteText(xmlWriter, orient.GetColumnRow(), splitLines);          
        }

        private void DrawBox(XmlWriter xmlWriter, string text, int linesOfText, SelectOrientation orientation)
        {
            var position = orientation.GetColumnRow();

            xmlWriter.WriteStartElement("rect");
            var rectangleHeight = 40 + (linesOfText - 1) * 17;
            int rectangleWidth = default;            
            ResizeBox(text, ref rectangleWidth);

            double rectangleXPos = distanceFromEdge + position.Column * unitWIdth + (unitWIdth-rectangleWidth)/2;
            double rectangleYPos = distanceFromEdge + position.Row * unitHeight - 17;

            (In, Out) = orientation.GetInOut(rectangleXPos, rectangleYPos, rectangleWidth, rectangleHeight);

            xmlWriter.WriteAttributeString("x", rectangleXPos.ToString());
            xmlWriter.WriteAttributeString("y", rectangleYPos.ToString());

            xmlWriter.WriteAttributeString("rx", 7.ToString());
            xmlWriter.WriteAttributeString("ry", 7.ToString());

            xmlWriter.WriteAttributeString("width", rectangleWidth.ToString());
            xmlWriter.WriteAttributeString("height", rectangleHeight.ToString());

            xmlWriter.WriteAttributeString("style", "fill:rgb(255,255,255);stroke-width:2;stroke:rgb(0,0,0)");
            xmlWriter.WriteEndElement();
        }

        void WriteText(XmlWriter xmlWriter, (double x, double y) position, string[] lines)
        {
            (int x, int y) fitInBox = (10, 7);
            int spaceBetweenLines = 17;

            double xPosition = distanceFromEdge + (position.x * unitWIdth + fitInBox.x) + (unitWIdth - rectangleWidth) / 2;
            double yPosition = distanceFromEdge + (position.y * unitHeight + fitInBox.y);

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

        public int MinColumnOfChildren()
        {
            int a = 0;
            if (childElements.Count != 0)
            {
                a = childElements.Min(x => x.Column);
            }

            return a;
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

            this.rectangleWidth = rectangleWidth;
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