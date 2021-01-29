using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    class DrawBox
    {
        readonly XmlWriter xmlWriter;
        readonly double rectangleXPos;
        readonly double rectangleYPos;
        readonly int rectangleWidth;
        readonly int rectangleHeight;
        readonly IOrientation orientation;
        readonly string color;

        public DrawBox(XmlWriter xmlWriter, double rectangleXPos, double rectangleYPos, int rectangleWidth, int rectangleHeight, IOrientation orientation, string color = "white")
        {
            this.xmlWriter = xmlWriter;
            this.rectangleXPos = rectangleXPos;
            this.rectangleYPos = rectangleYPos;
            this.rectangleWidth = rectangleWidth;
            this.rectangleHeight = rectangleHeight;
            this.orientation = orientation;
            this.color = color;
        }

        public void Draw()
        {     
            xmlWriter.WriteStartElement("rect");     

            xmlWriter.WriteAttributeString("x", rectangleXPos.ToString());
            xmlWriter.WriteAttributeString("y", rectangleYPos.ToString());

            xmlWriter.WriteAttributeString("rx", 7.ToString());
            xmlWriter.WriteAttributeString("ry", 7.ToString());

            xmlWriter.WriteAttributeString("width", rectangleWidth.ToString());
            xmlWriter.WriteAttributeString("height", rectangleHeight.ToString());

            if(color == "gray")
            {
                xmlWriter.WriteAttributeString("style", "fill:rgb(220,220,220)");
            }
            else
            {
                xmlWriter.WriteAttributeString("style", "fill:rgb(255,255,255);stroke-width:2;stroke:rgb(0,0,0)");
            }

            xmlWriter.WriteEndElement();
        }
    }
}
