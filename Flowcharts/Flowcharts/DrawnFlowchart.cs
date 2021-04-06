using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    public class DrawnFlowchart
    {
        readonly Grid organizedGrid;
        readonly OrderedArrows orderedArrows;
        readonly MemoryStream memoryStream = Memory.MemoryStream;
        readonly XmlWriter xmlWriter = Xml.XmlWriter;

        readonly int rowSize;
        readonly int columnSize;

        public DrawnFlowchart(Grid organizedGrid, OrderedArrows orderedArrows)
        {
            this.orderedArrows = orderedArrows;
            this.organizedGrid = organizedGrid;

            (rowSize, columnSize) = organizedGrid.GetSize();
        }

        public void Draw()
        {
            DrawBeginning();
            DrawElements();
            orderedArrows.DrawArrows();
            DrawElements();
            DrawEnd();
        }

        public void DrawBeginning()
        {
            const string svgNs = "http://www.w3.org/2000/svg";

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("svg", svgNs);

            xmlWriter.WriteAttributeString("width", "3000");
            xmlWriter.WriteAttributeString("height", "3000");
        }

        public void DrawEnd()
        {
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

            if (memoryStream != null)
            {
                memoryStream.Position = 0;
            }
        }

        public void DrawElements()
        {
            foreach (Element element in organizedGrid)
            {
                element.Draw(columnSize, rowSize);
            }
        }
    }
}
