using System;
using System.Collections.Generic;
using System.Text;

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
            var sign = new Optional(new Any("-+"));

            var fractional = new Optional(new Sequence(dot, digits));
            var exponent = new Optional(new Sequence(eLetter, sign, digits));

            pattern = new Sequence(sign, digits, fractional, exponent);                           
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
