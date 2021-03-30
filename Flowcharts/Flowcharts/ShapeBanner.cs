using System.Xml;

namespace Flowcharts
{
    class ShapeBanner : ShapePolygon
    {
        public ShapeBanner(XmlWriter xmlWriter, IOrientation orientation, string text): base(xmlWriter, orientation, text)
        {

        }

        public override (double height, double length) GetSize()
        {
            return new ShapeBannerSize(lines).GetSize();
        }

        public override string CalculateCornerPoints()
        {
            return new ShapeBannerPoints(xPos, yPos, height, length).GetPoints();
        }

        public override IOPoints GetIO()
        {
            return new ShapeBannerIO(orientation, xPos, yPos, height, length).GetIO();
        }
    }
}
