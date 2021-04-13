using System.Xml;

namespace Flowcharts
{
    class ShapeSubroutine : ShapePolygon
    {
        public ShapeSubroutine(string text) : base( text)
        {
        }


        public override string CalculateCornerPoints()
        {
            return new ShapeSubroutinePoints(xPos, yPos, height, length).GetPoints();
        }

        public override IOPoints GetIO()
        {
            return new ShapeSubroutineIO(orientation, xPos, yPos, height, length).GetIO();
        }
    }
}