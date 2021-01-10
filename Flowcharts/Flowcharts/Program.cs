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
                                

            flowchart.AddPair("B", "F");
            flowchart.AddPair("B", "E");
            flowchart.AddPair("F", "n");
            flowchart.AddPair("E", "H");
            flowchart.AddPair("E", "h");
            flowchart.AddPair("E", "hh");
            flowchart.AddPair("Q", "hh");

            flowchart.Draw();   
        }
    }
}