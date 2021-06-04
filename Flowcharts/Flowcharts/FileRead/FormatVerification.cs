using System;
using System.Collections.Generic;
using System.Text;

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
            if (lines.Length == 1)
            {
                throw new InputFormatException("Input file cannot have only one line");
            }
            if (lines[0].Trim() == "" || lines[0] == null)
            {
                throw new InputFormatException("The first line is the output file name and cannot be empty");
            }
            if(!orientations.Contains(lines[1]))
            {
                throw new InputFormatException("The second line is the flowchart orientation and must be either LeftRight, RightLeft, TopDown or DownTop");
            }

            for (int i = 2; i< lines.Length; i++)
            {
                string line = lines[i].Trim();

                if(line == "end")
                {
                    break;
                }

                if(line != "" && !ContainsArrow(line) && !ContainsSubsystem(line))
                {
                    throw new InputFormatException("Line must contain either one of the arrow symbols or subsystem commands");
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
