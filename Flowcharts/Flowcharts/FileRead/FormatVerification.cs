using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Flowcharts
{
    class FormatVerification
    {
        readonly string[] lines;
        readonly List<string> orientations = new List<string> { "LeftRight", "RightLeft", "TopDown", "DownTop" };

        public FormatVerification(string[] lines)
        {
            this.lines = lines;
        }

        public void CheckIfGoodFormat()
        {
            if(lines.Length == 0)
            {
                throw new InputFormatException("File is empty");
            }
            if (lines.Where(x=> x.Trim() != "").ToList().Count < 3) 
            {
                throw new InputFormatException("File must have at least 3 lines");
            }
            if (lines[0].Trim() == "" || lines[0] == null)
            {
                throw new InputFormatException("The first line is the resulting SVG filename and cannot be empty");
            }
            if(!orientations.Contains(lines[1]))
            {
                throw new InputFormatException("The second line must be one of the following: LeftRight, RightLeft, TopDown or DownTop");
            }

            for (int i = 2; i< lines.Length; i++)
            {
                string line = lines[i].Trim();

                if(line.ToLower() == "end")
                {
                    break;
                }

                if(line != "" && !ContainsArrow(line) && !ContainsSubsystem(line))
                {
                    throw new InputFormatException("Line must contain one of the following: \"-->\", \"/-->\", \"<--\", \"==>\", \"---\", \"-.->\", \"end\", \"subsystem\" or \"end subsystem\"");
                }               
            }
        }

        public bool ContainsArrow(string line)
        {
            if (line.Contains("-->") ||
                line.Contains("<--") ||
                line.Contains("==>") ||
                line.Contains("-.->") ||
                line.Contains("---"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ContainsSubsystem(string line)
        {
            if (line.ToLower().IndexOf("subsystem") == 0 || line.ToLower().IndexOf("end subsystem") == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
