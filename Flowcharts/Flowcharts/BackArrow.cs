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

            double slope = (toElement.Out.y - fromElement.In.y) / (fromElement.In.x - toElement.Out.x );
            //slope = -1 / slope;
            System.Console.WriteLine( slope + " " + fromElement.Text);
            points[2] = (xMiddle + slope).ToString();
            points[3] = (yMiddle + slope).ToString();
            points[4] = toElement.Out.x.ToString();
            points[5] = toElement.Out.y.ToString();

            return points;
        }

        override public void Draw()
        {
            new DrawnBackArrow(xmlWriter, fromElement, toElement, GetArrowEnds()).Draw();
        }
    }
}
