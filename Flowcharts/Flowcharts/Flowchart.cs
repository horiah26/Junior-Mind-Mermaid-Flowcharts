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

        public void PresetElementsInColumnsAtEqualDistance(IEnumerable<IGrouping<int, Element>> columns)
        {
            foreach (var Column in columns)
            {
                int i = 0;
                foreach (var element in Column)
                {
                    element.Row = i;
                    i++;
                }
            }
        }

        public void ElementsToMiddleIfNotLastColumn()
        {
            var maxColumn = dictionary.Max(x => x.Value.Column);

            foreach (var element in dictionary.Values)
            {
                if (element.childElements.Count == 0 && element.parentElements.Count > 1 && element.Column != maxColumn)
                {
                    var average = element.parentElements.Average(x => x.Row);
                    element.Row = average;
                }
            }
        }

        public void CalculateRows()
        {
            var columns = dictionary.Values.GroupBy(x => x.Column);

            PresetElementsInColumnsAtEqualDistance(columns);

            //

            ElementsToMiddleIfNotLastColumn();
            MoveSiblingsIfOverlapping(columns);
            ElementsToMiddleIfNotLastColumn();
            MoveSiblingsIfOverlapping(columns);
            foreach (var element in dictionary.Values)
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

            var previousColumns = new List<IGrouping<int, Element>> { };

            foreach (var column in columns)
            {
                List<double> childrenRows = new List<double> { };

                foreach (var element in column)
                {
                    if (element.childElements.Count() != 0)
                    {
                        childrenRows.Add(CalculateAverageRowOfChildren(element) - element.Row);
                    }
                }

                double average = 0;

                if (childrenRows.Count() != 0)
                {
                    average = childrenRows.Average();
                }
                previousColumns.Add(column);

                foreach (var previous in previousColumns)
                {
                    MoveColumnDown(previous, average);
                }
            }

            PlaceParentsInMiddleOfChildren(columns);

            //foreach (var dictionaryEntry in dictionary.Values)
            //{
            //    if (dictionaryEntry.parentElements.Count == 1 &&
            //        dictionaryEntry.childElements.Count == 0 &&
            //        CheckIfOnlyFollower(dictionaryEntry))
            //    {
            //        dictionaryEntry.Row = dictionaryEntry.parentElements.First().Row;
            //    }

            //    if (dictionaryEntry.parentElements.Count == 0 &&
            //       dictionaryEntry.childElements.Count == 1 &&
            //       CheckIfOnlyFollower(dictionaryEntry))
            //    {
            //        dictionaryEntry.Row = dictionaryEntry.childElements.First().Row;
            //    }
            //}


            var overlapping = GetOverlapping();





            foreach (var v in overlapping)
            {
                if (!v.Item1.parentElements.Any(x => x.Y == v.Item1.Row))
                {
                    v.Item1.Row = v.Item1.parentElements.First().Row;
                    v.Item2.Row = v.Item1.Row - 1;
                }
                else
                {
                    Console.WriteLine("wong in overlap");
                }
            }

            foreach (var dictionaryEntry in dictionary.Values)
            {
                dictionaryEntry.UpdateRow();
            }
        }

        private void PlaceParentsInMiddleOfChildren(IEnumerable<IGrouping<int, Element>> columns)
        {
            foreach (var column in columns.Reverse())
            {
                foreach (var element in column)
                {
                    if (element.childElements.Count != 0 && element.childElements.All(x => x.parentElements.Count() == 1))
                    {
                        element.Row = element.childElements.Average(x => x.Row);
                    }
                }
            }
        }

        private double CalculateAverageRowOfChildren(Element element)
        {
            return element.childElements.Average(x => x.Row);
        }

        public void MoveSiblingsIfOverlapping(IEnumerable<IGrouping<int, Element>> columns)
        {
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
        }

        public List<(Element, Element)> GetOverlapping()
        {
            var cartesianCombinations = new List<(Element, Element)> { };
            var overlapping = new List<(Element, Element)> { };

            foreach (var element in dictionary.Values)
            {
                foreach (var element2 in dictionary.Values)
                {
                    if (!element.Equals(element2))
                    {
                        cartesianCombinations.Add((element, element2));
                    }
                }
            }

            foreach (var v in cartesianCombinations)
            {
                if (v.Item1.Column == v.Item2.Column && v.Item1.Row == v.Item2.Row)
                {
                    overlapping.Add(v);
                }
            }

            return overlapping;
        }

        public void MoveColumnDown(IGrouping<int, Element> column, double targetRow)
        {

            foreach(var element in column)
            {
                element.Row += targetRow;
            }
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