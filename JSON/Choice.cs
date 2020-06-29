using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace JSON
{
    public class Choice : IPattern
    {
        readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            IMatch match = new Match(false, text);

            foreach (var pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());

                if (match.Success())
                {
                    return new Match(true, match.RemainingText());
                }
            }

            return match;
        }
    }
}