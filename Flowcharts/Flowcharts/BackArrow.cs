using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class BackArrow : Arrow
    {
        public BackArrow(XmlWriter xmlWriter, Element fromElement, Element toElement) : base(xmlWriter, fromElement, toElement)
        {
            this.xmlWriter = xmlWriter;
            this.fromElement = fromElement;
            this.toElement = toElement;
        }

        override public void SetInAndOut()
        {
            xmlWriter.WriteAttributeString("x1", fromElement.In.x.ToString());
            xmlWriter.WriteAttributeString("y1", fromElement.In.y.ToString());
            xmlWriter.WriteAttributeString("x2", toElement.Out.x.ToString());
            xmlWriter.WriteAttributeString("y2", toElement.Out.y.ToString());
        }
    }
}
