using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public class LineComponents
    {
        readonly string line;
        public LineComponents(string line)
        {
            this.line = line;
        }

        public string[] SeparateLineComponents()
        {
            string element1 = null;
            string element2 = null;

            string secondHalf = null;
            string arrow = null;
            string text = null;

            if (line.IndexOf("/-->") != -1)
            {
                var index = line.IndexOf("/-->");
                element1 = line.Substring(0, index).Trim();
                secondHalf = line[(index + 4)..].Trim();
                (text, element2) = SeparateArrowTextFromElement2(secondHalf);
                arrow = "SideArrow";
            }
            else if(line.IndexOf("-->") != -1)
            {
                var index = line.IndexOf("-->");
                element1 = line.Substring(0, index).Trim();
                secondHalf = line[(index + 3)..].Trim();
                (text, element2) = SeparateArrowTextFromElement2(secondHalf);
                arrow = "Arrow";
            }
            else if (line.IndexOf("<--") != -1)
            {
                var index = line.IndexOf("<--");
                element1 = line.Substring(0, index).Trim();
                secondHalf = line[(index + 3)..].Trim();
                (text, element2) = SeparateArrowTextFromElement2(secondHalf);
                arrow = "BackArrow";
            }
            else if (line.IndexOf("---") != -1)
            {
                var index = line.IndexOf("---");
                element1 = line.Substring(0, index).Trim();
                secondHalf = line[(index + 3)..].Trim();
                (text, element2) = SeparateArrowTextFromElement2(secondHalf);
                arrow = "Link";
            }
            else if (line.IndexOf("-.->") != -1)
            {
                var index = line.IndexOf("-.->");
                element1 = line.Substring(0, index).Trim();
                secondHalf = line[(index + 4)..].Trim();
                (text, element2) = SeparateArrowTextFromElement2(secondHalf);
                arrow = "DottedLink";
            }
            else if (line.IndexOf("==>") != -1)
            {
                var index = line.IndexOf("==>");
                element1 = line.Substring(0, index).Trim();
                secondHalf = line[(index + 3)..].Trim();
                (text, element2) = SeparateArrowTextFromElement2(secondHalf);
                arrow = "ThickLink";
            }

            return new string[] { element1, element2, arrow, text };
        }

        (string text, string element2) SeparateArrowTextFromElement2(string secondHalf)
        {
            string text = null;
            string element2 = secondHalf;
            int textStart = secondHalf.IndexOf("|");
            int textEnd = secondHalf.LastIndexOf("|");

            if (textStart != textEnd)
            {
                text = secondHalf.Substring(textStart + 1, textEnd - textStart - 1).Trim();
                element2 = secondHalf[(textEnd + 1)..].Trim();
            }

            return (text, element2);
        }
    }
}
