using System;
using System.IO;
using System.Xml;

namespace Flowcharts
{
    public class DrawnFlowchart
    {
        readonly IGrid organizedGrid;
        readonly IArrowRegister orderedArrows;
        readonly MemoryStream memoryStream = Memory.MemoryStream;
        readonly XmlWriter xmlWriter = Writer.XmlWriter;

        readonly int Rows;
        readonly int Columns;

        public DrawnFlowchart(IGrid organizedGrid, IArrowRegister orderedArrows)
        {
            this.orderedArrows = ArrayOperations.CreatePairedArrows(orderedArrows, organizedGrid);
            this.organizedGrid = organizedGrid;

            Rows = organizedGrid.ElementArray.GetLength(0);
            Columns = organizedGrid.ElementArray.GetLength(1);
        }

        public void Draw()
        {
            DrawBeginning();
            DrawSubsystems();
            DrawElements();
            orderedArrows.DrawArrows();
            DrawElements();
            DrawEnd();
        }

        private void DrawSubsystems()
        {
            var subsystems = SubsystemOperations.IdentifySubsystems(organizedGrid.ElementArray);

            foreach(var subsystem in subsystems)
            {
                SubsystemOperations.DrawSubsystem(subsystem, organizedGrid.ElementArray);
            }
        }

        public void DrawBeginning()
        {
            const string svgNs = "http://www.w3.org/2000/svg";

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("svg", svgNs);

            xmlWriter.WriteAttributeString("width", "5000");
            xmlWriter.WriteAttributeString("height", "5000");
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
                element.Draw(Columns, Rows);
            }
        }
    }
}