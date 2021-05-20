using System.IO;

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
            StaticOrientation.SetOrientation(orientationName);

            Writer.CreateWriter(FileName, path);

            InitializeFlowchart();
        }

        public Flowchart(string orientationName, MemoryStream memoryStream)
        {
            StaticOrientation.SetOrientation(orientationName);

            Memory.SetMemoryStream(memoryStream);
            Writer.CreateWriter(memoryStream);

            InitializeFlowchart();
        }

        private void InitializeFlowchart()
        {
            elementRegister = Factory.ElementRegister();
            arrowRegister = Factory.ArrowRegister();
            Grid = Factory.CreateGrid();
        }

        public void AddPair((string key, string text, string shape) dataElement1, (string key, string text, string shape) dataElement2, string arrowName, string text = null)
        {
            var element1 = Factory.Element(dataElement1.key, dataElement1.text, dataElement1.shape);
            var element2 = Factory.Element(dataElement2.key, dataElement2.text, dataElement2.shape);

            elementRegister.AddPair(arrowName, element1, element2);

            var arrow = Factory.IArrow(arrowName, element1, element2, text);
            arrowRegister.Add(arrow);
        }

        public void AddPair((string key, string text, string shape, Subsystem subsystem) dataElement1, (string key, string text, string shape, Subsystem subsystem) dataElement2, string arrowName, string text = null)
        {
            var element1 = Factory.Element(dataElement1.key, dataElement1.text, dataElement1.shape);
            var element2 = Factory.Element(dataElement2.key, dataElement2.text, dataElement2.shape);

            if (!element1.Subsystems.Contains(dataElement1.subsystem))
            {
                element1.Subsystems.Add(dataElement1.subsystem);
            }
            if (!element2.Subsystems.Contains(dataElement2.subsystem))
            {
                element2.Subsystems.Add(dataElement2.subsystem);
            }

            elementRegister.AddPair(arrowName, element1, element2);

            var arrow = Factory.IArrow(arrowName, element1, element2, text);
            arrowRegister.Add(arrow);
        }

        public void AddPair(string key1, (string key, string text, string shape) dataElement2, string arrowName, string text = null)
        {
            var element1 = elementRegister[key1];
            var element2 = Factory.Element(dataElement2.key, dataElement2.text, dataElement2.shape);
            elementRegister.AddPair(arrowName, element1, element2);

            IArrow arrow = Factory.IArrow(arrowName, element1, element2, text);
            arrowRegister.Add(arrow);
        }

        public void AddPair(string key1, (string key, string text, string shape, Subsystem subsystem) dataElement2, string arrowName, string text = null)
        {
            var element1 = elementRegister[key1];
            var element2 = Factory.Element(dataElement2.key, dataElement2.text, dataElement2.shape);

            if (!element2.Subsystems.Contains(dataElement2.subsystem))
            {
                element2.Subsystems.Add(dataElement2.subsystem);
            }

            elementRegister.AddPair(arrowName, element1, element2);

            IArrow arrow = Factory.IArrow(arrowName, element1, element2, text);
            arrowRegister.Add(arrow);
        }

        public void AddPair((string key, string text, string shape) dataElement1, string key2, string arrowName, string text = null)
        {
            var element1 = Factory.Element(dataElement1.key, dataElement1.text, dataElement1.shape);
            var element2 = elementRegister[key2];
            
            elementRegister.AddPair(arrowName, element1, element2);

            IArrow arrow = Factory.IArrow(arrowName, element1, element2, text);
            arrowRegister.Add(arrow);
        }

        public void AddPair((string key, string text, string shape, Subsystem subsystem) dataElement1, string key2, string arrowName, string text = null)
        {
            var element1 = Factory.Element(dataElement1.key, dataElement1.text, dataElement1.shape);
            var element2 = elementRegister[key2];

            if (!element1.Subsystems.Contains(dataElement1.subsystem))
            {
                element1.Subsystems.Add(dataElement1.subsystem);
            }

            elementRegister.AddPair(arrowName, element1, element2);

            IArrow arrow = Factory.IArrow(arrowName, element1, element2, text);
            arrowRegister.Add(arrow);
        }

        public void AddPair(string key1, string key2, string arrowName, string text = null)
        {
            var element1 = elementRegister[key1];
            var element2 = elementRegister[key2];

            elementRegister.AddPair(arrowName, element1, element2);

            IArrow arrow = Factory.IArrow(arrowName, element1, element2, text);

            arrowRegister.Add(arrow);
        }

        public void AddSubsystem(string key, Subsystem subsystem)
        {
            var element = elementRegister[key];

            if (!element.Subsystems.Contains(subsystem))
            {
                element.Subsystems.Add(subsystem);
            }
        }

        public void DrawFlowchart()
        {
            Factory.ProcessedFlowchart(Grid, arrowRegister, elementRegister).Draw();
        }
    }
}