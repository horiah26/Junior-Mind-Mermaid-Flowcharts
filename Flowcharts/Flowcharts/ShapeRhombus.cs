using System;
using System.Linq;
using System.Xml;

namespace Flowcharts
{
    class ShapeRhombus : IShape
    {
        int rectangleLength = 0;
        private int distanceFromEdge;
        private int unitLength;
        private int unitHeight;
        private XmlWriter xmlWriter;
        IOrientation orientation;

        (double x, double y) In;
        (double x, double y) Out;

        double rhombusXPos;
        double rhombusYPos;
        double rhombusSize;

        public ShapeRhombus()
        {
        }

        public ((double x, double y) In, (double x, double y) Out, int boxWidth) Draw(XmlWriter xmlWriter, IOrientation orientation, string Text)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;
            (distanceFromEdge, unitLength, unitHeight) = new GridSpacer(orientation).GetSpacing();

            (string[] lines, int numberOfLines) = new TextSplitter(Text).Split();

            rhombusSize = Calculate(lines);

            var maxline = lines.Max(x => x.Length);

            var (Column, Row) = orientation.GetColumnRow(); 

            rhombusXPos = distanceFromEdge + Column * unitLength + (unitLength - rhombusSize/3) / 2 + maxline * 4/3 - (numberOfLines - 1) * 7;
            rhombusYPos = distanceFromEdge + Row * unitHeight - rhombusSize/2 +  numberOfLines * 5; 
            (In, Out) = Draw();

            return (In, Out, rectangleLength);
        }

        public ((double x, double y) In, (double x, double y) Out) Draw()
        {
            (double x, double y) In;
            (double x, double y) Out;

            xmlWriter.WriteStartElement("polygon");

            (In, Out) = GetInOut();
            
            string coordinates = CoordinatesCalculator(rhombusXPos, rhombusYPos, rhombusSize);

            xmlWriter.WriteAttributeString("points", coordinates);
            xmlWriter.WriteAttributeString("style", "fill:white;stroke:black;stroke-width:3");

            xmlWriter.WriteEndElement();

            return (In, Out);
        }

        public double Calculate(string[] lines)
        {
            var maxline = lines.Max(x => x.Length);

            if (maxline < 2)
            {
                return 40;
            }
            else if (maxline >= 2 && maxline < 5)
            {
                return 68;
            }
            else if (maxline >= 5 && maxline < 7)
            {
                return 85;
            }
            else if (maxline >= 7 && maxline < 10)
            {
                return 100;
            }
            else if (maxline >= 10 && maxline < 13)
            {
                return 120;
            }
            else if (maxline >= 13 && maxline < 17)
            {
                return 150;
            }
            else
            {
                return 190;
            }            
        }

        public string CoordinatesCalculator(double rhombusXPos, double rhombusYPos, double rhombusSize)
        {
            string left = rhombusXPos.ToString() + "," + (rhombusYPos + rhombusSize / 2).ToString();
            string down = (rhombusXPos + rhombusSize / 2).ToString() + "," + (rhombusYPos + rhombusSize).ToString();
            string up = (rhombusXPos + rhombusSize / 2).ToString() + "," + rhombusYPos.ToString();
            string right = (rhombusXPos + rhombusSize).ToString() + "," + (rhombusYPos + rhombusSize / 2).ToString();
                
            return up + " " + left + " " + down + " " + right;
        }

        public ((double x, double y) In, (double x, double y) Out) GetInOut()
        {
            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (rhombusXPos - 5, rhombusYPos + rhombusSize / 2);
                Out = (rhombusXPos + rhombusSize, rhombusYPos + rhombusSize / 2);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (rhombusXPos + rhombusSize + 3, rhombusYPos + rhombusSize / 2);
                Out = (rhombusXPos, rhombusYPos + rhombusSize / 2);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (rhombusXPos + rhombusSize / 2, rhombusYPos - 4);
                Out = (rhombusXPos + rhombusSize / 2, rhombusYPos + rhombusSize);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (rhombusXPos + rhombusSize / 2, rhombusYPos + rhombusSize + 3);
                Out = (rhombusXPos + rhombusSize / 2, rhombusYPos);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return (In, Out);            
        }
    }
}