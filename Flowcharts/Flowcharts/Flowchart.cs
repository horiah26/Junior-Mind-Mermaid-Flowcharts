using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;

namespace Flowcharts
{
    public class Flowchart
    {
        private Dictionary<string, Element> dictionary = new Dictionary<string, Element> { };
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

        private readonly List<Arrow> arrows = new List<Arrow> { };

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

            if (!dictionary.ContainsKey(text1))
            {
                dictionary.Add(text1, new Element(xmlWriter, x1, y1, text1));
            }
            if (!dictionary.ContainsKey(text2))
            {
                dictionary.Add(text2, new Element(xmlWriter, x2, y2, text2));
            }

            arrows.Add(new Arrow(xmlWriter, dictionary[text1], dictionary[text2]));

            foreach (var element in dictionary)
            {
                element.Value.Draw();
            }
            foreach (var arrow in arrows)
            {
                arrow.Draw();
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