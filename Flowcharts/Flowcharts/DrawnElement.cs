using System;
using System.Xml;

namespace Flowcharts
{
    class DrawnElement
    {
        readonly IOrientation orientation = StaticOrientation.Orientation;
        private readonly int distanceFromEdge;
        private readonly int unitLength;
        private readonly int unitHeight;
        double textAlignment;
        readonly string text;
        readonly Type shapeType;
        IShape shape;

        public DrawnElement(string text, Type shapeType) 
        {
            this.text = text;
            this.shapeType = shapeType;

            (distanceFromEdge, unitLength, unitHeight) = ElementOperations.GetSpacing();
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
            shape = (IShape)Activator.CreateInstance(shapeType, new object[] { text });

            (IOPoints InOut, double textAlignment) = shape.Draw();

            this.textAlignment = textAlignment;
            return InOut;
        }           
    }
}