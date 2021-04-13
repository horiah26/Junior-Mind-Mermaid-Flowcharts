using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class SideArrow : IArrow
    {
        public Element fromElement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Element toElement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public (Element fromElement, Element toElement) GetElementPair()
        {
            throw new NotImplementedException();
        }

        public void Write()
        {
            throw new NotImplementedException();
        }
    }
}
