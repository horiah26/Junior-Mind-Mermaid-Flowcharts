using System;
using System.Collections.Generic;
using Xunit;

namespace OOP2.Tests
{
    public class DictionaryTests
    {
        [Fact]
        public void CanCreateDictionary()
        {
            var dictionary = new Dictionary<int, string>(5);
            Assert.True(dictionary.Count == 0);
        }

        [Fact]
        public void CanCreateDictionaryOfCustomBucketSize()
        {
            var dictionary = new Dictionary<int, string>(7);
            Assert.True(dictionary.Count == 0);
        }

        [Fact]
        public void CanAddOneElement()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(0, "a");

            dictionary.ContainsKey(0);
            dictionary.Contains(new KeyValuePair<int, string>(0, "a"));
            Assert.True(dictionary.Count == 1);
        }

        [Fact]
        public void WorksWithStringAsKey()
        {
            var dictionary = new Dictionary<string, string>(5);
            dictionary.Add("key", "a");

            dictionary.ContainsKey("key");
            dictionary.Contains(new KeyValuePair<string, string>("key", "a"));
            Assert.True(dictionary.Count == 1);
        }

        [Fact]
        public void CanAddTwoElements()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(0, "a");
            dictionary.Add(14, "b");
            Assert.True(dictionary.Count == 2);
        }

        [Fact]
        public void Clears()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(3, "c");
            dictionary.Clear();

            Assert.Empty(dictionary);
        }

        [Fact]
        public void CanGetValueWithIndexer()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(3, "c");

            Assert.Equal("a", dictionary[1]);
        }

        [Fact]
        public void CanAddWithIndexer()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(3, "c");
            dictionary[4] = "d";

            Assert.True(dictionary.ContainsKey(4));
            Assert.Contains(new KeyValuePair<int, string>(4, "d"), dictionary);
        }

        [Fact]
        public void CanAddAfterClear()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(new KeyValuePair<int, string>(0, "a"));
            dictionary.Add(new KeyValuePair<int, string>(1, "b"));
            dictionary.Add(new KeyValuePair<int, string>(2, "c"));
            dictionary.Add(new KeyValuePair<int, string>(3, "d"));
             
            dictionary.Clear();

            dictionary.Add(1, "b");

            Assert.Contains(new KeyValuePair<int, string>(1, "b"), dictionary);
            Assert.DoesNotContain(new KeyValuePair<int, string>(0, "a"), dictionary);
            Assert.DoesNotContain(new KeyValuePair<int, string>(2, "c"), dictionary);

            dictionary.Add(2, "c");

            Assert.Contains(new KeyValuePair<int, string>(1, "b"), dictionary);
            Assert.DoesNotContain(new KeyValuePair<int, string>(0, "a"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(2, "c"), dictionary);

            dictionary.Remove(1);

            Assert.DoesNotContain(new KeyValuePair<int, string>(1, "b"), dictionary);
            Assert.DoesNotContain(new KeyValuePair<int, string>(0, "a"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(2, "c"), dictionary);
        }

        [Fact]
        public void ContainsKeyWorks()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(3, "c");

            Assert.True(dictionary.ContainsKey(1));
            Assert.True(dictionary.ContainsKey(2));
            Assert.True(dictionary.ContainsKey(3));

            Assert.False(dictionary.ContainsKey(4));
        }

        [Fact]
        public void ContainsWorks()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(new KeyValuePair<int, string>(0, "a"));
            dictionary.Add(new KeyValuePair<int, string>(1, "b"));
            dictionary.Add(new KeyValuePair<int, string>(2, "c"));

            Assert.Contains(new KeyValuePair<int, string>(0, "a"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(1, "b"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(2, "c"), dictionary);

            Assert.DoesNotContain(new KeyValuePair<int, string>(4, "a"), dictionary);
        }

        [Fact]
        public void CanRemoveFirstItem()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(new KeyValuePair<int, string>(0, "a"));
            dictionary.Add(new KeyValuePair<int, string>(1, "b"));
            dictionary.Add(new KeyValuePair<int, string>(2, "c"));

            dictionary.Remove(0);

            Assert.DoesNotContain(new KeyValuePair<int, string>(0, "a"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(1, "b"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(2, "c"), dictionary);

            Assert.DoesNotContain(new KeyValuePair<int, string>(4, "a"), dictionary);
        }

        [Fact]
        public void CanRemoveItemInTheMiddle()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(new KeyValuePair<int, string>(0, "a"));
            dictionary.Add(new KeyValuePair<int, string>(10, "b"));
            dictionary.Add(new KeyValuePair<int, string>(20, "c"));

            dictionary.Remove(10);

            Assert.Contains(new KeyValuePair<int, string>(0, "a"), dictionary);
            Assert.DoesNotContain(new KeyValuePair<int, string>(10, "b"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(20, "c"), dictionary);

            Assert.DoesNotContain(new KeyValuePair<int, string>(40, "a"), dictionary);
        }

        [Fact]
        public void CanRemoveLastItem()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(new KeyValuePair<int, string>(0, "a"));
            dictionary.Add(new KeyValuePair<int, string>(1, "b"));
            dictionary.Add(new KeyValuePair<int, string>(2, "c"));

            dictionary.Remove(2);

            Assert.Contains(new KeyValuePair<int, string>(0, "a"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(1, "b"), dictionary);
            Assert.DoesNotContain(new KeyValuePair<int, string>(2, "c"), dictionary);

            Assert.DoesNotContain(new KeyValuePair<int, string>(4, "a"), dictionary);
        }

        [Fact]
        public void CanRemoveAllButLast()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(new KeyValuePair<int, string>(0, "a"));
            dictionary.Add(new KeyValuePair<int, string>(1, "b"));
            dictionary.Add(new KeyValuePair<int, string>(2, "c"));
            dictionary.Add(new KeyValuePair<int, string>(3, "d"));

            dictionary.Remove(2);
            dictionary.Remove(0);
            dictionary.Remove(1);

            Assert.DoesNotContain(new KeyValuePair<int, string>(0, "a"), dictionary);
            Assert.DoesNotContain(new KeyValuePair<int, string>(1, "b"), dictionary);
            Assert.DoesNotContain(new KeyValuePair<int, string>(2, "c"), dictionary);

            Assert.Contains(new KeyValuePair<int, string>(3, "d"), dictionary);
        }

        [Fact]
        public void RemoveElementThatDoesNotExistReturnsFalse()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(new KeyValuePair<int, string>(0, "a"));
            dictionary.Add(new KeyValuePair<int, string>(1, "b"));
            dictionary.Add(new KeyValuePair<int, string>(2, "c"));

            Assert.False(dictionary.Remove(11));

            Assert.Contains(new KeyValuePair<int, string>(0, "a"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(1, "b"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(2, "c"), dictionary);

            Assert.DoesNotContain(new KeyValuePair<int, string>(4, "a"), dictionary);
        }

        [Fact]
        public void AddingWorksAfterRemove()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(new KeyValuePair<int, string>(0, "a"));
            dictionary.Add(new KeyValuePair<int, string>(1, "b"));
            dictionary.Add(new KeyValuePair<int, string>(2, "c"));

            dictionary.Remove(1);

            dictionary.Add(new KeyValuePair<int, string>(3, "f"));

            Assert.Contains(new KeyValuePair<int, string>(0, "a"), dictionary);        
            Assert.Contains(new KeyValuePair<int, string>(2, "c"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(3, "f"), dictionary);

            Assert.DoesNotContain(new KeyValuePair<int, string>(1, "b"), dictionary);
            Assert.DoesNotContain(new KeyValuePair<int, string>(4, "a"), dictionary);

            Assert.Equal(3, dictionary.Count);
        }

        [Fact]
        public void CanAddAndRemoveSuccesively()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(new KeyValuePair<int, string>(1, "a"));
            dictionary.Add(new KeyValuePair<int, string>(2, "b"));
            dictionary.Add(new KeyValuePair<int, string>(3, "c"));
            dictionary.Add(new KeyValuePair<int, string>(4, "d"));
            dictionary.Add(new KeyValuePair<int, string>(5, "e"));

            dictionary.Remove(4);

            Assert.Contains(new KeyValuePair<int, string>(1, "a"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(2, "b"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(3, "c"), dictionary);
            Assert.DoesNotContain(new KeyValuePair<int, string>(4, "d"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(5, "e"), dictionary);

            dictionary.Remove(2);

            Assert.Contains(new KeyValuePair<int, string>(1, "a"), dictionary);
            Assert.DoesNotContain(new KeyValuePair<int, string>(2, "b"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(3, "c"), dictionary);
            Assert.DoesNotContain(new KeyValuePair<int, string>(4, "d"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(5, "e"), dictionary);

            dictionary.Add(6, "f");

            Assert.Contains(new KeyValuePair<int, string>(1, "a"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(6, "f"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(3, "c"), dictionary);
            Assert.DoesNotContain(new KeyValuePair<int, string>(4, "d"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(5, "e"), dictionary);

            dictionary.Add(7, "g");

            Assert.Contains(new KeyValuePair<int, string>(1, "a"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(6, "f"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(3, "c"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(7, "g"), dictionary);
            Assert.Contains(new KeyValuePair<int, string>(5, "e"), dictionary);
        }

        [Fact]
        public void ReturnsKeys()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(3, "a");
            dictionary.Add(4, "b");
            dictionary.Add(5, "c");

            var keys = dictionary.Keys;

            Assert.True(keys.Contains(3));
            Assert.True(keys.Contains(4));
            Assert.True(keys.Contains(5));
        }

        [Fact]
        public void ReturnsValues()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(3, "a");
            dictionary.Add(4, "b");
            dictionary.Add(5, "c");

            var values = dictionary.Values;
            Assert.Equal(3, values.Count);
            Assert.True(values.Contains("a"));
            Assert.True(values.Contains("b"));
            Assert.True(values.Contains("c"));
        }

        [Fact]
        public void CanCopyToArray()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(3, "a");
            dictionary.Add(4, "b");
            dictionary.Add(5, "c");

            var array = new KeyValuePair<int, string>[3];

            dictionary.CopyTo(array, 0);

            Assert.Equal(array[0], new KeyValuePair<int, string>(5, "c"));
            Assert.Equal(array[1], new KeyValuePair<int, string>(3, "a"));
            Assert.Equal(array[2], new KeyValuePair<int, string>(4, "b"));
        }

        [Fact]
        public void CanCopyToArrayAtIndex()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(3, "a");
            dictionary.Add(4, "b");
            dictionary.Add(5, "c");

            var array = new KeyValuePair<int, string>[5];

            dictionary.CopyTo(array, 2);

            Assert.Equal(array[3], new KeyValuePair<int, string>(3, "a"));
            Assert.Equal(array[4], new KeyValuePair<int, string>(4, "b"));
            Assert.Equal(array[2], new KeyValuePair<int, string>(5, "c"));
        }

        [Fact]
        public void TryGetValueWhenKeyIsCorrect()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(0, "a");
            dictionary.Add(1, "b");
            dictionary.Add(2, "c");

            string value;

            Assert.True(dictionary.TryGetValue(1, out value));
            Assert.Equal("b", value);
        }

        [Fact]
        public void TryGetValueWhenKeyIsNotCorrect()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(0, "a");
            dictionary.Add(1, "b");
            dictionary.Add(2, "c");

            string value;

            Assert.False(dictionary.TryGetValue(3, out value));
            Assert.Equal(default, value);
        }

        [Fact]
        public void TryGetValueExceptionWhenKeyIsNull()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>(5);

            dictionary.Add("a", "a");
            dictionary.Add("b", "b");
            dictionary.Add("c", "c");

            string value;

            Assert.Throws<ArgumentNullException>(() => dictionary.TryGetValue(null, out value));
        }

        [Fact]
        public void ThrowsExceptionKeyDuplicate()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>(5);

            dictionary.Add("a", "alfa");

            Assert.Throws<ArgumentException>(() => dictionary.Add(new KeyValuePair<string, string>("a", "alfa")));
        }

        [Fact]
        public void ThrowsExceptionFullDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>(5);

            dictionary.Add("a", "a");
            dictionary.Add("b", "b");
            dictionary.Add("c", "c");
            dictionary.Add("d", "d"); 
            dictionary.Add("e", "e");

            Assert.Throws<ArgumentOutOfRangeException>(() => dictionary.Add(new KeyValuePair<string, string>("g", "g")));
        }
    }
} 