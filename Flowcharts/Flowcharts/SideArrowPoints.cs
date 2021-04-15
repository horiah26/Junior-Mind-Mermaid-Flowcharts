using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public class SideArrowPoints
    {
        readonly Element fromElement;
        readonly Element toElement;

        public SideArrowPoints(Element fromElement, Element toElement)
        {
            this.fromElement = fromElement;
            this.toElement = toElement;
        }       

        public string[] GetPoints()
        {
            string[] points = new string[4];

            if (typeof(OrientationLeftRight) == fromElement.Orientation.GetType() || typeof(OrientationRightLeft) == fromElement.Orientation.GetType())
            {
                if (fromElement.Row < toElement.Row)
                {
                    points[0] = fromElement.BackArrowRight.x.ToString();
                    points[1] = fromElement.BackArrowRight.y.ToString();
                    points[2] = toElement.BackArrowLeft.x.ToString();
                    points[3] = (toElement.BackArrowLeft.y - 5).ToString();
                }
                else
                {
                    points[0] = fromElement.BackArrowLeft.x.ToString();
                    points[1] = fromElement.BackArrowLeft.y.ToString();
                    points[2] = toElement.BackArrowRight.x.ToString();
                    points[3] = (toElement.BackArrowRight.y + 5).ToString();
                }
            }
            else
            {
                if (fromElement.Row < toElement.Row)
                {
                    points[0] = fromElement.BackArrowRight.x.ToString();
                    points[1] = fromElement.BackArrowRight.y.ToString();
                    points[2] = (toElement.BackArrowLeft.x - 5).ToString();
                    points[3] = toElement.BackArrowLeft.y.ToString();
                }
                else
                {
                    points[0] = fromElement.BackArrowLeft.x.ToString();
                    points[1] = fromElement.BackArrowLeft.y.ToString();
                    points[2] = (toElement.BackArrowRight.x + 5).ToString();
                    points[3] = toElement.BackArrowRight.y.ToString();
                }
            }
            return points;
        }
        
    }
}
