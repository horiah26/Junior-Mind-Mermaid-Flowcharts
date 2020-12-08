using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Flowcharts
{
    public class Flowchart
    {
        private Dictionary<string, Element> dictionary;
        public string FileName { get; private set; }
        public MemoryStream MemoryStream;

        public Flowchart(string FileName = null)
        {
            this.FileName = FileName;
        }

        public Flowchart(MemoryStream MemoryStream)
        {
            this.MemoryStream = MemoryStream;
        }

        private readonly List<(int x, int y, string text)> listOfSpecs = new List<(int x, int y, string text)> { };
        private readonly List<(Element fromElement, Element toElement)> listOfArrows = new List<(Element, Element)> { };

        public void AddPair(int x1, int y1, string text1, int x2, int y2, string text2)
        {
            XmlWriter xmlWriter;
            if (FileName == null)
            {
                xmlWriter = XmlWriter.Create(MemoryStream);
                MemoryStream.Position = 0;
            }
            else
            {
                xmlWriter = XmlWriter.Create(FileName + ".svg");
            }

            InitializeSVG(ref xmlWriter);

            listOfSpecs.Add((x1, y1, text1));
            listOfSpecs.Add((x2, y2, text2));

            dictionary = new Dictionary<string, Element> { };

            foreach (var (x, y, text) in listOfSpecs)
            {
                if (!dictionary.ContainsKey(text))
                {
                    dictionary.Add(text, new Element(xmlWriter, x, y, text));
                }
            }

            listOfArrows.Add((dictionary[text1], dictionary[text2]));

            foreach (var (fromElement, toElement) in listOfArrows)
            {
                new Arrow(xmlWriter, fromElement, toElement);
            }
      
            xmlWriter.WriteEndDocument(); 
            xmlWriter.Close();

            if(MemoryStream != null)
            {
                MemoryStream.Position = 0;
            }
        }

        private void InitializeSVG(ref XmlWriter thisWriter)
        {
            const string svgNs = "http://www.w3.org/2000/svg";

            thisWriter.WriteStartDocument();
            thisWriter.WriteStartElement("svg", svgNs);
        }
    }
}