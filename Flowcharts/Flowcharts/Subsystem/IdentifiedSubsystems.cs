using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    public class IdentifiedSubsystems
    {
        readonly Element[,] ElementArray;

        public IdentifiedSubsystems(Element[,] ElementArray)
        {
            this.ElementArray = ElementArray;
        }

        public List<Subsystem> IdentifySubsystems()
        {
            List<Subsystem> subsystems = new List<Subsystem> { };

            foreach (var element in ElementArray)
            {
                if(element != null && element.Subsystems != null)
                {
                    foreach (var subsystem in element.Subsystems)
                    {
                        if (!subsystems.Contains(subsystem))
                        {
                            subsystems.Add(subsystem);
                        }
                    }
                }
            }

            return SubsystemOperations.ColorSubsystems(subsystems.Distinct().ToList());
        }
    }
}
