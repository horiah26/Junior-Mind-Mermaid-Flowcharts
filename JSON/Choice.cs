using System;

namespace JSON
{
    public class Choice : IPattern
    {
        IPattern[] patterns;

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

        public void Add(IPattern newPattern)
        {
            Array.Resize(ref patterns, patterns.Length + 1);

            for (int i = patterns.Length - 1; i >= 1; i--)
            {
                patterns[i] = patterns[i - 1];
            }

            patterns[0] = newPattern;
        }
    }
}