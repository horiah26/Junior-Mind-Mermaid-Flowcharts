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
            var flowchart = new Flowchart("filename");
            flowchart.AddPair(0, 0, "A", 1, 0, "B");
        }
    }
}