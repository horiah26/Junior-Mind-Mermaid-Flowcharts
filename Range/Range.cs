using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace Range
{
    public class Range
    {
        private char start;
        private char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public bool Match(string text)
        {
            if(String.IsNullOrEmpty(text))
            {
                throw new System.ArgumentException("Parameter cannot be null or empty");
            }

            if(text[0] >= start && text[0] <= end)
            {
                return true;
            }

            return false;
        }
    }

}
