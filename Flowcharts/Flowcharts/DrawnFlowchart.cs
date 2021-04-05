using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Flowcharts
{
    public class DrawnFlowchart
    {
        Grid grid;
        readonly XmlWriter xmlWriter;
        readonly ArrowRegister arrowList;
        readonly ElementRegister elementList;
        readonly MemoryStream memoryStream;

        public DrawnFlowchart(XmlWriter xmlWriter, MemoryStream memoryStream, Grid grid, ArrowRegister arrowList, ElementRegister elementList)
        {
            this.grid = grid;
            this.xmlWriter = xmlWriter;
            this.memoryStream = memoryStream;
            this.arrowList = arrowList;
            this.elementList = elementList;
        }

        public void Draw()
        {
            InitializeSVG(xmlWriter);

            grid = new GridFromDictionary(elementList).GetGrid();

            int lastOccupiedColumn = (elementList.Max(x => x.Column));

            var organizedGrid = new OrganizedGrid(grid, arrowList.GetList()).GetOrganizedGrid();

            (int rowSize, int columnSize) = new GridSize(organizedGrid).GetSize();

            foreach (Element element in organizedGrid)
            {
                element.Draw(columnSize, rowSize);
            }

            var forwardArrows = new List<Arrow>() { };
            var backArrows = new List<Arrow>() { };

            foreach (Arrow arrow in arrowList)
            {
                if(typeof(BackArrow) == arrow.GetType())
                {
                    backArrows.Add(arrow);
                }
                else
                {
                    forwardArrows.Add(arrow);
                }
            }

            foreach(var backArrow in backArrows)
            {
                backArrow.Draw();
            }

            foreach(var arrow in forwardArrows)
            {
                arrow.Draw();
            }

            foreach (Arrow arrow in arrowList)
            {
                arrow.Write();
            }

            foreach (Element element in organizedGrid)
            {
                element.Draw(columnSize, rowSize);
            }

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

            if (memoryStream != null)
            {
                memoryStream.Position = 0;
            }
        }

        private void InitializeSVG(XmlWriter thisWriter)
        {
            const string svgNs = "http://www.w3.org/2000/svg";

            thisWriter.WriteStartDocument();
            thisWriter.WriteStartElement("svg", svgNs);

            thisWriter.WriteAttributeString("width", "3000");
            thisWriter.WriteAttributeString("height", "3000");
        }
    }
}