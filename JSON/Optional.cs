using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Optional : IPattern
    {
        readonly IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return new Match(true, pattern.Match(text).RemainingText());
        }
    }
}
