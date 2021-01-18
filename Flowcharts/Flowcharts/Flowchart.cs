using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System;

namespace Flowcharts
{
    public class Flowchart
    {
        public Dictionary<string, Element> dictionary = new Dictionary<string, Element> { };
        public string FileName { get; private set; }
        public MemoryStream MemoryStream;
        readonly XmlWriter xmlWriter;
        public int EmptyRow = 0;
        public Grid grid = new Grid();
        public string orientation = "LR";

        public Flowchart(string FileName = null)
        {
            this.FileName = FileName;
            xmlWriter = XmlWriter.Create(FileName + ".svg");
            InitializeSVG(ref xmlWriter);
        }

        public void Orientation(string orientation)
        {
            this.orientation = orientation;
        }

        public Flowchart(MemoryStream MemoryStream)
        {
            this.MemoryStream = MemoryStream;
            xmlWriter = XmlWriter.Create(MemoryStream);
            MemoryStream.Position = 0;
            InitializeSVG(ref xmlWriter);
        }

        public readonly List<Arrow> arrows = new List<Arrow> { };

        public void AddPair(string text1, string text2)
        {
            if (!dictionary.ContainsKey(text1))
            {
                dictionary.Add(text1, new Element(xmlWriter, text1, orientation));
            }
            if (!dictionary.ContainsKey(text2))
            {
                dictionary.Add(text2, new Element(xmlWriter, text2, orientation));
            }

            dictionary[text1].AddChild(dictionary[text2]);
            dictionary[text2].AddParent(dictionary[text1]);

            arrows.Add(new Arrow(xmlWriter, dictionary[text1], dictionary[text2]));                
        }

        public void AddBackPair(string text1, string text2)
        {
            arrows.Add(new BackArrow(xmlWriter, dictionary[text1], dictionary[text2]));
            dictionary[text1].backElements.Add(dictionary[text2]);
        }

        public void DictionaryToGrid()
        {
            var columns = dictionary.Values.GroupBy(x => x.Column);

            foreach (var column in columns)
            {
                int i = 0;
                foreach (var element in column)
                {
                    grid.Add(element, i++, column.Key);
                }
            }
        }

        public void Draw()
        {
            DictionaryToGrid();

            int lastOccupiedColumn = dictionary.Values.Max(x => x.Column);

            grid.ArrangeAll(arrows, lastOccupiedColumn);

            foreach (var element in dictionary.Values)
            {
                element.Draw(lastOccupiedColumn);
            }

            foreach (var arrow in arrows)
            {               
                arrow.Draw();               
            }

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

            if (MemoryStream != null)
            {
                MemoryStream.Position = 0;
            }
        }

        private void InitializeSVG(ref XmlWriter thisWriter)
        {
            const string svgNs = "http://www.w3.org/2000/svg";

            thisWriter.WriteStartDocument();
            thisWriter.WriteStartElement("svg", svgNs);

            thisWriter.WriteAttributeString("width", "3000");
            thisWriter.WriteAttributeString("height", "3000");
        }
    }
}