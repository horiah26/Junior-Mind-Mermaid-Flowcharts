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
            string[] points = new string[4];
            points[0] = fromElement.In.x.ToString();
            points[1] = fromElement.In.y.ToString();
            points[2] = toElement.Out.x.ToString();
            points[3] = toElement.Out.y.ToString();

            return points;
        }
    }
}
