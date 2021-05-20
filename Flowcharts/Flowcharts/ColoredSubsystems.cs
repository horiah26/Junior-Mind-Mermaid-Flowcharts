using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    class ColoredSubsystems
    {
        public List<Subsystem> Subsystems { get; private set; }

        public ColoredSubsystems(List<Subsystem> subsystems)
        {
            Subsystems = GiveColor(subsystems);
        }

        public List<Subsystem> GiveColor(List<Subsystem> subsystems)
        {
            List<string> colors = new List<string> { "mediumslateblue", "green", "red", "mediumspringgreen", "orchid", "indigo", "teal", "mediumpurple", "orange", "darkslategray" };

            for (int i = 0; i < subsystems.Count() && i < 9; i++)
            {
                subsystems[i].Color = colors[i];
            }
            if (subsystems.Count() >= 9)
            {
                var random = new Random();
                for (int i = 9; i < subsystems.Count(); i++)
                {
                    int randomColorIndex = random.Next(9);
                    subsystems[i].Color = colors[randomColorIndex];
                }
            }

            return subsystems;
        }
    }
}
