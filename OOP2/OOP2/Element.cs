using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{
    public class Element<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
        public int Next = -1;

        public Element(TKey Key, TValue Value)
        {
            this.Key = Key;
            this.Value = Value;
        }

        public Element(TKey Key, TValue Value, int Next)
        {
            this.Key = Key;
            this.Value = Value;
            this.Next = Next;
        }
    }
}
