using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Collections;

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

        FlowchartElementManager elementManager;
        FlowchartArrowManager arrowManager;

        public Flowchart(string orientationName, string FileName = null, string path = null)
        {
            this.orientationName = orientationName;
            this.FileName = FileName;

            xmlWriter = XmlWriter.Create(path + FileName + ".svg");

            InitializeFlowchart();
        }

        public Flowchart(string orientationName, MemoryStream MemoryStream)
        {
            this.orientationName = orientationName;
            this.memoryStream = MemoryStream;

            xmlWriter = XmlWriter.Create(memoryStream);
            memoryStream.Position = 0;

            InitializeFlowchart();
        }
        public void InitializeFlowchart()
        {
            elementManager = new FlowchartElementManager(xmlWriter, orientationName) { };
            arrowManager = new FlowchartArrowManager() { };
            grid = new Grid();
        }

        public void AddPair((string text, string shape) element1, (string text, string shape) element2, string text = null)
        {
            elementManager.AddPair(element1, element2, text);
            arrowManager.Add(new Arrow(xmlWriter, elementManager[element1.text], elementManager[element2.text], text));
        }                     

        public void AddBackPair(string text1, string text2)
        {
            arrowManager.Add(new BackArrow(xmlWriter, elementManager[text1], elementManager[text2]));
            elementManager[text1].backElements.Add(elementManager[text2]);
        }

        public void Draw() => new FlowchartDrawer(xmlWriter, memoryStream, grid, arrowManager, elementManager).Draw();
    }
}