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
            IMatch originalMatch = new Match(false, text);
            IMatch match = new Match(true, text);

            foreach (IPattern pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());

                if (!match.Success())
                {
                    return originalMatch;
                }               
            }

            return match;
        }
    }
}