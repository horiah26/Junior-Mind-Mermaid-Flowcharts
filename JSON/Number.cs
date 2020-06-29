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
            IPattern num = new Range('0', '9');

            IPattern sign = new Optional(new Any("-+"));
            IPattern dot = new Optional(new Character('.'));
            IPattern numbers = new OneOrMore(num);

            IPattern fractional = new Optional(new Sequence(dot, numbers));

            IPattern exponent = new Optional(new Sequence( new Any("Ee"), sign, numbers));


            pattern = new Sequence(sign, numbers, fractional, exponent);                           
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
