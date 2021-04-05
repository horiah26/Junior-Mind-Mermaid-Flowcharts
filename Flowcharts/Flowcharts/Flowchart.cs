using System;
using System.IO;
using System.Xml;

namespace Flowcharts
{
    public class Flowchart
    {
        public string FileName { get; private set; }

        public MemoryStream MemoryStream { get; private set; }
        private XmlWriter xmlWriter { get; set; }
        private Grid Grid { get; set; }

        public string orientationName { get; private set; }

        private ElementRegister elementRegister;
        private ArrowRegister arrowRegister;

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
            MemoryStream = memoryStream;

            xmlWriter = XmlWriter.Create(memoryStream);
            memoryStream.Position = 0;

            InitializeFlowchart();
        }

        private void InitializeFlowchart()
        {
            elementRegister = Factory.CreateElementRegister(xmlWriter, orientationName);
            arrowRegister = Factory.CreateArrowRegister();
            Grid = Factory.CreateGrid();
        }

        public void AddPair((string key, string text, string shape) dataElement1, (string key, string text, string shape) dataElement2, string arrowName, string text = null )
        {
            var element1 = Factory.CreateElement(xmlWriter, dataElement1.key, dataElement1.text, dataElement1.shape, orientationName);
            var element2 = Factory.CreateElement(xmlWriter, dataElement2.key, dataElement2.text, dataElement2.shape, orientationName);

            elementRegister.AddPair(arrowName, element1, element2);

            var arrow = Factory.CreateIArrow(xmlWriter, arrowName, element1, element2, text);
            arrowRegister.Add(arrow);
        }

        public void AddPair(string key1, (string key, string text, string shape) dataElement2, string arrowName, string text = null)
        {
            var element1 = elementRegister[key1];
            var element2 = Factory.CreateElement(xmlWriter,dataElement2.key, dataElement2.text, dataElement2.shape, orientationName);
            elementRegister.AddPair(arrowName, element1, element2);

            IArrow arrow = Factory.CreateIArrow(xmlWriter, arrowName, element1, element2, text);
            arrowRegister.Add(arrow);
        }

        public void AddPair((string key, string text, string shape) dataElement1, string key2, string arrowName, string text = null)
        {
            var element1 = Factory.CreateElement(xmlWriter, dataElement1.key, dataElement1.text, dataElement1.shape, orientationName);
            var element2 = elementRegister[key2];
            elementRegister.AddPair(arrowName, element1, element2);

            IArrow arrow = Factory.CreateIArrow(xmlWriter, arrowName, element1, element2, text);
            arrowRegister.Add(arrow);
        }

        public void AddPair(string key1, string key2, string arrowName, string text = null)
        {
            var arrowType = Type.GetType("Flowcharts." + arrowName);

            var element1 = elementRegister[key1];
            var element2 = elementRegister[key2];

            elementRegister.AddPair(arrowName, element1, element2);

            IArrow arrow = (IArrow)Activator.CreateInstance(arrowType, new object[] { xmlWriter, element1, element2, text });

            arrowRegister.Add(arrow);
        }


        public void DrawFlowchart()
        {
            Factory.CreateDrawnFlowchart(xmlWriter, MemoryStream, Grid, arrowRegister, elementRegister).Draw();
        }
    }
}