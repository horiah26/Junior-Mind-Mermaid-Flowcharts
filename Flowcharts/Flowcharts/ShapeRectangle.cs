using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeRectangle : IShape
    {
        public IOrientation orientation;
        public XmlWriter xmlWriter;

        public double xPos;
        public double yPos;
        public int rectangleHeight;

        public int rectangleLength = 0;
        public ShapeRectangle() {}

        public (EntryExitPoints, int dimension) Draw(XmlWriter xmlWriter, IOrientation orientation, string text)
        {
            this.orientation = orientation;
            this.xmlWriter = xmlWriter;

            (string[] lines, int numberOfLines) = new TextSplitter(text).Split();

            rectangleHeight = 40 + (numberOfLines - 1) * 17;
            rectangleLength = new ShapeRectangleLengthCalculator(lines).Calculate();

            var position = orientation.GetColumnRow();
            (xPos, yPos) = CalculatePosition(lines, position);

            EntryExitPoints InOut = DrawRectangle();
            return (InOut, rectangleLength);
        }

        public virtual (double xPos, double yPos) CalculatePosition(string[] lines, (int Column, int Row) position)
        {
            return new ShapeRectanglePositionCalculator(orientation, position, lines).Calculate();
        } 

        public virtual EntryExitPoints DrawRectangle()
        {
            return new ShapeRectangleDrawer(xmlWriter, orientation, xPos, yPos, rectangleHeight, rectangleLength, Color()).Draw();

        }

        virtual public string Color()
        {
            return "fill:rgb(255,255,255);stroke-width:2;stroke:rgb(0,0,0)";                       
        }
    }
}