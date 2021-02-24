﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeBanner : IShape
    {
        public IOrientation orientation;
        public XmlWriter xmlWriter;

        public int distanceFromEdge;
        public int unitLength;
        public int unitHeight;

        public double xPos;
        public double yPos;

        public double height;
        public double length;

        public ShapeBanner() { }
        
        public (EntryExitPoints, int textAlignment) Draw(XmlWriter xmlWriter, IOrientation orientation, string Text)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;

            (distanceFromEdge, unitLength, unitHeight) = new GridSpacer(orientation).GetSpacing();

            (string[] lines, _) = new TextSplitter(Text).Split();

            (height, length) = GetSize(lines);

            (xPos, yPos) = CalculatePosition(lines, orientation);

            EntryExitPoints InOut = DrawBanner();

            return (InOut, 0);
        }

        private EntryExitPoints DrawBanner()
        {
            return new ShapeBannerDrawer(xmlWriter, orientation, xPos, yPos, height, length).Draw();
        }

        private (double height, double length) GetSize(string[] lines)
        {
            return new ShapeBannerSizeCalculator(lines).Calculate();
        }

        private (double xPos, double yPos) CalculatePosition(string[] lines, IOrientation orientation)
        {
            var position = orientation.GetColumnRow();
            return new ShapeRectanglePositionCalculator(orientation, position, lines).Calculate();
        }
    }
}
