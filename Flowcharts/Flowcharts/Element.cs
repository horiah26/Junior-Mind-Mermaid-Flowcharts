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

        public int rowSize = 1;
        public int columnSize = 1;

        private readonly int distanceFromEdge = 50;
        private readonly int unitWIdth = 300;
        private readonly int unitHeight = 150;

        private int rectangleWidth;
        public IOrientation orientation;

        readonly string orientationString;

        readonly XmlWriter xmlWriter;
        public string Text { get; private set; }

        public List<Element> parentElements = new List<Element> { };
        public List<Element> childElements = new List<Element> { };
        public List<Element> backElements = new List<Element> { };

        public int Column = 0;
        public int Row = 0;

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

        public void Draw()
        {
            int linesOfText = 0;
            string[] splitLines = SplitWords(Text, ref linesOfText);

            Type orientationType = Type.GetType("Flowcharts.Orientation" + orientationString);

            IOrientation orientation = (IOrientation)Activator.CreateInstance(orientationType);
            orientation.Initialize(Column, Row, In, Out, columnSize, rowSize);
            this.orientation = orientation;

            DrawBox(orientation, linesOfText);
            WriteText(orientation, splitLines);          

        }

        public void WriteText(IOrientation orientation, string[] splitLines)
        {      
            (int x, int y) fitInBox = (10, 7);
            var position = orientation.GetColumnRow();

            double xPosition = distanceFromEdge + (position.Column * unitWIdth + fitInBox.x) + (unitWIdth - rectangleWidth) / 2;
            double yPosition = distanceFromEdge + (position.Row * unitHeight + fitInBox.y);

            WriteText textWriter = new WriteText(xmlWriter, xPosition, yPosition, splitLines);
            textWriter.Write();
        }

        public void DrawBox(IOrientation orientation, int linesOfText)
        {
            int rectangleHeight = 40 + (linesOfText - 1) * 17;
            int rectangleWidth = ResizeBox(Text);

            var position = orientation.GetColumnRow();

            double rectangleXPos = distanceFromEdge + position.Column * unitWIdth + (unitWIdth - rectangleWidth) / 2;
            double rectangleYPos = distanceFromEdge + position.Row * unitHeight - 17;

            var drawBox = new DrawBox(xmlWriter, rectangleXPos, rectangleYPos, rectangleWidth, rectangleHeight, orientation);
            (In, Out) = drawBox.Draw();
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

        private int ResizeBox(string text)
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

            return rectangleWidth;
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