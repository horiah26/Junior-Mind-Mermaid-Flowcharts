using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class SideArrow : Arrow
    {
        public SideArrow(Element fromElement, Element toElement, string text) :base(fromElement, toElement, text)
        {
            this.FromElement = fromElement;
            this.text = text;
            this.ToElement = toElement;
        }

        public override string[] GetArrowPoints()
        {
            return ArrowOperations.GetSideArrowPoints(FromElement, ToElement);
        }
    }
}
