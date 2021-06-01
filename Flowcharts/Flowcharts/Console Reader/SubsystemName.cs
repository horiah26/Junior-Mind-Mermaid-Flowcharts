using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    class SubsystemName
    {
        readonly string line;

        public SubsystemName(string line)
        {
            this.line = line;
        }
        public string GetSubsystemName()
        {
            int positionOfSubsystem = line.ToLower().IndexOf("subsystem");
            return line[(positionOfSubsystem + 9)..].Trim();
        }
    }
}
