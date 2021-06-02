using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    static class ConsoleOperations
    {
        public static string GetSubsystemName(string line)
        {
            return new SubsystemName(line).GetSubsystemName();
        }

        public static Subsystem CreateSubsystem(string subsystemName)
        {
            return new Subsystem(subsystemName);
        }

        public static void ProcessLine(Flowchart flowchart, string line, List<Subsystem> activeSubsystems)
        {
            new ProcessLine(flowchart, line, activeSubsystems).Process();
        }

        public static string[] BreakLineIntoComponents(string line)
        {
            return new LineComponents(line).SeparateLineComponents();
        }

        public static (string key, string text, string shape) GetElement(string component, Flowchart flowchart)
        {
            return new ComponentToElementSpecs(component, flowchart).GetComponents();
        }

        public static void AddToFlowchart(Flowchart flowchart, List<Subsystem> subsystems, (string key, string text, string shape) element1, (string key, string text, string shape) element2, string arrow, string text)
        {
            new LineToFlowchart(flowchart, subsystems, element1, element2, arrow, text).AddToFlowchart();
        }

        public static void ReadFromConsole()
        {
            new ReadLinesFromConsole().ReadFromConsole();
        }

        public static void ReadArgs(string[] lines)
        {
            new ReadLinesFromArgs(lines).ReadFromFile();
        }
    }
}
