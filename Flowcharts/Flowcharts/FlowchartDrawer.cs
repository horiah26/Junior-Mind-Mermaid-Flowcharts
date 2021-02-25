using System.IO;
using System.Linq;
using System.Xml;

namespace Flowcharts
{
    class FlowchartDrawer
    {
        Grid grid;
        readonly XmlWriter xmlWriter;
        readonly FlowchartArrowManager arrowManager;
        readonly FlowchartElementManager elementManager;
        readonly MemoryStream memoryStream;

        public FlowchartDrawer(XmlWriter xmlWriter, MemoryStream memoryStream, Grid grid, FlowchartArrowManager arrowManager, FlowchartElementManager elementManager)
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

            grid = new FlowchartDictionarytoGridHandler(elementManager).ToGrid();

            int lastOccupiedColumn = (elementManager.Max(x => x.Column));

            grid.ArrangeAll(arrowManager.GetList());

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