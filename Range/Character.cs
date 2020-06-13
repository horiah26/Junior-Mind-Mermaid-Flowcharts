using System;
using System.Collections.Generic;
using System.Text;

namespace Range
{
    public class Character : IPattern
    {
        readonly char pattern;
        Match match = new Match(false, "");

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                match.SetFalse();
                return match;
            }
            if (text[0] == pattern)
            {
                match.SetTrue();
                Remaining(text, pattern);
            }
            else 
            {
                match.SetFalse();
            }

            return match;             
        }

        private void Remaining(string text, char pattern)
        {
            match.SetRemaining(text.Remove(0, 1));
        }
    }
}
