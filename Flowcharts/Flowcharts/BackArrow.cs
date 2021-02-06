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

        override public string[] GetArrowEnds()       
        {
            string[] coordinates = new string[4];
            coordinates[0] = fromElement.In.x.ToString();
            coordinates[1] = fromElement.In.y.ToString();
            coordinates[2] = toElement.Out.x.ToString();
            coordinates[3] = toElement.Out.y.ToString();

            return coordinates;
        }
    }
}
