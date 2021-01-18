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

            flowchart.AddPair("Start", "Is it?");
            flowchart.AddPair("Is it?", "End");
            flowchart.AddPair("Is it?", "OK");


            flowchart.AddPair("OK", "Rethink");

            flowchart.AddBackPair("Rethink", "Is it?");

            flowchart.Draw();
        }
    }
}