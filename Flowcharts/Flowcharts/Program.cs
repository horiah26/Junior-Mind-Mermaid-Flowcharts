using System;
using System.Xml;

namespace Flowcharts
{
    class Program
    {
        static void Main()
        {
            string consoleInput = Console.ReadLine();
            
            using (XmlWriter xmlWriter = XmlWriter.Create("svgImage.svg"))
            {
                const string svgNs = "http://www.w3.org/2000/svg";

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("svg", svgNs);

                xmlWriter.WriteAttributeString("width", "width", "300");
                xmlWriter.WriteAttributeString("height", "height", "100");

                xmlWriter.WriteStartElement("rect");
                xmlWriter.WriteAttributeString("width", "300");
                xmlWriter.WriteAttributeString("height", "100");
                xmlWriter.WriteAttributeString("style", "fill:rgb(255,255,255);stroke-width:8;stroke:rgb(0,0,0)");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("text");
                xmlWriter.WriteAttributeString("x", "50");
                xmlWriter.WriteAttributeString("y", "50");
                xmlWriter.WriteAttributeString("fill", "red");
                xmlWriter.WriteString(consoleInput);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }       
        }
    }
}
