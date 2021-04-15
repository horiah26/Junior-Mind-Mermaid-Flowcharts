using System.Linq;
using System.Xml;

namespace Flowcharts
{
    public class Arrow : IArrow
    {
        public XmlWriter xmlWriter = Writer.XmlWriter;
        public Element FromElement { get; set; }
        public Element ToElement { get; set; }

        public string text = null;
        public bool PushesChildrenForward { get; protected set; }

        public Arrow(Element fromElement, Element toElement, string text)
        {
            FromElement = fromElement;
            ToElement = toElement;
            this.text = text;
            PushesChildrenForward = true;
        }

        public virtual void Draw()
        {
            ArrowOperations.DrawArrow(GetArrowPoints());
        }

        public void Write()
        {
            if (text != null)
            {
                (double xPosition, double yPosition) = CalculatePosition();
                ArrowOperations.WriteTextArrow(xPosition, yPosition, text);
            }
        }

        public virtual string[] GetArrowPoints()
        {
            string[] points = new string[4];

            points[0] = FromElement.Out.x.ToString();
            points[1] = FromElement.Out.y.ToString();
            points[2] = ToElement.In.x.ToString();
            points[3] = ToElement.In.y.ToString();

            return points;
        }

        public virtual (double xPosition, double yPosition) CalculatePosition()
        {
            var lines = TextOperations.SplitText(text);

            return ArrowOperations.GetArrowTextPosition(FromElement, ToElement, lines);
        }

        public (Element fromElement, Element toElement) GetElementPair()
        {
            return (FromElement, ToElement);
        }
    }
}