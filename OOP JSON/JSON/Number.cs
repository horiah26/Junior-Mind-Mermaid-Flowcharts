namespace JSON
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var dot = new Character('.');
            var eLetter = new Any("Ee");
            var minus = new Optional(new Character('-'));
            var signs = new Optional(new Any("-+"));

            var fractional = new Optional(new Sequence(dot, digits));

            var exponent = new Optional(new Sequence(eLetter, signs, digits));

            var integer = new Choice(new Sequence(new Range('1', '9'), digits),
                                     new Range('0', '9'));

            pattern = new Sequence(minus, integer, fractional, exponent);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}