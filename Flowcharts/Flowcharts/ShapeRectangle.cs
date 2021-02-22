using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeRectangle : IShape
    {
        int rectangleLength = 0;
        private XmlWriter xmlWriter;
        IOrientation orientation;

        (double x, double y) In;
        (double x, double y) Out;

        private double rectangleXPos;
        private double rectangleYPos;
        private int rectangleHeight;

        public ShapeRectangle() {}

        public ((double x, double y) In, (double x, double y) Out, int boxWidth) Draw(XmlWriter xmlWriter, IOrientation orientation, string text)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;

            (string[] lines, int numberOfLines) = new TextSplitter(text).Split();

            rectangleHeight = 40 + (numberOfLines - 1) * 17;
            rectangleLength = new ShapeRectangleLengthCalculator(lines).Calculate();

            var position = orientation.GetColumnRow();
            (rectangleXPos, rectangleYPos) = CalculatePosition(lines, position);

            (In, Out) = new ShapeRectangleDrawer(xmlWriter, orientation, rectangleXPos, rectangleYPos, rectangleHeight, rectangleLength, Color()).Draw();
            return (In, Out, rectangleLength);
        }

        public virtual (double, double) CalculatePosition(string[] lines, (int Column, int Row) position)
        {
            return new ShapeRectanglePositionCalculator(orientation, position, lines).Calculate();
        } 

        virtual public string Color()
        {
            return "fill:rgb(255,255,255);stroke-width:2;stroke:rgb(0,0,0)";                       
        }
    }
}