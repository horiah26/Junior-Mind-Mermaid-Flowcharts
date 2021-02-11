using System;
using System.Linq;
using System.Xml;

namespace Flowcharts
{
    class ElementDrawer
    {
        readonly XmlWriter xmlWriter;
        readonly IOrientation orientation;
        private int distanceFromEdge;
        private int unitLength;
        private int unitHeight;
        int boxWidth = 0;
        readonly string text;
        readonly string shapeString;

        public ElementDrawer(XmlWriter xmlWriter, IOrientation orientation, string text, string shapeString) 
        {
            this.orientation = orientation;
            this.text = text;
            this.xmlWriter = xmlWriter;
            this.shapeString = shapeString;
            (this.distanceFromEdge, unitLength, unitHeight) = new GridSpacer(orientation).GetSpacing();
        }

        public ((double x, double y) In, (double x, double y) Out) Draw()
        {

            string[] lines;

            var textSplitter = new TextSplitter(text);
            (lines, _) = textSplitter.Split();

            ((double x, double y) In, (double x, double y) Out) = DrawBox();

            PrepareAndWriteText(lines);

            return (In, Out);
        }

        public void PrepareAndWriteText(string[] splitLines)
        {
            (int x, int y) fitInBox = (10, 7);
            var (column, row) = orientation.GetColumnRow();

            double xPosition = distanceFromEdge + (column * unitLength + fitInBox.x) + (unitLength - boxWidth) / 2;
            double yPosition = distanceFromEdge + (row * unitHeight + fitInBox.y);

            TextWriter textWriter = new TextWriter(xmlWriter, xPosition, yPosition, splitLines);
            textWriter.Write();
        }

        public ((double x, double y) In, (double x, double y) Out) DrawBox()
        {
            Type shapeType = Type.GetType("Flowcharts.Shape" + shapeString);
            IShape shape = (IShape)Activator.CreateInstance(shapeType);

            ((double x, double y) In, (double x, double y) Out, int boxWidth) = shape.Draw(xmlWriter, orientation, text);

            this.boxWidth = boxWidth;
            return (In, Out);
        }           
    }
}