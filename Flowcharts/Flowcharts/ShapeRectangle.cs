using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeRectangle : IShape
    {
        int rectangleWidth = 0;
        private int distanceFromEdge = 50;
        private int unitWIdth = 300;
        private int unitHeight = 150;
        private XmlWriter xmlWriter;
        IOrientation orientation;

        (double x, double y) In;
        (double x, double y) Out;

        private double rectangleXPos;
        private double rectangleYPos;
        private int rectangleHeight;

        public ShapeRectangle()
        {
        }

        public ((double x, double y) In, (double x, double y) Out, int boxWidth) Draw(XmlWriter xmlWriter, IOrientation orientation, string Text, int numberOfLines)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;
            rectangleHeight = 40 + (numberOfLines - 1) * 17;
            rectangleWidth = ResizeBox(Text);
            var position = orientation.GetColumnRow();
            rectangleXPos = distanceFromEdge + position.Column * unitWIdth + (unitWIdth - rectangleWidth) / 2;
            rectangleYPos = distanceFromEdge + position.Row * unitHeight - 17;

            (In, Out) = Draw();

            return (In, Out, rectangleWidth);
        }

        private int ResizeBox(string text)
        {
            int length = text.Length;

            if (length == 1)
            {
                rectangleWidth = 30;
            }
            else if (length > 1 && length <= 3)
            {
                rectangleWidth = 45;
            }
            else if (length > 3 && length <= 10)
            {
                rectangleWidth = 90;
            }
            else if (length > 10 && length <= 20)
            {
                rectangleWidth = 150;
            }
            else
            {
                rectangleWidth = 200;
            }

            return rectangleWidth;
        }

        public ((double x, double y) In, (double x, double y) Out) Draw()
        {
            (double x, double y) In;
            (double x, double y) Out;

            xmlWriter.WriteStartElement("rect");

            (In, Out) = GetInOut();

            xmlWriter.WriteAttributeString("x", rectangleXPos.ToString());
            xmlWriter.WriteAttributeString("y", rectangleYPos.ToString());

            xmlWriter.WriteAttributeString("rx", 7.ToString());
            xmlWriter.WriteAttributeString("ry", 7.ToString());

            xmlWriter.WriteAttributeString("width", rectangleWidth.ToString());
            xmlWriter.WriteAttributeString("height", rectangleHeight.ToString());

            xmlWriter.WriteAttributeString("style", "fill:rgb(255,255,255);stroke-width:2;stroke:rgb(0,0,0)");

            xmlWriter.WriteEndElement();

            return (In, Out);
        }

        public ((double x, double y) In, (double x, double y) Out) GetInOut()
        {
            if (typeof(OrientationLR) == orientation.GetType())
            {
                In = (rectangleXPos - 5, rectangleYPos + rectangleHeight / 2);
                Out = (rectangleXPos + rectangleWidth, rectangleYPos + 20);
            }
            else if (typeof(OrientationRL) == orientation.GetType())
            {
                In = (rectangleXPos + rectangleWidth, rectangleYPos + 20);
                Out = (rectangleXPos - 5, rectangleYPos + rectangleHeight / 2);
            }
            else if (typeof(OrientationTD) == orientation.GetType())
            {
                In = (rectangleXPos + rectangleWidth / 2, rectangleYPos - 4);
                Out = (rectangleXPos + rectangleWidth / 2, rectangleYPos + rectangleHeight);
            }
            else if (typeof(OrientationDT) == orientation.GetType())
            {
                In = (rectangleXPos + rectangleWidth / 2, rectangleYPos + rectangleHeight);
                Out = (rectangleXPos + rectangleWidth / 2, rectangleYPos - 4);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return (In, Out);
        }
    }
}