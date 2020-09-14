using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OOP2
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public int freeIndex;
        public int bucketSize;
        public int[] buckets;
        public Element<TKey, TValue>[] elements;
        public TValue this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        public Dictionary(int bucketSize)
        {
            buckets = new int[bucketSize];
            elements = new Element<TKey, TValue>[bucketSize];
            this.bucketSize = bucketSize;
            freeIndex = 0;
            Array.Fill(buckets, -1);
        }

        public ICollection<TKey> Keys
        {
            get
            {
                List<TKey> KeyList = new List<TKey>();

                foreach (KeyValuePair<TKey, TValue> element in this)
                {
                    KeyList.Add(element.Key);
                }

                return KeyList;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                List<TValue> ValueList = new List<TValue>();

                foreach (KeyValuePair<TKey, TValue> element in this)
                {
                    ValueList.Add(element.Value);
                }

                return ValueList;
            }
        }
        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            freeIndex = FindFreeIndex();
            int bucketIndex = GetBucket(key);

            if(buckets[bucketIndex] == -1)
            {
                elements[freeIndex] = new Element<TKey, TValue>(key, value);
            }
            else
            {
                elements[freeIndex] = new Element<TKey, TValue>(key, value, buckets[bucketIndex]);
            }

            buckets[bucketIndex] = freeIndex;
            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        private int GetBucket(TKey key)
        {
            return key.GetHashCode() % 5;
        }

        public int FindFreeIndex()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] == null)
                {
                    return i;
                }
            }

            return -1;
        }


        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] == null)
                {
                    continue;
                }

                yield return new KeyValuePair<TKey, TValue>(elements[i].Key, elements[i].Value);
            }

        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }    
}