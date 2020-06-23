using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Character : IPattern
    {
        readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (!string.IsNullOrEmpty(text) && text[0] == pattern)
            {
                return new Match(true, text.Substring(1));
            }
            else
            {
                return new Match(false, text);
            }
        }
    }
}
