using System;
using System.Xml;

namespace Flowcharts
{
    class DrawnElement
    {
        readonly IOrientation orientation;
        private readonly int distanceFromEdge;
        private readonly int unitLength;
        private readonly int unitHeight;
        double textAlignment;
        readonly string text;
        readonly string shapeName;
        IShape shape;

        public DrawnElement(IOrientation orientation, string text, string shapeName) 
        {
            this.orientation = orientation;
            this.text = text;
            this.shapeName = shapeName;

            (distanceFromEdge, unitLength, unitHeight) = new GridSpacing(orientation).GetSpacing();
        }

        public IOPoints Draw()
        {
            string[] lines;

            lines = TextOperations.SplitText(text);

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

            TextOperations.WriteText(xPosition, yPosition, splitLines);
        }

        public IOPoints DrawBox()
        {
            Type shapeType = Type.GetType("Flowcharts.Shape" + shapeName);
            shape = (IShape)Activator.CreateInstance(shapeType, new object[] { text });

            (IOPoints InOut, double textAlignment) = shape.Draw();

            this.textAlignment = textAlignment;
            return InOut;
        }           
    }
}