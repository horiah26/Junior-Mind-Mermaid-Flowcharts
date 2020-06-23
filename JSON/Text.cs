using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Text : IPattern
    {
        string prefix;
        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            return  !string.IsNullOrEmpty(text) && prefix.Length <= text.Length && prefix == text.Substring(0, prefix.Length) 
            ? new Match(true, text.Substring(prefix.Length))
            : new Match(false, text);
        }
    }

}
