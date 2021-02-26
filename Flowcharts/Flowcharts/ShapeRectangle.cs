using System.Xml;

namespace Flowcharts
{
    class ShapeRectangle : ShapePolygon
    {
        public ShapeRectangle(XmlWriter xmlWriter, IOrientation orientation, string text) : base(xmlWriter, orientation, text)
        {
        }
    }
}