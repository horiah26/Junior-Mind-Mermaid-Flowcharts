using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Many : IPattern
    {
        IPattern pattern;
        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            Match match = new Match(true, text);

            while (pattern.Match(text).Success())
            {
                text = text.Substring(1);
                match = new Match(true, text);
            }

            return match;
        }
    }

}
