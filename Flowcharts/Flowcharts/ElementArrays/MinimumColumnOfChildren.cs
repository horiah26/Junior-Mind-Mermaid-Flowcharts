using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    public class MinimumColumnOfChildren
    {
        readonly List<Element> childElements;

        public MinimumColumnOfChildren(Element element)
        {
            childElements = element.childElements;
        }

        public int Get()
        {
            int minColumn = 0;

            if (childElements.Count != 0)
            {
                minColumn = childElements.Min(x => x.Column);
            }

            return minColumn;
        }
    }
}
