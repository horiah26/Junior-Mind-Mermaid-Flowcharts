using System;
using System.Collections.Generic;
using System.Text;

namespace Range
{

    public class Character : IPattern
    {
        readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        Match match = new Match(true, "");

        IMatch IPattern.Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                match.IsFalse();
                return match;
            }

            text[0] == pattern ? match.IsTrue() : match.IsFalse()


            return match;
             
        }
    }
}
