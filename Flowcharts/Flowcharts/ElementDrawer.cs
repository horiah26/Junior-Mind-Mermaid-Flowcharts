using System;
using System.Linq;
using System.Xml;

namespace Flowcharts
{
    class ElementDrawer
    {
        readonly XmlWriter xmlWriter;
        readonly IOrientation orientation;
        private readonly int distanceFromEdge;
        private readonly int unitLength;
        private readonly int unitHeight;
        int dimension = 0;
        readonly string text;
        readonly string shapeString;

        public ElementDrawer(XmlWriter xmlWriter, IOrientation orientation, string text, string shapeString) 
        {
            this.orientation = orientation;
            this.text = text;
            this.xmlWriter = xmlWriter;
            this.shapeString = shapeString;
            (distanceFromEdge, unitLength, unitHeight) = new GridSpacer(orientation).GetSpacing();
        }

        public EntryExitPoints Draw()
        {

            string[] lines;

            var textSplitter = new TextSplitter(text);
            (lines, _) = textSplitter.Split();

            EntryExitPoints InOut = DrawBox();

            PrepareAndWriteText(lines);

            return InOut;
        }

        public void PrepareAndWriteText(string[] splitLines)
        {
            (int x, int y) fitInBox = (10, 7);
            var (column, row) = orientation.GetColumnRow();

            double xPosition = distanceFromEdge + (column * unitLength + fitInBox.x) + (unitLength - dimension) / 2;
            double yPosition = distanceFromEdge + (row * unitHeight + fitInBox.y);

            TextWriter textWriter = new TextWriter(xmlWriter, xPosition, yPosition, splitLines);
            textWriter.Write();
        }

        public EntryExitPoints DrawBox()
        {
            Type shapeType = Type.GetType("Flowcharts.Shape" + shapeString);
            IShape shape = (IShape)Activator.CreateInstance(shapeType);

            (EntryExitPoints InOut, int dimension) = shape.Draw(xmlWriter, orientation, text);

            this.dimension = dimension;
            return InOut;
        }           
    }
}