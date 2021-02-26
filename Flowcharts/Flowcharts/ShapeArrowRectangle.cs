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

        public (EntryExitPoints, double textAlignment) Draw()
        {
            (lines, numberOfLines) = new TextSplitter(text).Split();

            (height, length) = GetSize(text);

            (xPos, yPos) = GetPosition();

            EntryExitPoints InOut = DrawRectangle();
            return (InOut, length);
        }

        public (double xPos, double yPos) GetPosition()
        {
            var maxLengthOfLine = new TextSizeCalculator(lines).Calculate();

            double xPosition = (fromElement.Out.x + toElement.In.x - (maxLengthOfLine) * 9.2) / 2;
            double yPosition = (fromElement.Out.y + toElement.In.y - (numberOfLines + 3) * 12) / 2;

            return (xPosition, yPosition);
        }

        public (double height, double length) GetSize(string text)
        {
            return new ShapeRectangleSizeCalculator(text).Calculate();
        }

        public virtual EntryExitPoints DrawRectangle()
        {
            return new ShapeRectangleDrawer(xmlWriter, orientation, xPos, yPos, height, length, "fill:rgb(255,255,255);stroke-width:2;stroke:rgb(0,0,0)").Draw();
        }
    }
}
