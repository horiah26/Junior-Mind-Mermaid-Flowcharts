using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    public class DrawnSubsystem
    {
        Subsystem subsystem;
        Element[,] ElementArray;
        readonly XmlWriter xmlWriter = Writer.XmlWriter;

        public DrawnSubsystem(Subsystem subsystem, Element[,] ElementArray)
        {
            this.subsystem = subsystem;
            this.ElementArray = ElementArray;
        }

        public void Draw()
        {
            var coordinates = SubsystemOperations.GetSubsystemPosition(ElementArray, subsystem); 
            string color = subsystem.Color;

            xmlWriter.WriteStartElement("polygon");
            xmlWriter.WriteAttributeString("points", coordinates);
            xmlWriter.WriteAttributeString("style", "fill:transparent;stroke:" + color + ";stroke-width:5");
            xmlWriter.WriteEndElement();
            WriteSubsystemName();
        }

        public void WriteSubsystemName()
        {
            var textPosition = SubsystemOperations.GetSubsystemTextPosition(ElementArray, subsystem); 
            string[] subsystemName = new string[] { subsystem.Name };
            new SubsystemWrittenText(textPosition.xPos, textPosition.yPos, subsystemName, subsystem.Color).Write();
        }
    }
}