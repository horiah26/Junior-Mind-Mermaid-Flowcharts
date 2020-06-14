using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace Range
{
    public class Range : IPattern
    {
        private char start; 
        private char end;
        Match match = new Match(false, "");

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }
        public IMatch Match(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                match.SetFalse();
            }

            if (text[0] >= start && text[0] <= end)
            {
                match.SetTrue();
            }

            return match;
        }
    }
    

}
