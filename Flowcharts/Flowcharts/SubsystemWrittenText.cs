using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Flowcharts
{
    public class SubsystemWrittenText : WrittenText
    {
        readonly string color;
        public SubsystemWrittenText(double xPosition, double yPosition, string[] lines, string color) : base(xPosition, yPosition, lines)
        {
            this.color = color;
        }

        public override void Color()
        {
            xmlWriter.WriteAttributeString("fill", color);
            xmlWriter.WriteAttributeString("font-size", "40px");
        }
    }
}
