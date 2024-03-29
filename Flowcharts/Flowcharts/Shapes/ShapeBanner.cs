﻿using System.Xml;

namespace Flowcharts
{
    class ShapeBanner : ShapePolygon
    {
        public ShapeBanner(string text) : base(text)
        {
        }

        public override (IOPoints, double textAlignment) Draw()
        {
            lines = TextOperations.SplitText(text);

            (height, length) = GetSize();

            (xPos, yPos) = CalculatePosition();

            coordinates = CalculateCornerPoints();

            DrawPolygon();

            return (GetIO(), length * 0.7 + 30);
        }

        public override (double height, double length) GetSize()
        {
            return new ShapeBannerSize(lines).GetSize();
        }

        public override string CalculateCornerPoints()
        {
            return new ShapeBannerPoints(xPos, yPos, height, length).GetPoints();
        }

        public override IOPoints GetIO()
        {
            return new ShapeBannerIO(xPos, yPos, height, length).GetIO();
        }
    }
}
