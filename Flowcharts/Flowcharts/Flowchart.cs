using System;
using System.IO;
using System.Xml;

namespace Flowcharts
{
    public class Flowchart
    {
        public string FileName { get; private set; }

        public MemoryStream memoryStream;
        readonly XmlWriter xmlWriter;
        public Grid grid;

        public int EmptyRow = 0;
        public string orientationName = "LR";

        ElementList elementList;
        ArrowRegister arrowList;

        public Flowchart(string orientationName, string FileName = null, string path = null)
        {
            this.orientationName = orientationName;
            this.FileName = FileName;

            xmlWriter = XmlWriter.Create(path + FileName + ".svg");

            InitializeFlowchart();
        }

        public Flowchart(string orientationName, MemoryStream memoryStream)
        {
            this.orientationName = orientationName;
            this.memoryStream = memoryStream;

            xmlWriter = XmlWriter.Create(memoryStream);
            memoryStream.Position = 0;

            InitializeFlowchart();
        }

        public void InitializeFlowchart()
        {
            elementList = new ElementList(xmlWriter, orientationName) { };
            arrowList = new ArrowRegister() { };
            grid = new Grid();
        }

        public void AddPair((string key, string text, string shape) element1, (string key, string text, string shape) element2, string arrowName, string text = null )
        {
            elementList.AddPair(element1, element2);

            var arrowType = Type.GetType("Flowcharts." + arrowName);

            IArrow arrow = (IArrow)Activator.CreateInstance(arrowType, new object[] { xmlWriter, elementList[element1.key], elementList[element2.key], text });
            
            arrowList.Add(arrow);
        }                     

        public void Draw() => new DrawnFlowchart(xmlWriter, memoryStream, grid, arrowList, elementList).Draw();
    }
}