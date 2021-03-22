using System.IO;
using System.Linq;
using System.Xml;

namespace Flowcharts
{
    class DrawnFlowchart
    {
        Grid grid;
        readonly XmlWriter xmlWriter;
        readonly ArrowRegister arrowList;
        readonly ElementList elementList;
        readonly MemoryStream memoryStream;

        public DrawnFlowchart(XmlWriter xmlWriter, MemoryStream memoryStream, Grid grid, ArrowRegister arrowList, ElementList elementList)
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

            new OrganizedGrid(grid, arrowList.GetList()).GetOrganizedGrid();

            foreach (Element element in elementList)
            {
                element.Draw();
            }

            foreach (Arrow arrow in arrowList)
            {
                arrow.Draw();
            }

            foreach (Arrow arrow in arrowList)
            {
                arrow.Write();
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