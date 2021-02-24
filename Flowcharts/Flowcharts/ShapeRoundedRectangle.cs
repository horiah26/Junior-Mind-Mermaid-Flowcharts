using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeRoundedRectangle : ShapeRectangle
    {
        public ShapeRoundedRectangle() 
        {

        }

        public override EntryExitPoints DrawRectangle()
        {
            return new ShapeRoundedRectangleDrawer(xmlWriter, orientation, xPos, yPos, rectangleHeight, rectangleLength, Color()).Draw();

        }
    }
}