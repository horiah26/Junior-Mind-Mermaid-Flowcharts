using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class BackArrowPoints
    {
        readonly Element toElement;
        readonly Element fromElement;

        public BackArrowPoints(Element fromElement, Element toElement)
        {
            this.fromElement = fromElement;
            this.toElement = toElement;
        }

        public string[] GetPoints()
        {
            string[] points = new string[6];

            points[0] = fromElement.In.x.ToString();
            points[1] = fromElement.In.y.ToString();

            double xMiddle = (fromElement.In.x + toElement.BackArrowLeft.x) / 2;
            double yMiddle = (fromElement.In.y + toElement.BackArrowLeft.y) / 2;

            double xDifference = (fromElement.In.x - toElement.BackArrowLeft.x);
            double yDifference = (toElement.BackArrowLeft.y - fromElement.In.y);

            double yAngleCorrection;
            double xAngleCorrection;

            double angleCorrectionFactor = 4;

            if (typeof(OrientationLeftRight) == fromElement.orientation.GetType() || typeof(OrientationDownTop) == fromElement.orientation.GetType())
            {
                if (toElement.Row < fromElement.Row)
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

            if (toElement.Row == fromElement.Row)
            {
                points[2] = (xMiddle + xAngleCorrection / 3).ToString();
                points[3] = (yMiddle + yAngleCorrection / 3).ToString();
            }
            else
            {
                points[2] = (xMiddle + xAngleCorrection).ToString();
                points[3] = (yMiddle + yAngleCorrection).ToString();
            }

            if (typeof(OrientationLeftRight) == fromElement.orientation.GetType())
            {
                if (toElement.Row == fromElement.Row)
                {
                    points[4] = (toElement.Out.x + 5).ToString();
                    points[5] = (toElement.Out.y).ToString();
                }
                else if (toElement.Row < fromElement.Row)
                {
                    points[4] = (toElement.BackArrowRight.x).ToString();
                    points[5] = (toElement.BackArrowRight.y + 5).ToString();
                }
                else
                {
                    points[4] = (toElement.BackArrowLeft.x).ToString();
                    points[5] = (toElement.BackArrowLeft.y - 5).ToString();
                }
            }
            else if (typeof(OrientationRightLeft) == fromElement.orientation.GetType())
            {
                if (toElement.Row == fromElement.Row)
                {
                    points[4] = (toElement.Out.x - 10).ToString();
                    points[5] = (toElement.Out.y).ToString();
                }
                else if (toElement.Row < fromElement.Row)
                {
                    points[4] = (toElement.BackArrowRight.x).ToString();
                    points[5] = (toElement.BackArrowRight.y + 5).ToString();
                }
                else
                {
                    points[4] = (toElement.BackArrowLeft.x).ToString();
                    points[5] = (toElement.BackArrowLeft.y - 5).ToString();
                }
            }
            else if (typeof(OrientationTopDown) == fromElement.orientation.GetType())
            {
                if (toElement.Row == fromElement.Row)
                {
                    points[4] = (toElement.Out.x).ToString();
                    points[5] = (toElement.Out.y + 5).ToString();
                }
                else if (toElement.Row < fromElement.Row)
                {
                    points[4] = (toElement.BackArrowRight.x + 5).ToString();
                    points[5] = (toElement.BackArrowRight.y).ToString();
                }
                else
                {
                    points[4] = (toElement.BackArrowLeft.x - 5).ToString();
                    points[5] = (toElement.BackArrowLeft.y).ToString();
                }
            }
            else
            {
                if (toElement.Row == fromElement.Row)
                {
                    points[4] = (toElement.Out.x).ToString();
                    points[5] = (toElement.Out.y - 5).ToString();
                }
                else if (toElement.Row < fromElement.Row)
                {
                    points[4] = (toElement.BackArrowRight.x + 5).ToString();
                    points[5] = (toElement.BackArrowRight.y).ToString();
                }
                else
                {
                    points[4] = (toElement.BackArrowLeft.x - 5).ToString();
                    points[5] = (toElement.BackArrowLeft.y).ToString();
                }
            }
            return points;
        }
    }    
}