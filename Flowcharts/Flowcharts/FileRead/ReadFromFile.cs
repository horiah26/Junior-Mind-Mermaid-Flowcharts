using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Flowcharts
{
    public class ReadFromFile
    {
        readonly string[] lines;

        public ReadFromFile(string[] lines)
        {
            this.lines = lines;
        }

        public IEnumerable<ElementSpecs> GetSpecs()
        {
            var elementSpecs = new List<ElementSpecs>() { };

            foreach (var line in lines)
            {
                if(line.Length > 0)
                {
                    var trimmedLine = TrimLine(line);
                    var element1 = ExtractFirstElementFromLine(trimmedLine);
                    var element2 = ExtractSecondElementFromLine(trimmedLine);
                    var arrowAndText = ExtractArrowAndText(trimmedLine);

                    elementSpecs.Add(ConsoleOperations.CreateElementSpecs(element1, element2, arrowAndText));
                }
            }

            return elementSpecs;
        }

        public IEnumerable<string> ExtractFirstElementFromLine(string line)
        {
            int from = line.IndexOf("(");
            int to = line.IndexOf("\")");

            string element1 = line.Substring(from + 1, to - from);

            return ExtractSpecs(element1);
        }

        public IEnumerable<string> ExtractSecondElementFromLine(string line)
        {
            int from = line.LastIndexOf("(\"");
            int to = line.LastIndexOf("\")");

            string element2 = line.Substring(from + 1, to - from);

            return ExtractSpecs(element2);
        }

        public IEnumerable<string> ExtractSpecs(string str)
        {
            var reg = new Regex("\".*?\"");
            var matches = reg.Matches(str);

            List<string> elementSpecs = new List<string>() { };

            foreach (var item in matches)
            {
                string stringedItem = item.ToString();
                elementSpecs.Add(stringedItem[1..^1]);
            }

            return elementSpecs;
        }

        public string[] ExtractArrowAndText(string line)
        {
            int endOfElement2 = line.LastIndexOf("\")");

            var arrowAndText = line[(endOfElement2 + 3)..].Trim().Split(",");

            for(int i = 0; i< arrowAndText.Length; i++)
            {
                arrowAndText[i] = arrowAndText[i].Trim();
                arrowAndText[i] = arrowAndText[i][1..^1];
            }  

            return arrowAndText;
        }

        public string TrimLine(string line)
        {
            line = line.Trim();
            line = line.Replace(");", "");
            line = line.Replace("( \"", "(\"");

            if (line.IndexOf("((") == 0 && line.LastIndexOf(")") == line.Length - 1)
            {
                line = line[1..^1];
            }

            return line;
        }
    }
}