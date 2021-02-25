using System.Xml;

namespace Flowcharts
{
    class ShapeRectangle : IShape
    {
        IOrientation orientation;
        XmlWriter xmlWriter;

        double xPos;
        double yPos;
        int rectangleHeight;
        int rectangleLength;

        string text;

        public ShapeRectangle(XmlWriter xmlWriter, IOrientation orientation, string text) 
        {
            this.orientation = orientation;
            this.xmlWriter = xmlWriter;
            this.text = text;
        }

        public (EntryExitPoints, int textAlignment) Draw()
        {
            (string[] lines, _) = new TextSplitter(text).Split();

            var position = orientation.GetColumnRow();
            (xPos, yPos) = CalculatePosition(lines, position);
            (rectangleHeight, rectangleLength) = GetSize(text);
            EntryExitPoints InOut = DrawRectangle();
            return (InOut, rectangleLength);
        }

        public(int rectangleHeight, int rectangleLength) GetSize(string text)
        {
            return new ShapeRectangleSizeCalculator(text).Calculate();
        }

        public virtual (double xPos, double yPos) CalculatePosition(string[] lines, (int Column, int Row) position)
        {
            return new ShapeRectanglePositionCalculator(orientation, position, lines).Calculate();
        } 

        public virtual EntryExitPoints DrawRectangle()
        {
            return new ShapeRectangleDrawer(xmlWriter, orientation, xPos, yPos, rectangleHeight, rectangleLength, "fill:rgb(255,255,255);stroke-width:2;stroke:rgb(0,0,0)").Draw();
        }
    }
}