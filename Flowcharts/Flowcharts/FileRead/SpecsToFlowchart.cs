using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    public class SpecsToFlowchart
    {
        readonly IEnumerable<ElementSpecs> elementSpecs;
        readonly Flowchart flowchart;

        public SpecsToFlowchart(Flowchart flowchart, IEnumerable<ElementSpecs> elementSpecs)
        {
            this.elementSpecs = elementSpecs;
            this.flowchart = flowchart;
        }

        public void AddToFlowchart()
        {
            foreach(var spec in elementSpecs)
            {
                (IEnumerable<string> Element1, IEnumerable<string> Element2, IEnumerable<string> ArrowAndText) = spec.GetSpecs();

                if (ArrowAndText.Count() == 1)
                {
                    if (Element1.Count() == 1 && Element2.Count() == 1)
                    {
                        flowchart.AddPair(Element1.First(), Element2.First(), ArrowAndText.First());
                    }
                    else if (Element1.Count() == 1 && Element2.Count() == 3)
                    {
                        flowchart.AddPair(Element1.First(), AllSpecs(Element2), ArrowAndText.First());
                    }
                    else if (Element1.Count() == 3 && Element2.Count() == 1)
                    {
                        flowchart.AddPair(AllSpecs(Element1), Element2.First(), ArrowAndText.First());
                    }
                    else if (Element1.Count() == 3 && Element2.Count() == 3)
                    {
                        flowchart.AddPair(AllSpecs(Element1), AllSpecs(Element2), ArrowAndText.First());
                    }
                }

                if (ArrowAndText.Count() == 2)
                {
                    if (Element1.Count() == 1 && Element2.Count() == 1)
                    {
                        flowchart.AddPair(Element1.First(), Element2.First(), ArrowAndText.First());
                    }
                    else if (Element1.Count() == 1 && Element2.Count() == 3)
                    {
                        flowchart.AddPair(Element1.First(), AllSpecs(Element2), ArrowAndText.First());
                    }
                    else if (Element1.Count() == 3 && Element2.Count() == 1)
                    {
                        flowchart.AddPair(AllSpecs(Element1), Element2.First(), ArrowAndText.First());
                    }
                    else if (Element1.Count() == 3 && Element2.Count() == 3)
                    {
                        flowchart.AddPair(AllSpecs(Element1), AllSpecs(Element2), ArrowAndText.First());
                    }
                }
            }
        }

        private (string key, string text, string shape) AllSpecs(IEnumerable<string> element)
        {
            string key = element.ElementAt(0);
            string text = element.ElementAt(1);
            string shape = element.ElementAt(2);

            return (key, text, shape);
        }
    }
}
