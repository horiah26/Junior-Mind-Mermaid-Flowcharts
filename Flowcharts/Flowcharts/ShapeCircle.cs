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
        EntryExitPoints InOut;

        int xPos;
        int yPos;
        int radius;

        public ShapeCircle() { }

        public (EntryExitPoints, int textAlignment) Draw(XmlWriter xmlWriter, IOrientation orientation, string text)
        {
            (distanceFromEdge, unitLength, unitHeight) = new GridSpacer(orientation).GetSpacing();
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;   

            var (Column, Row) = orientation.GetColumnRow();

            (_, int numberOfLines) = new TextSplitter(text).Split();

            radius = Convert.ToInt32( new ShapeCircleRadiusCalculator(text).Calculate());

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
   
            InOut = Draw();

            return (InOut, radius);
        }

        public EntryExitPoints Draw()
        {
            return new ShapeCircleDrawer(xmlWriter, orientation, xPos, yPos, radius).Draw();
        }
    }
}
