using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeRhombus : IShape
    {
        int rectangleWidth = 0;
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

        public ((double x, double y) In, (double x, double y) Out, int boxWidth) Draw(XmlWriter xmlWriter, IOrientation orientation, string Text, int numberOfLines)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;
            (distanceFromEdge, unitLength, unitHeight) = new GridSpacer(orientation).GetSpacing();

            var textSplitter = new TextSplitter(Text);

            string[] lines;
            (lines, numberOfLines) = textSplitter.Split();

            rhombusSize = Calculate(lines);

            var position = orientation.GetColumnRow(); 
            rhombusXPos = distanceFromEdge + position.Column * unitLength + (unitLength - rhombusSize/2) / 2;
            rhombusYPos = distanceFromEdge + position.Row * unitHeight - 23 * numberOfLines;
            (In, Out) = Draw();

            return (In, Out, rectangleWidth);
        }

        public ((double x, double y) In, (double x, double y) Out) Draw()
        {
            (double x, double y) In;
            (double x, double y) Out;

            xmlWriter.WriteStartElement("polygon");

            (In, Out) = GetInOut();
            
            var position = orientation.GetColumnRow();

            string coordinates = CoordinatesCalculator(rhombusXPos, rhombusYPos, rhombusSize);

            xmlWriter.WriteAttributeString("points", coordinates);
            xmlWriter.WriteAttributeString("style", "fill:white;stroke:black;stroke-width:3");

            xmlWriter.WriteEndElement();

            return (In, Out);
        }

        public double Calculate(string[] lines)
        {
            var maxline = lines.Max(x => x.Length);

            if (maxline < 5)
            {
                return 50;
            }
            else if (maxline >= 5 && maxline < 10)
            {
                return 100;
            }
            else if (maxline >= 10 && maxline < 13)
            {
                return 150;
            }
            else if (maxline >= 13 && maxline < 17)
            {
                return 180;
            }
            else
            {
                return 250;
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
                Out = (rhombusXPos + rhombusSize, rhombusYPos + 20);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (rhombusXPos + rhombusSize, rhombusYPos + 20);
                Out = (rhombusXPos - 5, rhombusYPos + rhombusSize / 2);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (rhombusXPos + rhombusSize / 2, rhombusYPos - 4);
                Out = (rhombusXPos + rhombusSize / 2, rhombusYPos + rhombusSize);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (rhombusXPos + rectangleWidth / 2, rhombusYPos + rhombusSize);
                Out = (rhombusXPos + rectangleWidth / 2, rhombusYPos - 4);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return (In, Out);            
        }
    }
}