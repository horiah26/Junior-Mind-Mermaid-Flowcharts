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
            var wSpace = new Many(new Any(" \n\r\t"));

            var value = new Choice(new String(), 
                                   new Number(), 
                                   new Text("null"), 
                                   new Text("true"), 
                                   new Text("false"));

            var objValue = new Sequence(wSpace, 
                                        new String(), 
                                        wSpace, 
                                        new Character(':'), 
                                        wSpace,
                                        value,
                                        wSpace);

            var objList = new Sequence(wSpace, new List(objValue, new Character(',')), wSpace);           

            var obj = new Sequence(new Character('{'), 
                                   new Choice (objList, wSpace), 
                                   new Character('}'));
  
            var arrayList = new List(new Sequence(wSpace, value, wSpace), new Character(','));

            var array = new Sequence(new Character('['),
                                     new Choice(arrayList, wSpace),
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
