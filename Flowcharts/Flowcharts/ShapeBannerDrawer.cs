using System.Xml;

namespace Flowcharts
{
    internal class ShapeBannerDrawer
    {
        private XmlWriter xmlWriter;
        private IOrientation orientation;
        private double xPos;
        private double yPos;
        private double bannerHeight;
        private double bannerLength;

        public ShapeBannerDrawer(XmlWriter xmlWriter, IOrientation orientation, double xPos, double yPos, double bannerHeight, double bannerLength)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;
            this.xPos = xPos;
            this.yPos = yPos;
            this.bannerHeight = bannerHeight;
            this.bannerLength = bannerLength;
        }

        public EntryExitPoints Draw()
        {
            xmlWriter.WriteStartElement("polygon");
            EntryExitPoints InOut = new ShapeBannerInOutCalculator(orientation, xPos, yPos, bannerHeight, bannerLength).GetInOut();
            string coordinates = GetCoordinates();

            xmlWriter.WriteAttributeString("points", coordinates);
            xmlWriter.WriteAttributeString("style", "fill:white;stroke:black;stroke-width:3");
            xmlWriter.WriteEndElement();

            return InOut;
        }

        public virtual string GetCoordinates()
        {
            return new ShapeBannerCoordinatesCalculator(xPos, yPos, bannerHeight, bannerLength).Calculate();
        }
    }
}