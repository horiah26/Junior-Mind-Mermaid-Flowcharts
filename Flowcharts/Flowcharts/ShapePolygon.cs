using System.Xml;

namespace Flowcharts
{
    abstract class ShapePolygon : IShape
    {
        public IOrientation orientation;
        public XmlWriter xmlWriter;

        public double xPos;
        public double yPos;

        public double height;
        public double length;

        public string[] lines;
        readonly public string text;

        protected string coordinates;

        public ShapePolygon(XmlWriter xmlWriter, IOrientation orientation, string text)
        {
            this.orientation = orientation;
            this.xmlWriter = xmlWriter;
            this.text = text;
        }

        public (IOPoints, double textAlignment) Draw()
        {
            lines = new SplitText(text).GetLines();

            (height, length) = GetSize();

            (xPos, yPos) = CalculatePosition();

            coordinates = CalculateCornerPoints();

            DrawPolygon();

            return (GetIO(), length);
        }

        public virtual void DrawPolygon()
        {
            xmlWriter.WriteStartElement("polygon");
            xmlWriter.WriteAttributeString("points", coordinates);
            xmlWriter.WriteAttributeString("style", "fill:white;stroke:black;stroke-width:3");
            xmlWriter.WriteEndElement();
        }

        public (double xPos, double yPos) CalculatePosition()
        {
            var position = orientation.GetColumnRow();
            return new ShapePolygonPosition(orientation, position, lines).GetPosition();
        }

        public virtual (double height, double length) GetSize()
        {
            return new ShapeRectangleSize(text).GetSize();
        }

        public virtual string CalculateCornerPoints()
        {
            return new ShapeRectanglePointsCalculator(xPos, yPos, height, length).GetPoints();
        }

        public virtual IOPoints GetIO()
        {
            return new ShapeRectangleIO(orientation, xPos, yPos, height, length).GetIO();
        }
    }
}