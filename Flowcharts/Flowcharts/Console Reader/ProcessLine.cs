using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public class ProcessLine
    {
        readonly string line;
        readonly List<Subsystem> activeSubsystems;
        readonly Flowchart flowchart;

        public ProcessLine(Flowchart flowchart, string line, List<Subsystem> activeSubsystems)
        {
            this.flowchart = flowchart;
            this.line = line;
            this.activeSubsystems = activeSubsystems;
        }

        public void Process()
        {
            var lineComponents = ConsoleOperations.BreakLineIntoComponents(line);

            (string key1, string text1, string shape1) = ConsoleOperations.GetElement(lineComponents[0], flowchart);
            (string key2, string text2, string shape2) = ConsoleOperations.GetElement(lineComponents[1], flowchart);
            string arrow = lineComponents[2];
            string text = lineComponents[3];

            ConsoleOperations.AddToFlowchart(flowchart, activeSubsystems, (key1, text1, shape1), (key2, text2, shape2), arrow, text);
        }
    }
}
