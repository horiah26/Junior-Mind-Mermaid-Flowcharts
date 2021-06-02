using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    class ReadLinesFromArgs
    {
        readonly string inputLocation;
        readonly string writeTo = null;
        string[] lines;

        Flowchart flowchart;
        List<Subsystem> activeSubsystems = new List<Subsystem> { };

        public ReadLinesFromArgs(string[] args)
        {
            inputLocation = args[0];

            if (args.Length > 1)
            {
                writeTo = args[1];
            }
            else
            {
                writeTo = Path.GetDirectoryName(inputLocation) + "\\";
            }
        }

        public void ReadFromFile()
        {
            lines = File.ReadAllLines(inputLocation);
            string fileName = lines[0];
            string orientation = lines[1];

            flowchart = Factory.Flowchart(orientation, fileName, writeTo);
            GridSpacing.SetLarge();
                       
            for (int i = 2; i < lines.Length; i++)
            {
                if (lines[i].ToLower() == "end")
                {
                    break;
                }

                ProcessLineFromConsole(lines[i]);
            }

            flowchart.DrawFlowchart();
        }

        public void ProcessLineFromConsole(string line)
        {
            if (line != null && line != "")
            {
                if (line.ToLower().IndexOf("subsystem") == 0)
                {
                    string subsystemName = ConsoleOperations.GetSubsystemName(line);
                    activeSubsystems.Add(ConsoleOperations.CreateSubsystem(subsystemName));
                }
                else if (line.ToLower().IndexOf("end subsystem") == 0)
                {
                    string subsystemName = ConsoleOperations.GetSubsystemName(line);
                    activeSubsystems = activeSubsystems.Where(x => x.Name != subsystemName).ToList();
                }
                else
                {
                    ConsoleOperations.ProcessLine(flowchart, line, activeSubsystems);
                }
            }
        }
    }
}
