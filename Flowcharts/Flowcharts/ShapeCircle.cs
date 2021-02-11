using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeCircle : IShape
    {
        private int distanceFromEdge;
        private int unitLength;
        private int unitHeight;
        
        private XmlWriter xmlWriter;
        IOrientation orientation;

        (double x, double y) In;
        (double x, double y) Out;

        int xPos;
        int yPos;
        int radius;

        public ShapeCircle() { }

        public ((double x, double y) In, (double x, double y) Out, int boxWidth) Draw(XmlWriter xmlWriter, IOrientation orientation, string text)
        {
            (distanceFromEdge, unitLength, unitHeight) = new GridSpacer(orientation).GetSpacing();
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;   

            var (Column, Row) = orientation.GetColumnRow();

            radius = new ShapeCircleRadiusCalculator(text).Calculate(); ;
            (_, int numberOfLines) = new TextSplitter(text).Split();

            if (text.Length == 1)
            {
                xPos = distanceFromEdge + Column * unitLength + unitLength / 2 + 5;
                yPos = distanceFromEdge + Row * unitHeight + numberOfLines * 5 - 3;
            }
            else
            {
                xPos = distanceFromEdge + Column * unitLength + unitLength / 2 + radius / 4 + 5;
                yPos = distanceFromEdge + Row * unitHeight + numberOfLines * 5;
            }
   
            (In, Out) = Draw();

            return (In, Out, radius);
        }

        public ((double x, double y) In, (double x, double y) Out) Draw()
        {
            return new ShapeCircleDrawer(xmlWriter, orientation, xPos, yPos, radius).Draw();
        }
    }
}
