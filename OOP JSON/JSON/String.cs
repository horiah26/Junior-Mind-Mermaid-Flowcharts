namespace JSON
{
    public class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            var comma = new Text("\"");

            var hexadecimal = new Choice(new Range('a', 'f'), new Range('A', 'F'), new Range('0', '9'));

            var unicode = new Sequence(new Text("\\u"), hexadecimal, hexadecimal, hexadecimal, hexadecimal);

            var codepoints = new Choice(new Range('#','['),
                                        new Range(']', (char)ushort.MaxValue),
                                        new Any("! "));

            var elements = new Choice(unicode,
                                      codepoints,
                                      new Text("\\\\"),
                                      new Text("\\\""),
                                      new Sequence(new Text("\\"), new Any("bfnrt/")));

            pattern = new Sequence(comma, new Many(elements), comma);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
