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
            IMatch match = new Match(true, text);

            while (match.Success())
            {
                match = pattern.Match(match.RemainingText());
            }

            return new Match(true, match.RemainingText());
        }
    }

}
