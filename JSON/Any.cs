using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Any : IPattern
    {
        string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }
            foreach(char c in accepted)
            {
                if (text[0] == c)
                {
                    return new Match(true, text.Substring(1));
                }
            }

            return new Match(false, text);            
        }
    }
}

