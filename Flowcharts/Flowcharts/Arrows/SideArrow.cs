using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class SideArrow : Arrow
    {
        public SideArrow(Element fromElement, Element toElement, string text) :base(fromElement, toElement, text)
        {
            FromElement = fromElement;
            ToElement = toElement;
            this.text = text;
            PushesChildrenForward = false;
        }

        public override string[] GetArrowPoints()
        {
            return ArrowOperations.GetSideArrowPoints(FromElement, ToElement);
        }
    }
}
