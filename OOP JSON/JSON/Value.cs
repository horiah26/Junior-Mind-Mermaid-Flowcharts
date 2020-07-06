namespace JSON
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var whitespace = new Many(new Any(" \n\r\t"));

            var value = new Choice(new String(), 
                                   new Number(), 
                                   new Text("null"), 
                                   new Text("true"), 
                                   new Text("false"));

            var objectValue = new Sequence(whitespace, 
                                        new String(), 
                                        whitespace, 
                                        new Character(':'), 
                                        whitespace,
                                        value,
                                        whitespace);

            var objectList = new Sequence(whitespace, new List(objectValue, new Character(',')), whitespace);           

            var obj = new Sequence(new Character('{'), 
                                   new Choice (objectList, whitespace), 
                                   new Character('}'));
  
            var arrayList = new List(new Sequence(whitespace, value, whitespace), new Character(','));

            var array = new Sequence(new Character('['),
                                     new Choice(arrayList, whitespace),
                                     new Character(']'));

            value.Add(obj);
            value.Add(array);

            pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }

}
