using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public class LineToFlowchart
    {
        (string key, string text, string shape) element1;
        (string key, string text, string shape) element2;
        readonly string arrow;
        readonly string text;
        readonly Flowchart flowchart;
        readonly List<Subsystem> subsystems;

        public LineToFlowchart(Flowchart flowchart, List<Subsystem> subsystems, (string key, string text, string shape) element1, (string key, string text, string shape) element2, string arrow, string text)
        {
            this.element1 = element1;
            this.element2 = element2;
            this.arrow = arrow;
            this.text = text;
            this.flowchart = flowchart;
            this.subsystems = subsystems;
        }

        public void AddToFlowchart()
        {
            if (element1.text == null || element1.shape == null)
            {
                flowchart.AddPair(element1.key, element2, arrow, text);
            }
            else if (element2.text == null || element2.shape == null)
            {
                flowchart.AddPair(element1, element2.key, arrow, text);
            }
            else
            {
                flowchart.AddPair(element1, element2, arrow, text);
            }

            if(subsystems.Count > 0)
            {
                foreach(var subsystem in subsystems)
                {
                    flowchart.AddSubsystem(element1.key, subsystem);
                    flowchart.AddSubsystem(element2.key, subsystem);
                }
            }
        }
    }
}
