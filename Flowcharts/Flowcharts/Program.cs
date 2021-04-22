using System;
using System.IO;

namespace Flowcharts
{
    class Program
    {
        static void Main(string[] args)
        {
            string rectangle = "Rectangle";
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
            var flowchart = Factory.Flowchart("LeftRight", "test");

            flowchart.AddPair(("A", "A", rectangle), ("B", "B", rectangle), arrow);
            flowchart.AddPair(("A", "A", rectangle), ("C", "C", rectangle), arrow);
            flowchart.AddPair(("A", "A", rectangle), ("D", "D", rectangle), arrow);
            flowchart.AddPair("D", ("E", "E", rectangle), arrow);

            flowchart.DrawFlowchart();
        }
    }
}