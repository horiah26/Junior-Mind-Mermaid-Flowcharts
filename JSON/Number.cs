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
            IPattern minus = new Optional(new Character('-'));


            pattern = new Sequence(minus, num);                             
                                        
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
