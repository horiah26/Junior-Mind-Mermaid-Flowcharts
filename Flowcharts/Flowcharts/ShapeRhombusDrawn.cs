using System.Xml;

namespace Flowcharts
{
    class ShapeRhombusDrawn
    {
        protected readonly XmlWriter xmlWriter;
        protected readonly IOrientation orientation;
        protected (double x, double y) In;
        protected (double x, double y) Out;
        protected readonly double xPos;
        protected readonly double yPos;
        protected readonly double size;

        public ShapeRhombusDrawn(XmlWriter xmlWriter, IOrientation orientation, double xPos, double yPos, double size)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.size = size;
        }

        public IOPoints Draw()
        {
            xmlWriter.WriteStartElement("polygon");
                        
            string points = Getpoints();

            xmlWriter.WriteAttributeString("points", points);
            xmlWriter.WriteAttributeString("style", "fill:white;stroke:black;stroke-width:3");
            xmlWriter.WriteEndElement();

            return new IOPoints(In, Out);
        }

        public virtual string Getpoints()
        {
            return new ShapeRhombusPoints(xPos, yPos, size).GetPoints();
        }
    }
}
