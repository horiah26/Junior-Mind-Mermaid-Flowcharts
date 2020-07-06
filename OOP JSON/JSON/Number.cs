namespace JSON
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {            
            var eLetter = new Any("Ee");
            var dot = new Character('.');
            var signs = new Optional(new Any("+-"));
            var minus = new Optional(new Character('-'));
            var digits = new OneOrMore(new Range('0', '9'));

            var fractional = new Optional(new Sequence(dot, digits));

            var exponent = new Optional(new Sequence(eLetter, signs, digits));

            var number = new Choice(new Sequence(new Range('1', '9'), new Optional(digits), fractional),
                                    new Sequence(new Text("0."), digits),
                                    new Character('0'));     

            pattern = new Sequence(minus, number, exponent);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
