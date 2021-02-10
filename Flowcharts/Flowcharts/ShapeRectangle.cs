using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeRectangle : IShape
    {
        int rectangleLength = 0;
        private int distanceFromEdge ;
        private int unitLength;
        private int unitHeight;
        private XmlWriter xmlWriter;
        IOrientation orientation;

        (double x, double y) In;
        (double x, double y) Out;

        private double rectangleXPos;
        private double rectangleYPos;
        private int rectangleHeight;

        public ShapeRectangle() {}

        public ((double x, double y) In, (double x, double y) Out, int boxWidth) Draw(XmlWriter xmlWriter, IOrientation orientation, string text)
        {
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;

            (string[] lines, int numberOfLines) = new TextSplitter(text).Split();

            rectangleHeight = 40 + (numberOfLines - 1) * 17;

            rectangleLength = new RectangleLengthCalculator(lines).Calculate() * 9;
            (distanceFromEdge, unitLength, unitHeight) = new GridSpacer(orientation).GetSpacing();

            var position = orientation.GetColumnRow();
            (rectangleXPos, rectangleYPos) = GetPosition(position);
            (In, Out) = Draw();

            return (In, Out, rectangleLength);
        }

        public virtual (double rectangleXPos, double rectangleYPos) GetPosition((int Column, int Row) position)
        {
            rectangleXPos = distanceFromEdge + position.Column * unitLength + (unitLength - rectangleLength) / 2;
            rectangleYPos = distanceFromEdge + position.Row * unitHeight - 17;

            return (rectangleXPos, rectangleYPos);
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

            xmlWriter.WriteAttributeString("width", rectangleLength.ToString());
            xmlWriter.WriteAttributeString("height", rectangleHeight.ToString());

            Color();

            xmlWriter.WriteEndElement();

            return (In, Out);
        }

        virtual public void Color()
        {
            xmlWriter.WriteAttributeString("style", "fill:rgb(255,255,255);stroke-width:2;stroke:rgb(0,0,0)");
        }

        public ((double x, double y) In, (double x, double y) Out) GetInOut()
        {
            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (rectangleXPos - 5, rectangleYPos + rectangleHeight / 2);
                Out = (rectangleXPos + rectangleLength, rectangleYPos + 20);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (rectangleXPos + rectangleLength, rectangleYPos + 20);
                Out = (rectangleXPos - 5, rectangleYPos + rectangleHeight / 2);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (rectangleXPos + rectangleLength / 2, rectangleYPos - 4);
                Out = (rectangleXPos + rectangleLength / 2, rectangleYPos + rectangleHeight);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                In = (rectangleXPos + rectangleLength / 2, rectangleYPos + rectangleHeight);
                Out = (rectangleXPos + rectangleLength / 2, rectangleYPos - 4);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return (In, Out);
        }
    }
}