using System.Xml;

namespace Flowcharts
{
    internal class ShapeBannerDrawer
    {
        private readonly XmlWriter xmlWriter;
        private readonly IOrientation orientation;
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;

        public ShapeBannerDrawer(XmlWriter xmlWriter, IOrientation orientation, double xPos, double yPos, double height, double length)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        public EntryExitPoints Draw()
        {
            xmlWriter.WriteStartElement("polygon");
            EntryExitPoints InOut = new ShapeBannerInOutCalculator(orientation, xPos, yPos, height, length).GetInOut();
            string points = Getpoints();

            xmlWriter.WriteAttributeString("points", points);
            xmlWriter.WriteAttributeString("style", "fill:white;stroke:black;stroke-width:3");
            xmlWriter.WriteEndElement();

            return InOut;
        }

        public string Getpoints()
        {
            return new ShapeBannerPointsCalculator(xPos, yPos, height, length).Calculate();
        }
    }
}