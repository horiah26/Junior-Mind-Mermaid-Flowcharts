using System;
using System.Linq;
using System.Xml;

namespace Flowcharts
{
    class ElementDrawer
    {
        readonly XmlWriter xmlWriter;
        readonly IOrientation orientation;
        private readonly int distanceFromEdge = 50;
        private readonly int unitWIdth = 300;
        private readonly int unitHeight = 150;
        int boxWidth = 0;
        int numberOfLines = 1;
        readonly string text;
        readonly string shapeString;

        public ElementDrawer(XmlWriter xmlWriter, IOrientation orientation, string text, string shapeString) 
        {
            this.orientation = orientation;
            this.text = text;
            this.xmlWriter = xmlWriter;
            this.shapeString = shapeString;
        }

        public ((double x, double y) In, (double x, double y) Out) Draw()
        {
            (string[] splitText, int numberofLines) = SplitWords(text);
            numberOfLines = numberofLines;

            ((double x, double y) In, (double x, double y) Out) = DrawBox();

            WriteText(orientation, splitText);

            return (In, Out);
        }

        public void WriteText(IOrientation orientation, string[] splitLines)
        {
            (int x, int y) fitInBox = (10, 7);
            var (column, row) = orientation.GetColumnRow();

            double xPosition = distanceFromEdge + (column * unitWIdth + fitInBox.x) + (unitWIdth - boxWidth) / 2;
            double yPosition = distanceFromEdge + (row * unitHeight + fitInBox.y);

            WriteText textWriter = new WriteText(xmlWriter, xPosition, yPosition, splitLines);
            textWriter.Write();
        }

        public ((double x, double y) In, (double x, double y) Out) DrawBox()
        {
            Type shapeType = Type.GetType("Flowcharts.Shape" + shapeString);
            IShape shape = (IShape)Activator.CreateInstance(shapeType);

            ((double x, double y) In, (double x, double y) Out, int boxWidth) = shape.Draw(xmlWriter, orientation, text, numberOfLines);

            this.boxWidth = boxWidth;
            return (In, Out);
        }

        (string[] splitText, int numberOfLines) SplitWords(string text)
        {
            var charCount = 0;
            var maxLineLength = 23;

            var split = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .GroupBy(w => (charCount += w.Length + 1) / maxLineLength)
                            .Select(g => string.Join(" ", g)).ToArray();

            return (split, split.Length);
        }        
    }
}