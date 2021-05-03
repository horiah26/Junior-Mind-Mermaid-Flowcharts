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

            string[] text;
            string path = null;

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

            var flowchart = Factory.Flowchart("LeftRight", "test");

            flowchart.AddPair(("Start", "Start", "Stadium"), ("A1", "A1", "Rectangle"), "Arrow");
            flowchart.AddPair("Start", ("A2", "A2", "Rectangle"), "Arrow");
            flowchart.AddPair("A2", ("C2", "C2", "Rectangle"), "Arrow");
            flowchart.AddPair("A1", ("B1", "B1", "Rectangle"), "Arrow");
            flowchart.AddPair("A1", ("B2", "B2", "Rectangle"), "Arrow");
            flowchart.AddPair("B1", ("C1", "C1", "Rectangle"), "Arrow");
            flowchart.AddPair("B2", ("C2", "C2", "Rectangle"), "SideArrow");

            flowchart.DrawFlowchart();
        }
    }
}