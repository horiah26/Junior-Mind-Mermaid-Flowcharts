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
            flowchart.Orientation("TD");

            flowchart.AddPair("Christmas", "Go shopping");
            flowchart.AddPair("Go shopping", "Let me think");

            flowchart.AddPair("Let me think", "Laptop");
            flowchart.AddPair("Let me think", "iPhone");
            flowchart.AddPair("Let me think", "Car");

            flowchart.AddBackPair("Laptop", "Christmas");

            flowchart.Draw();
        }
    }
}