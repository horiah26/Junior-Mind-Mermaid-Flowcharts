﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class ShapeCircle : IShape
    {
        private int distanceFromEdge;
        private int unitLength;
        private int unitHeight;
        
        private XmlWriter xmlWriter;
        IOrientation orientation;

        (double x, double y) In;
        (double x, double y) Out;

        int xPos;
        int yPos;
        int radius;

        public ShapeCircle() { }

        public ((double x, double y) In, (double x, double y) Out, int boxWidth) Draw(XmlWriter xmlWriter, IOrientation orientation, string Text, int numberOfLines)
        {
            (distanceFromEdge, unitLength, unitHeight) = new GridSpacer(orientation).GetSpacing();
            this.xmlWriter = xmlWriter;
            this.orientation = orientation;   
            var position = orientation.GetColumnRow();
            radius = new CircleRadiusCalculator(Text).Calculate(); ;

            if (Text.Length == 1)
            {
                xPos = distanceFromEdge + position.Column * unitLength + unitLength / 2 + 5;
                yPos = distanceFromEdge + position.Row * unitHeight + numberOfLines * 5 - 3;
            }
            else
            {
                xPos = distanceFromEdge + position.Column * unitLength + unitLength / 2 + radius / 4 + 5;
                yPos = distanceFromEdge + position.Row * unitHeight + numberOfLines * 5;
            }
   
            (In, Out) = Draw();

            return (In, Out, radius);
        }

        public ((double x, double y) In, (double x, double y) Out) Draw()
        {
            (double x, double y) In;
            (double x, double y) Out;

            xmlWriter.WriteStartElement("circle");

            (In, Out) = GetInOut();

            xmlWriter.WriteAttributeString("cx", xPos.ToString());
            xmlWriter.WriteAttributeString("cy", yPos.ToString());

            xmlWriter.WriteAttributeString("r", radius.ToString().ToString());
            xmlWriter.WriteAttributeString("stroke", "black");

            xmlWriter.WriteAttributeString("stroke-width", "3");
            xmlWriter.WriteAttributeString("fill", "white");

            xmlWriter.WriteEndElement();

            return (In, Out);
        }

        public ((double x, double y) In, (double x, double y) Out) GetInOut()
        {
            if (typeof(OrientationLeftRight) == orientation.GetType())
            {
                In = (xPos - radius - 3, yPos);
                Out = (xPos + radius, yPos);
            }
            else if (typeof(OrientationRightLeft) == orientation.GetType())
            {
                In = (xPos + radius + 5, yPos);
                Out = (xPos - radius, yPos);
            }
            else if (typeof(OrientationTopDown) == orientation.GetType())
            {
                In = (xPos, yPos - radius - 4);
                Out = (xPos, yPos + radius);
            }
            else if (typeof(OrientationDownTop) == orientation.GetType())
            {
                Out = (xPos, yPos - radius);
                In = (xPos, yPos + radius + 4);
            }
            else
            {
                throw new FormatException("Orientation has not been writeen correctly");
            }

            return (In, Out);
        }
    }
}