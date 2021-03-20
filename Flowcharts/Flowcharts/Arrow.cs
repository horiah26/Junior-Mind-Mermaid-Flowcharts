using System.Xml;

namespace Flowcharts
{
    public class Arrow : IArrow
    {
        public XmlWriter xmlWriter;
        public Element fromElement;
        public Element toElement;
        public string text = null;

        public Arrow(XmlWriter xmlWriter, Element fromElement, Element toElement, string text)
        {
            this.xmlWriter = xmlWriter;
            this.fromElement = fromElement;
            this.toElement = toElement;
            this.text = text;
        }

        public virtual void Draw()
        {
            new DrawnArrow(xmlWriter, fromElement, toElement, GetArrowEnds()).Draw();
        }

        public void Write()
        {
            if (text != null)
            {
                new TextOnArrow(xmlWriter, fromElement, toElement, text).DrawAndWrite();
            }
        }

        public virtual string[] GetArrowEnds()
        {
            string[] points = new string[4];

            points[0] = fromElement.Out.x.ToString();
            points[1] = fromElement.Out.y.ToString();
            points[2] = toElement.In.x.ToString();
            points[3] = toElement.In.y.ToString();

            return points;
        }
    }
}