using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Flowcharts
{
    class Program
    {
        static void Main()
        {         
            Flowchart flowchart = new Flowchart("test");
            flowchart.Orientation("LR");

            flowchart.AddPair(("A", "Circle"), ("B", "Rectangle"), "A to B");
            flowchart.AddPair(("A", "Circle"), ("CDEFGHSI", "Circle"), "Text");
            flowchart.AddPair(("A", "Circle"), ("ASDASDA", "Circle"), "Another text");

            flowchart.Draw();
        }
    }
}