using System.Xml;

namespace Flowcharts
{
    abstract public class ShapePolygon : IShape
    {
        public IOrientation orientation;
        public XmlWriter xmlWriter = Writer.XmlWriter;

        public double xPos;
        public double yPos;

        public double height;
        public double length;

        public string[] lines;
        public string text;

        protected string coordinates;

        public ShapePolygon(string text)
        {
            orientation = StaticOrientation.Orientation;
            this.text = text;
        }

        public virtual (IOPoints, double textAlignment) Draw()
        {
            lines = TextOperations.SplitText(text);

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
            Color();
            xmlWriter.WriteEndElement();
        }

        public virtual void Color()
        {
            xmlWriter.WriteAttributeString("style", "fill:white;stroke:black;stroke-width:3");
        }

        public virtual (double xPos, double yPos) CalculatePosition()
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
            return new ShapeRectanglePoints(xPos, yPos, height, length).GetPoints();
        }

        public virtual IOPoints GetIO()
        {
            return new ShapeRectangleIO(orientation, xPos, yPos, height, length).GetIO();
        }
    }
}