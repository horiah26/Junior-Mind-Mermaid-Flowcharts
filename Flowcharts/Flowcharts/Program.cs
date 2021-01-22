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

            flowchart.AddPair("A", "B");
            flowchart.AddPair("B", "C", "E");
            flowchart.AddPair("B", "D", "Text on arrow");

            flowchart.Draw();
        }
    }
}