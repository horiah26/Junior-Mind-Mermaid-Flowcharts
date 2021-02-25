using System;
using System.Xml;

namespace Flowcharts
{
    class ShapeHexagon : ShapePolygon
    {
        public ShapeHexagon(XmlWriter xmlWriter, IOrientation orientation, string text) : base(xmlWriter, orientation, text)
        {
        }
    }
}