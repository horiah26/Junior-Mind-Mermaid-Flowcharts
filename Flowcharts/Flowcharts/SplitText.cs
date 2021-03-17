using System.Collections.Generic;
using System.Linq;

namespace Flowcharts
{
    public class SplitText
    {
        readonly string text;
       
        public SplitText(string text)
        {
            this.text = text;
        }

        public string[] GetLines()
        {
            int maxCharactersInLine = 20;
            var lines = SplitToLines(text, maxCharactersInLine).ToArray();
            return lines;
        }

        IEnumerable<string> SplitToLines(string stringToSplit, int maximumLineLength)
        {
            var words = stringToSplit.Split(' ');
            var line = words.First();
            foreach (var word in words.Skip(1))
            {
                var test = $"{line} {word}";
                if (test.Length > maximumLineLength)
                {
                    yield return line;
                    line = word;
                }
                else
                {
                    line = test;
                }
            }
            yield return line;
        }
    }
}
