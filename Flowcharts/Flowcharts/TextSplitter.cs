using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flowcharts
{
    public class TextSplitter
    {
        string text;
       
        public TextSplitter(string text)
        {
            this.text = text;
        }

        public (string[] lines, int numberOfLines) Split()
        {
            int maxCharactersInLine = 20;
            var lines = SplitToLines(text, maxCharactersInLine).ToArray();
            int numberOfLines = lines.Length;
            return (lines, numberOfLines);
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
