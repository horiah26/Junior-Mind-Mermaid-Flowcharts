using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    class ReadFromConsole
    {
        public ReadFromConsole()
        {
        }

        public void Read()
        {
            Console.WriteLine("Orientation? LeftRight / RightLeft / TopDown / DownTop");
            string orientation = Console.ReadLine();

            Console.WriteLine("File name? If empty, \"test\"");
            string fileName = Console.ReadLine();

            if(fileName.Trim() == "") 
            {
                fileName = "test"; 
            }

            var flowchart = Factory.Flowchart(orientation, fileName);
            GridSpacing.SetLarge();

            List<Subsystem> activeSubsystems = new List<Subsystem> { };

            while (true)
            {
                string line = Console.ReadLine().Trim();

                if (line != "")
                {
                    if (line == "end")
                    {
                        break;
                    }

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

            flowchart.DrawFlowchart();
        }
    }
}
