﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class DottedLink : Arrow
    {
        public DottedLink(XmlWriter xmlWriter, Element fromElement, Element toElement, string text) : base(xmlWriter, fromElement, toElement, text)
        {

        }

        public override void Draw()
        {
            var points = GetArrowEnds();

            xmlWriter.WriteStartElement("line");

            xmlWriter.WriteAttributeString("x1", points[0]);
            xmlWriter.WriteAttributeString("y1", points[1]);
            xmlWriter.WriteAttributeString("x2", points[2]);
            xmlWriter.WriteAttributeString("y2", points[3]);

            xmlWriter.WriteAttributeString("stroke", "#000");
            xmlWriter.WriteAttributeString("stroke-width", "3");
            xmlWriter.WriteAttributeString("stroke-dasharray", "10,10");
            xmlWriter.WriteEndElement();
        }
    }
}