using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeRoundedRectangle : ShapePolygon
    {
        public ShapeRoundedRectangle(XmlWriter xmlWriter, IOrientation orientation, string text) : base(xmlWriter, orientation, text)
        {
        }

        public override void DrawPolygon()
        {
            new ShapeRoundedRectangleDrawn(xmlWriter, xPos, yPos, height, length).Draw(coordinates);
        }
    }
}