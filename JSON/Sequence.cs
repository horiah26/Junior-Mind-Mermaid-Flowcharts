using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JSON
{
    public class Sequence : IPattern
    {
        readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            Match originalMatch = new Match(false, text);
            Match match = new Match(true, text);

            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            foreach (IPattern pattern in patterns)
            {
                match = (Match)pattern.Match(match.RemainingText());

                if (!match.Success())
                {
                    return originalMatch;
                }               
            }

            return match;
        }
    }
}