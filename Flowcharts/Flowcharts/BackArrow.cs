using System.Xml;

namespace Flowcharts
{
    class BackArrow : Arrow
    {
        public BackArrow(Element fromElement, Element toElement, string text) : base(fromElement, toElement, text)
        {
            this.fromElement = fromElement;
            this.toElement = toElement;
        }

        override public string[] GetArrowEnds()
        {
            string[] points = new string[6];

            points[0] = fromElement.Out.x.ToString();
            points[1] = fromElement.Out.y.ToString();

            double xMiddle = (fromElement.In.x + toElement.BackArrowEntry.x) / 2;
            double yMiddle = (fromElement.In.y + toElement.BackArrowEntry.y) / 2;

            double xDifference = (fromElement.In.x - toElement.BackArrowEntry.x);
            double yDifference = (toElement.BackArrowEntry.y - fromElement.In.y);

            double yAngleCorrection;
            double xAngleCorrection;

            double angleCorrectionFactor = 11;

            if(typeof(OrientationLeftRight) == fromElement.orientation.GetType() || typeof(OrientationDownTop) == fromElement.orientation.GetType())
            {
                if(toElement.Row < fromElement.Row)
                {
                    yAngleCorrection = xDifference / angleCorrectionFactor;
                    xAngleCorrection = yDifference / angleCorrectionFactor;
                }
                else
                {
                    yAngleCorrection = - xDifference / angleCorrectionFactor;
                    xAngleCorrection = - yDifference / angleCorrectionFactor;
                }
            }
            else
            {
                if (toElement.Row >= fromElement.Row)
                {
                    yAngleCorrection = xDifference / angleCorrectionFactor;
                    xAngleCorrection = yDifference / angleCorrectionFactor;
                }
                else
                {
                    yAngleCorrection = -xDifference / angleCorrectionFactor;
                    xAngleCorrection = -yDifference / angleCorrectionFactor;
                }
            }

            points[2] = (xMiddle + xAngleCorrection).ToString();
            points[3] = (yMiddle + yAngleCorrection).ToString();



            if (typeof(OrientationLeftRight) == fromElement.orientation.GetType())
            {
                if (toElement.Row < fromElement.Row)
                {
                    points[4] = (toElement.BackArrowEntry.x + 10).ToString();
                    points[5] = (toElement.BackArrowEntry.y + 12).ToString();
                }
                else
                {
                    points[4] = (toElement.BackArrowEntry.x + 10).ToString();
                    points[5] = (toElement.BackArrowEntry.y - 12).ToString();
                }
            }
            else if (typeof(OrientationRightLeft) == fromElement.orientation.GetType())
            {
                if (toElement.Row < fromElement.Row)
                {
                    points[4] = (toElement.BackArrowEntry.x + 10).ToString();
                    points[5] = (toElement.BackArrowEntry.y + 12).ToString();
                }
                else
                {
                    points[4] = (toElement.BackArrowEntry.x + 10).ToString();
                    points[5] = (toElement.BackArrowEntry.y - 12).ToString();
                }
            }
            else if (typeof(OrientationTopDown) == fromElement.orientation.GetType())
            {
                if (toElement.Row < fromElement.Row)
                {
                    points[4] = (toElement.BackArrowEntry.x + 12).ToString();
                    points[5] = (toElement.BackArrowEntry.y + 10).ToString();
                }
                else
                {
                    points[4] = (toElement.BackArrowEntry.x - 12).ToString();
                    points[5] = (toElement.BackArrowEntry.y + 10).ToString();
                }
            }
            else
            {
                if (toElement.Row < fromElement.Row)
                {
                    points[4] = (toElement.BackArrowEntry.x + 12).ToString();
                    points[5] = (toElement.BackArrowEntry.y + 10).ToString();
                }
                else
                {
                    points[4] = (toElement.BackArrowEntry.x - 12).ToString();
                    points[5] = (toElement.BackArrowEntry.y + 10).ToString();
                }
            } 
            return points;
        }

        override public void Draw()
        {
            new DrawnBackArrow(xmlWriter, fromElement, toElement, GetArrowEnds()).Draw();
        }
    }
}
