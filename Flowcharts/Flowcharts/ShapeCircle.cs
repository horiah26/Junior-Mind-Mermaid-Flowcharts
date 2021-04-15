using System;
using System.Xml;

namespace Flowcharts
{
    class ShapeCircle : IShape
    {        
        IOPoints InOut;

        double xPos;
        double yPos;
        double radius;
        readonly string text;

        public ShapeCircle(string text)
        {
            this.text = text;
        }

        public (IOPoints, double textAlignment) Draw()
        {
            radius = Convert.ToInt32(new ShapeCircleRadius(text).GetRadius());

            (xPos, yPos) = GetPosition();
   
            InOut = DrawCircle();

            return (InOut, radius * 1.7);
        }

        public IOPoints DrawCircle()
        {
            return new ShapeCircleDrawn(xPos, yPos, radius).Draw();
        }

        public (double xPos, double yPos) GetPosition()
        {
            return new ShapeCirclePosition().GetPosition();
        }

        public (double height, double length) GetSize()
        {
            var radius = new ShapeCircleRadius(text).GetRadius();
            return (radius, radius);
        }
    }
}
