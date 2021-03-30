using System;
using System.Xml;

namespace Flowcharts
{
    class DrawnElement
    {
        readonly XmlWriter xmlWriter;
        readonly IOrientation orientation;
        private readonly int distanceFromEdge;
        private readonly int unitLength;
        private readonly int unitHeight;
        double textAlignment;
        readonly string text;
        readonly string shapeString;
        IShape shape;

        public DrawnElement(XmlWriter xmlWriter, IOrientation orientation, string text, string shapeString) 
        {
            this.orientation = orientation;
            this.text = text;
            this.xmlWriter = xmlWriter;
            this.shapeString = shapeString;

            (distanceFromEdge, unitLength, unitHeight) = new GridSpacing(orientation).GetSpacing();
        }

        public IOPoints Draw()
        {
            string[] lines;

            lines = new SplitText(text).GetLines();

            IOPoints InOut = DrawBox();

            PrepareAndWriteText(lines);

            return InOut;
        }

        public void PrepareAndWriteText(string[] splitLines)
        {
            int xFitInBox = 10;
            int yFitInBox = 7;

            var (column, row) = orientation.GetColumnRow();

            (var height, _) = shape.GetSize();

            double xPosition = distanceFromEdge + (column * unitLength + xFitInBox) + (unitLength - textAlignment) / 2;
            double yPosition = distanceFromEdge + (row * unitHeight + yFitInBox) - height / 2;

            new WrittenText(xmlWriter, xPosition, yPosition, splitLines).Write();
        }

        public IOPoints DrawBox()
        {
            Type shapeType = Type.GetType("Flowcharts.Shape" + shapeString);
            shape = (IShape)Activator.CreateInstance(shapeType, new object[] { xmlWriter, orientation, text });

            (IOPoints InOut, double textAlignment) = shape.Draw();

            this.textAlignment = textAlignment;
            return InOut;
        }           
    }
}