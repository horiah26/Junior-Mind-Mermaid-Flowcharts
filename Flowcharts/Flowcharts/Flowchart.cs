using System;
using System.IO;
using System.Xml;

namespace Flowcharts
{
    public class Flowchart
    {
        public MemoryStream MemoryStream { get; private set; }
        private Grid Grid { get; set; }

        private ElementRegister elementRegister;
        private ArrowRegister arrowRegister;

        public Flowchart(string orientationName, string FileName = null, string path = null)
        {
            Orientation.SetOrientation(orientationName);

            Writer.CreateWriter(FileName, path);

            InitializeFlowchart();
        }

        public Flowchart(string orientationName, MemoryStream memoryStream)
        {
            Orientation.SetOrientation(orientationName);

            Memory.SetMemoryStream(memoryStream);
            Writer.CreateWriter(memoryStream);

            InitializeFlowchart();
        }

        private void InitializeFlowchart()
        {
            elementRegister = Factory.CreateElementRegister();
            arrowRegister = Factory.CreateArrowRegister();
            Grid = Factory.CreateGrid();
        }

        public void AddPair((string key, string text, string shape) dataElement1, (string key, string text, string shape) dataElement2, string arrowName, string text = null )
        {
            var element1 = Factory.CreateElement(dataElement1.key, dataElement1.text, dataElement1.shape);
            var element2 = Factory.CreateElement(dataElement2.key, dataElement2.text, dataElement2.shape);

            elementRegister.AddPair(arrowName, element1, element2);

            var arrow = Factory.CreateIArrow(arrowName, element1, element2, text);
            arrowRegister.Add(arrow);
        }

        public void AddPair(string key1, (string key, string text, string shape) dataElement2, string arrowName, string text = null)
        {
            var element1 = elementRegister[key1];
            var element2 = Factory.CreateElement(dataElement2.key, dataElement2.text, dataElement2.shape);
            elementRegister.AddPair(arrowName, element1, element2);

            IArrow arrow = Factory.CreateIArrow(arrowName, element1, element2, text);
            arrowRegister.Add(arrow);
        }

        public void AddPair((string key, string text, string shape) dataElement1, string key2, string arrowName, string text = null)
        {
            var element1 = Factory.CreateElement(dataElement1.key, dataElement1.text, dataElement1.shape);
            var element2 = elementRegister[key2];
            elementRegister.AddPair(arrowName, element1, element2);

            IArrow arrow = Factory.CreateIArrow(arrowName, element1, element2, text);
            arrowRegister.Add(arrow);
        }

        public void AddPair(string key1, string key2, string arrowName, string text = null)
        {
            var element1 = elementRegister[key1];
            var element2 = elementRegister[key2];

            elementRegister.AddPair(arrowName, element1, element2);

            IArrow arrow = Factory.CreateIArrow(arrowName, element1, element2, text);

            arrowRegister.Add(arrow);
        }

        public void DrawFlowchart()
        {
            Factory.CreateProcessedFlowchart(Grid, arrowRegister, elementRegister).Process();
        }


    }
}