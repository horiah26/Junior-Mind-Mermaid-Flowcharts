using System.Xml;

namespace Flowcharts
{
    class ShapeStadium : ShapeParallelogram
    {
        public ShapeStadium(string text) : base( text)
        {

        }

        public override void DrawPolygon()
        {
            new ShapeStadiumDrawn(xmlWriter).Draw(xPos, yPos, height, length);
        }

        public override IOPoints GetIO()
        {
            return new ShapeStadiumIO(orientation, xPos, yPos, height, length).GetIO();
        }
    }
}