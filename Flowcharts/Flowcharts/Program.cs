using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Flowcharts
{
    class Program
    {
        static void Main()
        {

            var flowchart = new Flowchart("test");

            flowchart.AddPair("a", "q");
            flowchart.AddPair("a", "u");
            flowchart.AddPair("a", "b");
            flowchart.AddPair("b", "c");
            flowchart.AddPair("b", "d");
            flowchart.AddPair("b", "e");
            flowchart.AddPair("b", "f");
            flowchart.AddPair("d", "g");
            flowchart.AddPair("d", "h");
            flowchart.AddPair("e", "w");
            flowchart.AddPair("e", "y");
            flowchart.AddPair("e", "x");
            flowchart.AddPair("l", "f");
            flowchart.AddPair("m", "f");
            flowchart.AddPair("w", "v");
            flowchart.AddPair("h", "v"); 
            flowchart.AddPair("w", "z");
            flowchart.AddPair("h", "z");

            flowchart.Draw();
        }
    }
}