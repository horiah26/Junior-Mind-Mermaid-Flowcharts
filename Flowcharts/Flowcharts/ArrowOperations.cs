using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    static class ArrowOperations
    {
        public static void DrawArrow(string[] points)
        {
            new DrawnArrow(points).Draw();
        }

        public static void WriteTextArrow(double xPosition, double yPosition, string text)
        {
            new TextOnArrow(xPosition, yPosition, text).DrawAndWrite();
        }

        public static void DrawBackArrow(Element fromElement, Element toElement, string[] points)
        {
            new DrawnBackArrow(fromElement, toElement, points).Draw();
        }

        public static (double xPosition, double yPosition) GetArrowTextPosition(Element fromElement, Element toElement, string[] lines)
        {
            return new ArrowTextPosition(fromElement, toElement, lines).GetCoordinates();
        }
    }
}
