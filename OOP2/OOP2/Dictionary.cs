using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OOP2
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private int[] buckets;
        private Element<TKey, TValue>[] elements;

        public Dictionary(int bucketSize)
        {
            buckets = new int[bucketSize];
            elements = new Element<TKey, TValue>[bucketSize];

            Array.Fill(buckets, -1);
        }

        public TValue this[TKey key] 
        { 
            get
            {
                var element = FindByKey(key);
                return element.Value;
            }            
            set 
            {
                var element = FindByKey(key);
                element.Value = value;
            }
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

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Add(Element<TKey, TValue> element)
        {
            Add(element.Key, element.Value);
        }

        public void Add(TKey key, TValue value)
        {
            CheckIfNull(key);
            CheckIfDuplicate(key);
            EnsureCapacity();

            int freeIndex = FindFreeIndex();
            int bucketNumber = GetBucket(key);

            elements[freeIndex] = new Element<TKey, TValue>(key, value, buckets[bucketNumber]);
            buckets[bucketNumber] = freeIndex;

            Count++;
        }

        private int GetBucket(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % buckets.Length;
        }

        private int FindFreeIndex()
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
            Count = 0;
            Array.Fill(buckets, -1);
            Array.Fill(elements, null);
        }

        public bool Contains(Element<TKey, TValue> element)
        {
            CheckIfNull(element.Key);
            return (FindByKey(element.Key) != null && FindByKey(element.Key).Value.Equals(element.Value));
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            CheckIfNull(item.Key);
            return Contains(new Element<TKey, TValue>(item.Key, item.Value));
        }

        private Element<TKey, TValue> FindByKey(TKey key)
        {
            CheckIfNull(key);

            int bucketNumber = GetBucket(key);
            int currentIndex = buckets[bucketNumber];

            while (currentIndex != -1)
            {
                if (elements[currentIndex].Key.Equals(key))
                {
                    return elements[currentIndex];
                }

                currentIndex = elements[currentIndex].Next;
            }

            Element<TKey, TValue> nullElement = null;
            return nullElement;
        }

        public bool ContainsKey(TKey key)
        {
            CheckIfNull(key);
            return FindByKey(key) != null;
        }

        public bool ContainsValue(TValue value)
        {
            return Values.Contains(value);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (FindByKey(item.Key).Value.Equals(item.Value))
            {
                return Remove(item.Key);
            }

            return false;
        }

        public bool Remove(TKey key)
        {
            CheckIfNull(key);

            int bucketNumber = GetBucket(key);
            int valueInBucket = buckets[bucketNumber];

            Element<TKey, TValue> currentElement = elements[valueInBucket];
            Element<TKey, TValue> previousElement = null;                          

            while (!currentElement.Key.Equals(key) && currentElement.Next != -1)
            {
                previousElement = currentElement;
                currentElement = elements[currentElement.Next];
            }

            if (currentElement.Key.Equals(key))
            {
                if (previousElement == null)
                {
                    elements[buckets[valueInBucket]] = null;
                    buckets[bucketNumber] = -1;
                }
                else
                {
                    int tempNext = currentElement.Next;

                    elements[previousElement.Next] = null;
                    previousElement.Next = tempNext;
                }

                Count--;
                return true;
            }
          
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null");
            }
            else if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Index must be greater than 0");
            }
            else if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentOutOfRangeException("The number of elements in the source T[] array is greater than the available space from arrayIndex to the end of the destination array.");
            }

            int arrayPosition = 0;

            for (int i = 0; i < elements.Length; i++)
            {
                if(elements[i] != null)
                {
                    array[arrayPosition + arrayIndex] = new KeyValuePair<TKey, TValue>(elements[i].Key, elements[i].Value);
                    arrayPosition++;
                }
            }
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            CheckIfNull(key);

            if (FindByKey(key) != null)
            {
                value = FindByKey(key).Value;
                return true;
            }

            value = default;
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != null)
                {
                    yield return new KeyValuePair<TKey, TValue>(elements[i].Key, elements[i].Value);
                }
            }
        }

        public void EnsureCapacity()
        {
            if (elements.Length == Count)
            {
                Array.Resize(ref elements, Count * 2);
            }
        }

        private void CheckIfNull(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key is null");
            };
        }

        private void CheckIfDuplicate(TKey key)
        {
            if (FindByKey(key) != null)
            {
                throw new ArgumentException("An element with this key already exists in the dictionary");
            }
        }
    }
}