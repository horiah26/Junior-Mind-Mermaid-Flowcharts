using System;
using System.Xml;

namespace Flowcharts
{
    class ShapeCircle : IShape
    {        
        private readonly XmlWriter xmlWriter;
        readonly IOrientation orientation;
        EntryExitPoints InOut;

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

        public (EntryExitPoints, double textAlignment) Draw()
        {
            radius = Convert.ToInt32(new ShapeCircleRadiusCalculator(text).Calculate());

            (xPos, yPos) = GetPosition();
   
            InOut = DrawCircle();

            return (InOut, radius);
        }

        public EntryExitPoints DrawCircle()
        {
            return new ShapeCircleDrawer(xmlWriter, orientation, xPos, yPos, radius).Draw();
        }

        public (int xPos, int yPos) GetPosition()
        {
            return new ShapeCirclePositionCalculator(orientation, text, radius).Calculate();
        }
    }
}
