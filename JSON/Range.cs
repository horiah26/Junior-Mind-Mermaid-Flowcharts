using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace JSON
{
    public class Range : IPattern
    {
        private char start;
        private char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            if (text[0] >= start && text[0] <= end)
            {
                return new Match(true, text.Substring(1));
            }

            return new Match(false, text);
        }
    }

}
