using System;
using System.Xml;

namespace Flowcharts
{
    internal class ShapeStadiumDrawn
    {
        private XmlWriter xmlWriter;

        public ShapeStadiumDrawn(XmlWriter xmlWriter)
        {
            this.xmlWriter = xmlWriter;
        }

        internal void Draw(double xPos, double yPos, double height, double length)
        {
            double curvature = 25;
            DrawLines(xPos, yPos, height, length);
            DrawCurves(xPos, yPos, height, length, curvature);
        }

        private void DrawCurves(double xPos, double yPos, double height, double length, double curvature)
        {
            var leftCoordinates = CalculateCurvePoints(xPos, yPos, height, curvature);

            xmlWriter.WriteStartElement("path");
            xmlWriter.WriteAttributeString("d", leftCoordinates);
            xmlWriter.WriteAttributeString("stroke", "black");
            xmlWriter.WriteAttributeString("stroke-width", "3");
            xmlWriter.WriteAttributeString("fill", "transparent");
            xmlWriter.WriteEndElement();

            var rightCoordinates = CalculateCurvePoints(xPos + length, yPos, height, -curvature);

            xmlWriter.WriteStartElement("path");
            xmlWriter.WriteAttributeString("d", rightCoordinates);
            xmlWriter.WriteAttributeString("stroke", "black");
            xmlWriter.WriteAttributeString("stroke-width", "3");
            xmlWriter.WriteAttributeString("fill", "transparent");
            xmlWriter.WriteEndElement();
        }

        private void DrawLines(double xPos, double yPos, double height, double length)
        {
            xmlWriter.WriteStartElement("line");
            xmlWriter.WriteAttributeString("x1", xPos.ToString());
            xmlWriter.WriteAttributeString("x2", (xPos + length).ToString());
            xmlWriter.WriteAttributeString("y1", yPos.ToString());
            xmlWriter.WriteAttributeString("y2", yPos.ToString());
            xmlWriter.WriteAttributeString("stroke", "black");
            xmlWriter.WriteAttributeString("stroke-width", "3");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("line");
            xmlWriter.WriteAttributeString("x1", xPos.ToString());
            xmlWriter.WriteAttributeString("x2", (xPos + length).ToString());
            xmlWriter.WriteAttributeString("y1", (yPos + height).ToString());
            xmlWriter.WriteAttributeString("y2", (yPos + height).ToString());
            xmlWriter.WriteAttributeString("stroke", "black");
            xmlWriter.WriteAttributeString("stroke-width", "3");
            xmlWriter.WriteEndElement();
        }

        private string CalculateCurvePoints(double xPos, double yPos, double height, double curvature)
        {
            string point1 = xPos.ToString() + "," + yPos.ToString();
            string point2 = (xPos - curvature).ToString() + "," + yPos.ToString();
            string point3 = (xPos - curvature).ToString() + "," + (yPos + height).ToString();
            string point4 = xPos.ToString() + "," + (yPos + height).ToString();

            return "M " + point1 + " C " + point2 + " " + point3 + " " + point4;
        }
    }
}