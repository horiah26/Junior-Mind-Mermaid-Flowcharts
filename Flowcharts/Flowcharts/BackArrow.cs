using System.Xml;

namespace Flowcharts
{
    class BackArrow : Arrow
    {
        public BackArrow(XmlWriter xmlWriter, Element fromElement, Element toElement, string text) : base(xmlWriter, fromElement, toElement, text)
        {
            this.xmlWriter = xmlWriter;
            this.fromElement = fromElement;
            this.toElement = toElement;
        }

        override public string[] GetArrowEnds()       
        {
            string[] points = new string[4];
            points[0] = toElement.In.x.ToString();
            points[1] = toElement.In.y.ToString();
            points[2] = fromElement.Out.x.ToString();
            points[3] = fromElement.Out.y.ToString();

            return points;
        }
    }
}
