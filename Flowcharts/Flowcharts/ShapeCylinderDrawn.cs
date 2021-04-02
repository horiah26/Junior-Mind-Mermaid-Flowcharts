using System.Xml;

namespace Flowcharts
{
    internal class ShapeCylinderDrawn
    {
        private readonly XmlWriter xmlWriter;
        private readonly double xPos;
        private readonly double yPos;
        private readonly double height;
        private readonly double length;

        public ShapeCylinderDrawn(XmlWriter xmlWriter, double xPos, double yPos, double height, double length)
        {
            this.xmlWriter = xmlWriter;
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.length = length;
        }

        public void Draw()
        {
            DrawRectangle();
            DrawUpperEllipse();
            DrawLowerEllipse();
            CoverLowerEllipse();
        }

        public void DrawUpperEllipse()
        {
            xmlWriter.WriteStartElement("ellipse");
            xmlWriter.WriteAttributeString("cx", (xPos + length / 2).ToString());
            xmlWriter.WriteAttributeString("cy", (yPos - height / 4).ToString());
            xmlWriter.WriteAttributeString("rx", (length / 2).ToString());
            xmlWriter.WriteAttributeString("ry", 10.ToString());
            xmlWriter.WriteAttributeString("stroke", "black");
            xmlWriter.WriteAttributeString("fill", "white");
            xmlWriter.WriteAttributeString("stroke-width", "3");

            xmlWriter.WriteEndElement();
        }

        public void DrawRectangle()
        {
            var coordinates = new ShapeRectanglePoints(xPos, yPos + height / 2.5 - 1, height * 1.25 - 2, length).GetPoints();

            xmlWriter.WriteStartElement("polygon");
            xmlWriter.WriteAttributeString("points", coordinates);
            xmlWriter.WriteAttributeString("style", "fill:white;stroke:black;stroke-width:3");
            xmlWriter.WriteEndElement();
        }

        public void DrawLowerEllipse()
        {
            xmlWriter.WriteStartElement("ellipse");
            xmlWriter.WriteAttributeString("cx", (xPos + length / 2).ToString());
            xmlWriter.WriteAttributeString("cy", (yPos + height).ToString());
            xmlWriter.WriteAttributeString("rx", (length / 2).ToString());
            xmlWriter.WriteAttributeString("ry", 10.ToString());
            xmlWriter.WriteAttributeString("stroke", "black");
            xmlWriter.WriteAttributeString("fill", "white");
            xmlWriter.WriteAttributeString("stroke-width", "3");

            xmlWriter.WriteEndElement();
        }

        public void CoverLowerEllipse()
        {
            xmlWriter.WriteStartElement("rect");
            xmlWriter.WriteAttributeString("x", (xPos + 1.5).ToString());
            xmlWriter.WriteAttributeString("y", (yPos + 2).ToString());
            xmlWriter.WriteAttributeString("width", (length - 3).ToString());
            xmlWriter.WriteAttributeString("height", (height - 2.2).ToString());
            xmlWriter.WriteAttributeString("fill", "white");
            xmlWriter.WriteEndElement();
        }
    }
}