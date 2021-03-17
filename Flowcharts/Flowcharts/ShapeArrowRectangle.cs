using System.Xml;

namespace Flowcharts
{
    class ShapeArrowRectangle : IShape
    {
        readonly IOrientation orientation;
        readonly XmlWriter xmlWriter;

        double xPos;
        double yPos;
        double height;
        double length;
        readonly string text;
        string[] lines;
        int numberOfLines;
        readonly Element fromElement;
        readonly Element toElement;


        public ShapeArrowRectangle(IOrientation orientation, XmlWriter xmlWriter, Element fromElement, Element toElement, string text)
        {
            this.orientation = orientation;
            this.xmlWriter = xmlWriter;
            this.fromElement = fromElement;
            this.toElement = toElement;
            this.text = text;
        }

        public (IOPoints, double textAlignment) Draw()
        {
            lines = new SplitText(text).GetLines();
            numberOfLines = lines.Length;

            (height, length) = GetSize(text);

            (xPos, yPos) = GetPosition();

            IOPoints InOut = DrawRectangle();
            return (InOut, length);
        }

        public (double xPos, double yPos) GetPosition()
        {
            var maxLengthOfLine = new TextSizeCalculator(lines).Calculate();

            double xPosition = (fromElement.Out.x + toElement.In.x - (maxLengthOfLine) * 7) / 2;
            double yPosition = (fromElement.Out.y + toElement.In.y - 55 - numberOfLines * 4) / 2;

            return (xPosition, yPosition);
        }

        public (double height, double length) GetSize(string text)
        {
            return new ShapeRectangleSize(text).GetSize();
        }

        public virtual IOPoints DrawRectangle()
        {
            return new ShapeRectangleDrawn(xmlWriter, orientation, xPos, yPos, height, length, "fill:rgb(220,220,220);stroke-width:4;stroke:rgb(255,255,255)").Draw();
        }
    }
}
