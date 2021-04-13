using System.Linq;
using System.Xml;

namespace Flowcharts
{
    public class Arrow : IArrow
    {
        public XmlWriter xmlWriter = Writer.XmlWriter;
        public Element fromElement { get; set; }
        public Element toElement { get; set; }

        public string text = null;

        public Arrow(Element fromElement, Element toElement, string text)
        {
            this.fromElement = fromElement;
            this.toElement = toElement;
            this.text = text;
        }

        public virtual void Draw()
        {
            ArrowOperations.DrawArrow(GetArrowEnds());
        }

        public void Write()
        {
            if (text != null)
            {
                (double xPosition, double yPosition) = CalculatePosition();
                ArrowOperations.WriteTextArrow(xPosition, yPosition, text);
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

        public virtual (double xPosition, double yPosition) CalculatePosition()
        {
            var lines = TextOperations.SplitText(text);

            return ArrowOperations.GetArrowTextPosition(fromElement, fromElement, lines);
        }

        public (Element fromElement, Element toElement) GetElementPair()
        {
            return (fromElement, toElement);
        }
    }
}