using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public class ElementSpecs
    {
        IEnumerable<string> Element1 { get; }
        IEnumerable<string> Element2 { get; }
        IEnumerable<string> ArrowAndText { get; }

        public ElementSpecs(IEnumerable<string> element1, IEnumerable<string> element2, IEnumerable<string> arrowAndText)
        {
            Element1 = element1;
            Element2 = element2;
            ArrowAndText = arrowAndText;
        }

        public (IEnumerable<string> Element1, IEnumerable<string> Element2, IEnumerable<string> ArrowAndText) GetSpecs()
        {
            return (Element1, Element2, ArrowAndText);
        }
    }
}
