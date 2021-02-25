using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeBanner : ShapePolygon
    {
        public ShapeBanner(XmlWriter xmlWriter, IOrientation orientation, string text): base(xmlWriter, orientation, text)
        {

        }

        public override (double height, double length) GetSize()
        {
            return new ShapeBannerSizeCalculator(lines).Calculate();
        }

        public override string CalculateCornerPoints()
        {
            return new ShapeBannerPointsCalculator(xPos, yPos, height, length).Calculate();
        }

        public override EntryExitPoints GetInOut()
        {
            return new ShapeBannerInOutCalculator(orientation, xPos, yPos, height, length).GetInOut();
        }
    }
}
