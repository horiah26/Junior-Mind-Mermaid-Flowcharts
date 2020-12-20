using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;

namespace Flowcharts
{
    public class Flowchart
    {
        public Dictionary<string, Element> dictionary = new Dictionary<string, Element> { };
        public string FileName { get; private set; }
        public MemoryStream MemoryStream;
        readonly XmlWriter xmlWriter;
        public int EmptyRow = 0;

        public Flowchart(string FileName = null)
        {
            this.FileName = FileName;
            xmlWriter = XmlWriter.Create(FileName + ".svg");
            InitializeSVG(ref xmlWriter);
        }

        public Flowchart(MemoryStream MemoryStream)
        {
            this.MemoryStream = MemoryStream;
            xmlWriter = XmlWriter.Create(MemoryStream);
            MemoryStream.Position = 0;
            InitializeSVG(ref xmlWriter);
        }

        private readonly List<Arrow> arrows = new List<Arrow> { };

        public void AddPair(string text1, string text2)
        {

            if (!dictionary.ContainsKey(text1))
            {
                dictionary.Add(text1, new Element(xmlWriter, text1));
            }
            if (!dictionary.ContainsKey(text2))
            {
                dictionary.Add(text2, new Element(xmlWriter, text2));
            }

            dictionary[text1].AddFollowing(dictionary[text2]);
            dictionary[text2].AddPrevious(dictionary[text1]);

            arrows.Add(new Arrow(xmlWriter, dictionary[text1], dictionary[text2]));
        }

        public void CalculateRows()
        {
            var columns = dictionary.Values.GroupBy(x => x.Column);

            foreach(var Column in columns)
            {
                int i = 0;
                foreach(var element in Column)
                {                   
                    element.Row = i;
                    i++;
                }
            }

            foreach (var dictionaryEntry in dictionary.Values)
            {
                if (dictionaryEntry.parentElements.Count == 1 && 
                    dictionaryEntry.childElements.Count == 0 && 
                    CheckIfOnlyFollower(dictionaryEntry))
                {
                    dictionaryEntry.Row = dictionaryEntry.parentElements.First().Row;
                }

                if(dictionaryEntry.parentElements.Count == 0 &&
                   dictionaryEntry.childElements.Count == 1 &&
                   CheckIfOnlyFollower(dictionaryEntry))
                {
                    dictionaryEntry.Row = dictionaryEntry.childElements.First().Row;
                }
            }

            foreach (var column in columns)
            {
                var rows = column.GroupBy(x => x.Row);

                foreach (var row in rows)
                {
                    if (row.Count() > 1)
                    {
                        int i = 0;
                        foreach (var element in row)
                        {
                            MoveSiblingsDown(element, i++);
                        }
                    }
                }
            }

            var maxColumn = dictionary.Max(x => x.Value.Column);

            foreach (var element in dictionary.Values)
            {
                if (element.childElements.Count == 0 && element.parentElements.Count > 1 && element.Column != maxColumn) 
                {
                    var average = element.parentElements.Average(x => x.Row);
                    element.Row = average;
                }
            }

            foreach(var element in dictionary.Values)
            {
                var parentRows = new List<double> { };
                foreach (var parent in element.parentElements)
                {
                    parentRows.Add(parent.Row);
                }

                var childRows = new List<double> { };
                foreach (var parent in element.childElements)
                {
                    childRows.Add(parent.Row);
                }

                var commonRows = parentRows.Intersect(childRows);

                if (commonRows.Count() != 0 && !commonRows.Contains(element.Row))
                {
                    element.Row = commonRows.First();
                }

            }

            

            foreach (var dictionaryEntry in dictionary.Values)
            {
                dictionaryEntry.UpdateRow();
            }
        }

        public void MoveIfOverlapping(IEnumerable<IGrouping<int, KeyValuePair<string, Element>>> columns)
        {
            
        }

        public void MoveSiblingsDown(Element element, int rows)
        {
            foreach(var parent in element.parentElements)
            {
                foreach(var child in parent.childElements)
                {
                    child.Row += rows;
                }
            }
        }

        public bool CheckIfOnlyFollower(Element element)
        {           
            foreach(var previousElement in element.parentElements)
            {
                if(previousElement.childElements.Count != 1)
                {
                    return false;
                }
            }

            return true;
        }        

        public void Draw()
        {
            CalculateRows();

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