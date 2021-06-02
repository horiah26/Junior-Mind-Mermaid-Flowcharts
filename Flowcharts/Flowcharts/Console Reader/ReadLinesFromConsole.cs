using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    class ReadLinesFromConsole
    {
        Flowchart flowchart;
        public ReadLinesFromConsole()
        {
        }

        public void ReadFromConsole()
        {
            string path = ReadPath();
            string fileName = ReadFilename();
            string orientation = ReadOrientation();

            List<Subsystem> activeSubsystems = new List<Subsystem> { };
            List<string> lines = new List<string> {path, orientation, fileName};

            while (true)
            {
                var line = Console.ReadLine().Trim();
                if(line == "end")
                {
                    break;
                }

                lines.Add(line);
            }

            flowchart = Factory.Flowchart(orientation, fileName, path);
            GridSpacing.SetLarge();

            for (int i = 3; i < lines.Count; i++)
            {
                ProcessLineFromConsole(lines[i], activeSubsystems);       
            }

            flowchart.DrawFlowchart();
        }

        private string ReadOrientation()
        {
            Console.WriteLine("Orientation? LeftRight / RightLeft / TopDown / DownTop");
            return Console.ReadLine().Trim();
        }

        public void ProcessLineFromConsole(string line, List<Subsystem> activeSubsystems)
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

        public string ReadPath()
        {
            Console.WriteLine("Desired SVG Path");
            string path = Console.ReadLine().Trim();

            if (path.Length == 0 || !path.Contains("\\") && path.Trim()[1] != ':')
            {
                path = null;
            }

            return path;
        }

        public string ReadFilename()
        {

            Console.WriteLine("File name? If empty, \"test\"");
            string fileName = Console.ReadLine();

            if (fileName.Trim() == "")
            {
                fileName = "test";
            }

            return fileName;
        }
    }
}
