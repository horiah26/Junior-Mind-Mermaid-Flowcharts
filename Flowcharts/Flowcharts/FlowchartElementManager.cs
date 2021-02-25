using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace Flowcharts
{
    public class FlowchartElementManager : IEnumerable<Element>
    {
        public Dictionary<string, Element> dictionary = new Dictionary<string, Element> { };
        readonly XmlWriter xmlWriter;
        readonly string orientationName;

        public FlowchartElementManager(XmlWriter xmlWriter, string orientationName) 
        {
            this.xmlWriter = xmlWriter;
            this.orientationName = orientationName;
        }

        public Element this[string key]
        {
            get
            {
                if (!dictionary.ContainsKey(key))
                {
                    throw new ArgumentException("Key not found in Dictionary");
                }

                return dictionary[key];
            }
        }

        public void AddPair((string text, string shape) element1, (string text, string shape) element2, string text = null)
        {
            if (!dictionary.ContainsKey(element1.text))
            {
                dictionary.Add(element1.text, new Element(xmlWriter, element1.text, orientationName));
            }
            if (!dictionary.ContainsKey(element2.text))
            {
                dictionary.Add(element2.text, new Element(xmlWriter, element2.text, orientationName));
            }

            dictionary[element1.text].AddChild(dictionary[element2.text]);
            dictionary[element2.text].AddParent(dictionary[element1.text]);

            dictionary[element1.text].shapeString = element1.shape;
            dictionary[element2.text].shapeString = element2.shape;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in dictionary)
            {
                yield return item.Value;
            }
        }

        IEnumerator<Element> IEnumerable<Element>.GetEnumerator()
        {
            foreach (var item in dictionary)
            {
                yield return item.Value;
            }
        }
    }
}
