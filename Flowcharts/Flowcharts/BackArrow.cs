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

            double yAngleCorrection;
            double xAngleCorrection;

            double angleCorrectionFactor = 11;

            if(typeof(OrientationLeftRight) == fromElement.orientation.GetType() || typeof(OrientationDownTop) == fromElement.orientation.GetType())
            {
                if(toElement.Row < fromElement.Row)
                {
                    yAngleCorrection = xDifference / angleCorrectionFactor;
                    xAngleCorrection = yDifference / angleCorrectionFactor;

                    points[4] = (toElement.BackArrowIn.x + 10).ToString();
                    points[5] = (toElement.BackArrowIn.y + 12).ToString();
                }
                else
                {
                    yAngleCorrection = - xDifference / angleCorrectionFactor;
                    xAngleCorrection = - yDifference / angleCorrectionFactor;

                    points[4] = (toElement.BackArrowIn.x + 10).ToString();
                    points[5] = (toElement.BackArrowIn.y - 12).ToString();
                }
            }
            else
            {
                if (toElement.Row >= fromElement.Row)
                {
                    yAngleCorrection = xDifference / angleCorrectionFactor;
                    xAngleCorrection = yDifference / angleCorrectionFactor;

                    points[4] = (toElement.BackArrowIn.x + 10).ToString();
                    points[5] = (toElement.BackArrowIn.y + 12).ToString();
                }
                else
                {
                    yAngleCorrection = -xDifference / angleCorrectionFactor;
                    xAngleCorrection = -yDifference / angleCorrectionFactor;


                    points[4] = (toElement.BackArrowIn.x + 10).ToString();
                    points[5] = (toElement.BackArrowIn.y - 12).ToString();
                }
            }

            if(typeof(OrientationLeftRight) == fromElement.orientation.GetType())
            {
                if (toElement.Row < fromElement.Row)
                {
                    points[4] = (toElement.BackArrowIn.x + 10).ToString();
                    points[5] = (toElement.BackArrowIn.y + 12).ToString();
                }
                else
                {
                    points[4] = (toElement.BackArrowIn.x + 10).ToString();
                    points[5] = (toElement.BackArrowIn.y - 12).ToString();
                }
            }
            else if (typeof(OrientationRightLeft) == fromElement.orientation.GetType())
            {
                if (toElement.Row < fromElement.Row)
                {
                    points[4] = (toElement.BackArrowIn.x + 10).ToString();
                    points[5] = (toElement.BackArrowIn.y + 12).ToString();
                }
                else
                {
                    points[4] = (toElement.BackArrowIn.x + 10).ToString();
                    points[5] = (toElement.BackArrowIn.y - 12).ToString();
                }
            }

            points[2] = (xMiddle + xAngleCorrection).ToString();
            points[3] = (yMiddle + yAngleCorrection).ToString();

            return points;
        }

        override public void Draw()
        {
            new DrawnBackArrow(xmlWriter, fromElement, toElement, GetArrowEnds()).Draw();
        }
    }
}
