using System;
using System.IO;

namespace Flowcharts
{
    class Program
    {
        static void Main(string[] args)
        {
            string shape = "Banner";
            string arrow = "Arrow";

            //string[] text;
            //string path = null;

            //if (args.Length > 0)
            //{
            //    if (args.Length == 2)
            //    {
            //        path = args[1];
            //    }

            //    int lastDash = args[0].LastIndexOf("\\") + 1;
            //    int extension = args[0].LastIndexOf(".");
            //    string fileName = args[0][lastDash..extension];

            //    text = System.IO.File.ReadAllLines(args[0]);
            //    var reader = new ReadFromFile(text).GetSpecs();
            //    var flowchart = Factory.Flowchart("TopDown", fileName, path);
            //    new SpecsToFlowchart(flowchart, reader).AddToFlowchart();
            //    flowchart.DrawFlowchart();
            //}
            //

            var flowchart = Factory.Flowchart("TopDown", "test");
            shape = "Subroutine";
            flowchart.AddPair(("A", "A", shape), ("B", "BB", shape), arrow);
            flowchart.AddPair(("A2", "AAAAAAAA", shape), ("B2", "BBB BBBBBB BBBBBB BBBBBB BB", shape), arrow);
            flowchart.AddPair(("A4", "AAA AAAAAA A A AAAAAA A AA AAAA AAAAA AA AAAAA AAAA", shape), ("B4", "BBBB BBBB BBBB BBBBBBB BBBBBB BBBBB BBBB BBB BB BBB", shape), arrow);

            flowchart.DrawFlowchart();
        }
    }
}