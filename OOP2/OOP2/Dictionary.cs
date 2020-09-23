using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OOP2
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private int[] buckets;
        private int freeIndex;
        private Element<TKey, TValue>[] elements;

        public Dictionary(int bucketSize = 5)
        {
            buckets = new int[bucketSize];
            elements = new Element<TKey, TValue>[bucketSize];
            InitializeArray();
        }

        private void InitializeArray()
        {
            freeIndex = 0;
            Array.Fill(buckets, -1);

            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = new Element<TKey, TValue>(default, default);
                elements[i].Next = i + 1;
            }

            elements[elements.Length - 1].Next = -1;
        }

        public TValue this[TKey key]
        {
            get
            {
                if(FindIndex(key, out var unusedIndex) == -1)
                {
                    throw new ArgumentException("Key not found in Dictionary");
                }

                var index = FindIndex(key, out unusedIndex);
                return elements[index].Value;
            }
            set
            {
                if (FindIndex(key, out var unusedIndex) == -1)
                {
                    Add(new KeyValuePair<TKey, TValue>(key, value));
                }

                var index = FindIndex(key, out  unusedIndex);
                elements[index].Value = value;
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                List<TKey> keyList = new List<TKey>();

                foreach (KeyValuePair<TKey, TValue> element in this)
                {
                    keyList.Add(element.Key);
                }

                return keyList;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                List<TValue> ValueList = new List<TValue>();

                foreach (var element in this)
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

        public void Add(TKey key, TValue value)
        {
            CheckIfFull();
            CheckIfNull(key);
            CheckIfDuplicate(key);

            int bucketNumber = GetBucket(key);
            int tempIndex = elements[freeIndex].Next;

            elements[freeIndex] = new Element<TKey, TValue>(key, value); 
            elements[freeIndex].Next = buckets[bucketNumber];

            buckets[bucketNumber] = freeIndex;

            freeIndex = tempIndex;
            Count++;
        }

        private void CheckIfFull()
        {
            if(Count == elements.Length)
            {
                throw new ArgumentOutOfRangeException("Dictionary is full");
            }
        }

        private int GetBucket(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % buckets.Length;
        }

        public void Clear()
        {
            Count = 0;
            InitializeArray();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            CheckIfNull(item.Key);
            int index = FindIndex(item.Key, out int unusedIndex);

            if(index != -1)
            {
                return elements[index].Value.Equals(item.Value);
            }

            return false;
        }

        private int FindIndex(TKey key, out int previousIndex)
        {
            CheckIfNull(key);
            previousIndex = -1;

            for (int currentIndex = buckets[GetBucket(key)]; currentIndex != -1; currentIndex = elements[currentIndex].Next)
            {
                if (elements[currentIndex].Key.Equals(key))
                {
                    return currentIndex;
                }

                previousIndex = currentIndex;
            }

            return -1;
        }

        public bool Remove(TKey key)
        {
            CheckIfNull(key);

            int index = FindIndex(key, out var previousIndex);

            if (index == -1)
            {
                return false;
            }

            if (previousIndex == -1)
            {
                buckets[GetBucket(key)] = elements[index].Next;
            }
            else
            {
                elements[previousIndex].Next = elements[index].Next;
            }

            elements[index].Next = freeIndex;
            freeIndex = index;
            Count--;
            return true;
        }

        public bool ContainsKey(TKey key)
        {
            CheckIfNull(key);
            return FindIndex(key, out var unusedIndex) != -1;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            int index = FindIndex(item.Key, out var unusedIndex);

            if (elements[index].Value.Equals(item.Value))
            {
                return Remove(item.Key);
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

            int positionIndex = -1;

            foreach(var element in this)
            {
                positionIndex++;
                array[positionIndex + arrayIndex] = new KeyValuePair<TKey, TValue>(element.Key, element.Value);
            }
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            CheckIfNull(key);

            int index = FindIndex(key, out var unusedIndex);

            if (index != -1)
            {
                value = elements[index].Value;
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
            foreach(var valueInBucket in buckets)
            {
                if(valueInBucket != -1)
                {                    
                    var index = valueInBucket;

                    while (index != -1)
                    {
                        yield return new KeyValuePair<TKey, TValue>(elements[index].Key, elements[index].Value);
                        index = elements[index].Next;
                    }                    
                }
            }
        }

        private void CheckIfNull(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key is null");
            }
        }

        private void CheckIfDuplicate(TKey key)
        {
            if (FindIndex(key, out var unusedIndex) != -1)
            {
                throw new ArgumentException("An element with this key already exists in the dictionary");
            }
        }
    }
}