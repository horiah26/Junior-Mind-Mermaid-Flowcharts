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

        public (string[] lines, int numberOfLines) SplitWords()
        {
            var charCount = 0;
            var maxLineLength = 20;

            var lines = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .GroupBy(w => (charCount += w.Length + 1) / maxLineLength)
                            .Select(g => string.Join(" ", g)).ToArray();

            int numberOfLines = lines.Length;
            return (lines, numberOfLines);
        }
    }
}
