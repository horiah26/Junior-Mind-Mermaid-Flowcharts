using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var whitespace = new Any(" \n\r\t") ;

            var value = new Choice(new String(), 
                                   new Number(), 
                                   new Text("null"), 
                                   new Text("true"), 
                                   new Text("false"));

            var objValue = new Sequence(whitespace, 
                                        new String(), 
                                        whitespace, 
                                        new Character(':'), 
                                        value);

            var objList = new List(objValue, new Character(','));

            var obj = new Sequence(new Character('{'), 
                                   new Choice (objList, whitespace), 
                                   new Character('}'));

            var arrayList = new List(value, new Character(','));

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
