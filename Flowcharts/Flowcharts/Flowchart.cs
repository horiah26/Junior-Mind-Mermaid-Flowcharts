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

        ElementRegister elementRegister;
        ArrowRegister arrowManager;

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
            elementRegister = new ElementRegister(xmlWriter, orientationName) { };
            arrowManager = new ArrowRegister() { };
            grid = new Grid();
        }

        public void AddPair((string text, string shape) element1, (string text, string shape) element2, string text = null)
        {
            elementRegister.AddPair(element1, element2, text);
            arrowManager.Add(new Arrow(xmlWriter, elementRegister[element1.text], elementRegister[element2.text], text));
        }                     

        public void AddBackPair(string text1, string text2)
        {
            arrowManager.Add(new BackArrow(xmlWriter, elementRegister[text1], elementRegister[text2]));
            elementRegister[text1].backElements.Add(elementRegister[text2]);
        }

        public void Draw() => new DrawnFlowchart(xmlWriter, memoryStream, grid, arrowManager, elementRegister).Draw();
    }
}