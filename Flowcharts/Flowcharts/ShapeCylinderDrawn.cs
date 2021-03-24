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
            DrawEllipse();
            DrawEdges();
            DrawCurve();
            CoverBackCurve();
        }

        public void DrawEllipse()
        {
            xmlWriter.WriteStartElement("ellipse");
            xmlWriter.WriteAttributeString("cx", (xPos + length / 2).ToString());
            xmlWriter.WriteAttributeString("cy", (yPos - height / 4).ToString());
            xmlWriter.WriteAttributeString("rx", (length / 2).ToString());
            xmlWriter.WriteAttributeString("ry", 10.ToString());
            xmlWriter.WriteAttributeString("stroke", "black");
            xmlWriter.WriteAttributeString("fill", "transparent");
            xmlWriter.WriteAttributeString("stroke-width", "3");

            xmlWriter.WriteEndElement();

        }

        public void DrawEdges()
        {
            xmlWriter.WriteStartElement("line");
            xmlWriter.WriteAttributeString("x1", xPos.ToString());
            xmlWriter.WriteAttributeString("x2", xPos.ToString());
            xmlWriter.WriteAttributeString("y1", (yPos + height).ToString());
            xmlWriter.WriteAttributeString("y2", (yPos - height / 4).ToString());
            xmlWriter.WriteAttributeString("stroke", "black");
            xmlWriter.WriteAttributeString("stroke-width", "3");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("line");
            xmlWriter.WriteAttributeString("x1", (xPos + length).ToString());
            xmlWriter.WriteAttributeString("x2", (xPos + length).ToString());
            xmlWriter.WriteAttributeString("y1", (yPos + height).ToString());
            xmlWriter.WriteAttributeString("y2", (yPos - height / 4).ToString());
            xmlWriter.WriteAttributeString("stroke", "black");
            xmlWriter.WriteAttributeString("stroke-width", "3");
            xmlWriter.WriteEndElement();
        }

        public void DrawCurve()
        {
            xmlWriter.WriteStartElement("ellipse");
            xmlWriter.WriteAttributeString("cx", (xPos + length / 2).ToString());
            xmlWriter.WriteAttributeString("cy", (yPos + height).ToString());
            xmlWriter.WriteAttributeString("rx", (length / 2).ToString());
            xmlWriter.WriteAttributeString("ry", 10.ToString());
            xmlWriter.WriteAttributeString("stroke", "black");
            xmlWriter.WriteAttributeString("fill", "transparent");
            xmlWriter.WriteAttributeString("stroke-width", "3");

            xmlWriter.WriteEndElement();
        }

        public void CoverBackCurve()
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