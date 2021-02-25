using System.Xml;

namespace Flowcharts
{
    class ShapeRhombusDrawer
    {
        protected readonly XmlWriter xmlWriter;
        protected (double x, double y) In;
        protected (double x, double y) Out;
        protected readonly IOrientation orientation;
        protected readonly double xPos;
        protected readonly double yPos;
        protected readonly double size;

        public ShapeRhombusDrawer(XmlWriter xmlWriter, IOrientation orientation, double xPos, double yPos, double size)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.size = size;
        }

        public EntryExitPoints Draw()
        {
            xmlWriter.WriteStartElement("polygon");

            (In, Out) = new ShapeRhombusInOutCalculator(orientation, xPos, yPos, size).GetInOut();
                        string points = Getpoints();

            xmlWriter.WriteAttributeString("points", points);
            xmlWriter.WriteAttributeString("style", "fill:white;stroke:black;stroke-width:3");
            xmlWriter.WriteEndElement();

            return new EntryExitPoints(In, Out);
        }

        public virtual string Getpoints()
        {
            return new ShapeRhombusPointsCalculator(xPos, yPos, size).Calculate();
        }
    }
}
