using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    public class IdentifiedSubsystems
    {
        public List<Subsystem> Subsystems { get; private set; }
        Element[,] ElementArray;

        public IdentifiedSubsystems(Element[,] ElementArray)
        {
            this.ElementArray = ElementArray;
        }

        public List<Subsystem> IdentifySubsystems()
        {
            List<Subsystem> subsystems = new List<Subsystem> { };

            foreach (var element in ElementArray)
            {
                if (element != null && element.Subsystem != null)
                {
                    subsystems.Add(element.Subsystem);
                }
            }

            return subsystems.Distinct().ToList();
        }
    }
}
