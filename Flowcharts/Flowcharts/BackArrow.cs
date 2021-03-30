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
            string[] points = new string[6];
            points[0] = fromElement.In.x.ToString();
            points[1] = fromElement.In.y.ToString();

            double xMiddle = (fromElement.In.x + toElement.Out.x) / 2;
            double yMiddle = (fromElement.In.y + toElement.Out.y) / 2;

            double xDifference = (fromElement.In.x - toElement.Out.x);
            double yDifference = (toElement.Out.y - fromElement.In.y);

            points[2] = (xMiddle + yDifference / 8.5).ToString();
            points[3] = (yMiddle + xDifference / 8.5).ToString();

            if (typeof(OrientationLeftRight) == fromElement.orientation.GetType() || typeof(OrientationRightLeft) == fromElement.orientation.GetType())
            {
                points[4] = (toElement.Out.x + 5).ToString();
                points[5] = toElement.Out.y.ToString();
            }
            else
            {
                points[4] = toElement.Out.x.ToString();
                points[5] = (toElement.Out.y + 5).ToString();
            }


            return points;
        }

        override public void Draw()
        {
            new DrawnBackArrow(xmlWriter, fromElement, toElement, GetArrowEnds()).Draw();
        }
    }
}
