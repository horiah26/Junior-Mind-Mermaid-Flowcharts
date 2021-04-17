using System.Xml;

namespace Flowcharts
{
    class ShapeRoundedRectangle : ShapePolygon
    {
        public ShapeRoundedRectangle(string text) : base(text)
        {
        }

        public override void DrawPolygon()
        {
            new ShapeRoundedRectangleDrawn(xmlWriter, xPos, yPos, height, length).Draw();
        }
    }
}