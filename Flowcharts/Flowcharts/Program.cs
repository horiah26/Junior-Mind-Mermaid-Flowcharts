using System;
using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    class Program
    {
        static void Main(string[] args)
        {            
            if (args.Length > 0)
            {
                string path = null;

                if (args.Length == 2)
                {
                    path = args[1];
                }

                int lastDash = args[0].LastIndexOf("\\") + 1;
                int extension = args[0].LastIndexOf(".");
                string fileName = args[0][lastDash..extension];

                string[]  text = System.IO.File.ReadAllLines(args[0]);
                var reader = new ReadFromFile(text).GetSpecs();
                var flowchart = Factory.Flowchart("TopDown", fileName, path);
                new SpecsToFlowchart(flowchart, reader).AddToFlowchart();
                flowchart.DrawFlowchart();
            }        

            ConsoleOperations.Read();
        }
    }
}