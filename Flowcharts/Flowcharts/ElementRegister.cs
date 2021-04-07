using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace Flowcharts
{
    public class ElementRegister : IEnumerable<Element>
    {
        public Dictionary<string, Element> dictionary = new Dictionary<string, Element> { };

        public ElementRegister() 
        {
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

        public void AddPair(string arrowName, Element element1, Element element2)
        {
            var textLimit = new IsLengthWithinLimit();

            textLimit.Check(element1.Text);
            textLimit.Check(element2.Text);

            if (!dictionary.ContainsKey(element1.Key))
            {
                dictionary.Add(element1.Key, element1);
            }
            if (!dictionary.ContainsKey(element2.Key))
            {
                dictionary.Add(element2.Key, element2);
            }

            if(arrowName != "BackArrow")
            {
                dictionary[element1.Key].AddChild(dictionary[element2.Key]);
                dictionary[element2.Key].AddParent(dictionary[element1.Key]);
            }
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