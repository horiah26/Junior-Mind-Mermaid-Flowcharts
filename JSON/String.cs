using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            var comma = new Text("\"");

            var letter = new Choice(new Range('a', 'z'), new Range('A', 'Z'));

            var hexadecimal = new Choice(new Range('a', 'f'), new Range('A', 'F'), new Range('0', '9'));

            var unicode = new Sequence(new Text("\\u"), hexadecimal, hexadecimal, hexadecimal, hexadecimal);

            var specials = 
                new Choice(
                 unicode,
                 new Text("\\\\ "),
                 new Text("\\\""),
                 new Text("\\/"),
                 new Text("\\b"),
                 new Text("\\f"),
                 new Text("\\n"),
                 new Text("\\r"),
                 new Text("\\t"),
                 new Text(" "));

            var lettersOrComma = new Many(new Choice(letter, specials));

            pattern = new Sequence(comma, lettersOrComma, comma);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
