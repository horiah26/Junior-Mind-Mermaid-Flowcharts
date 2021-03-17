using System.IO;
using System.Linq;
using System.Xml;

namespace Flowcharts
{
    class DrawnFlowchart
    {
        Grid grid;
        readonly XmlWriter xmlWriter;
        readonly ArrowRegister arrowManager;
        readonly ElementRegister elementManager;
        readonly MemoryStream memoryStream;

        public DrawnFlowchart(XmlWriter xmlWriter, MemoryStream memoryStream, Grid grid, ArrowRegister arrowManager, ElementRegister elementManager)
        {
            this.grid = grid;
            this.xmlWriter = xmlWriter;
            this.memoryStream = memoryStream;
            this.arrowManager = arrowManager;
            this.elementManager = elementManager;
        }

        public void Draw()
        {
            InitializeSVG(xmlWriter);

            grid = new GridFromDictionary(elementManager).GetGrid();

            int lastOccupiedColumn = (elementManager.Max(x => x.Column));
            new OrganizedGrid(grid, arrowManager.GetList()).GetOrganizedGrid();

            foreach (Element element in elementManager)
            {
                element.Draw();
            }

            foreach (Arrow arrow in arrowManager)
            {
                arrow.Draw();
            }

            foreach (Arrow arrow in arrowManager)
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