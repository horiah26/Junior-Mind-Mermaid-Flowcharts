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
            flowchart.Orientation("BT");

            flowchart.AddPair("A", "B");
            flowchart.AddPair("B", "C");
            flowchart.AddPair("B", "D");

            flowchart.Draw();
        }
    }
}