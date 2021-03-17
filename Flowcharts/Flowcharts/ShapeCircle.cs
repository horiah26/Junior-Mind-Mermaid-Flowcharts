using System;
using System.Xml;

namespace Flowcharts
{
    class ShapeCircle : IShape
    {        
        private readonly XmlWriter xmlWriter;
        readonly IOrientation orientation;
        IOPoints InOut;

        int xPos;
        int yPos;
        int radius;
        readonly string text;

        public ShapeCircle(XmlWriter xmlWriter, IOrientation orientation, string text)
        {
            this.orientation = orientation;
            this.xmlWriter = xmlWriter;
            this.text = text;
        }

        public (IOPoints, double textAlignment) Draw()
        {
            radius = Convert.ToInt32(new ShapeCircleRadius(text).GetRadius());

            (xPos, yPos) = GetPosition();
   
            InOut = DrawCircle();

            return (InOut, radius);
        }

        public IOPoints DrawCircle()
        {
            return new ShapeCircleDrawn(xmlWriter, orientation, xPos, yPos, radius).Draw();
        }

        public (int xPos, int yPos) GetPosition()
        {
            return new ShapeCirclePosition(orientation, text, radius).GetPosition();
        }
    }
}
