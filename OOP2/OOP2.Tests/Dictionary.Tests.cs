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
        public void CanAddOneElement()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(0, "a");

            dictionary.ContainsKey(0);
            dictionary.Contains(new Element<int, string>(0, "a"));
            Assert.True(dictionary.Count == 1);
        }

        [Fact]
        public void WorksWithStringAsKey()
        {
            var dictionary = new Dictionary<string, string>(5);
            dictionary.Add("key", "a");

            dictionary.ContainsKey("key");
            dictionary.Contains(new Element<string, string>("key", "a"));
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
        public void DictionaryDoublesSize()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(0, "a");
            dictionary.Add(14, "b");
            Assert.True(dictionary.Count == 2);
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

            dictionary.Add(new Element<int, string>(0, "a"));
            dictionary.Add(new Element<int, string>(1, "b"));
            dictionary.Add(new Element<int, string>(2, "c"));

            Assert.True(dictionary.Contains(new Element<int, string>(0, "a")));
            Assert.True(dictionary.Contains(new Element<int, string>(1, "b")));
            Assert.True(dictionary.Contains(new Element<int, string>(2, "c")));

            Assert.False(dictionary.Contains(new Element<int, string>(4, "a")));
        }

        [Fact]
        public void CanRemoveFirst()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(new Element<int, string>(0, "a"));
            dictionary.Add(new Element<int, string>(1, "b"));
            dictionary.Add(new Element<int, string>(2, "c"));

            dictionary.Remove(0);

            Assert.False(dictionary.Contains(new Element<int, string>(0, "a")));
            Assert.True(dictionary.Contains(new Element<int, string>(1, "b")));
            Assert.True(dictionary.Contains(new Element<int, string>(2, "c")));

            Assert.False(dictionary.Contains(new Element<int, string>(4, "a")));
        }

        [Fact]
        public void CanRemoveInTheMiddle()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(new Element<int, string>(0, "a"));
            dictionary.Add(new Element<int, string>(10, "b"));
            dictionary.Add(new Element<int, string>(20, "c"));

            dictionary.Remove(10);

            Assert.True(dictionary.Contains(new Element<int, string>(0, "a")));
            Assert.False(dictionary.Contains(new Element<int, string>(10, "b")));
            Assert.True(dictionary.Contains(new Element<int, string>(20, "c")));

            Assert.False(dictionary.Contains(new Element<int, string>(40, "a")));
        }

        [Fact]
        public void CanRemoveLast()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(new Element<int, string>(0, "a"));
            dictionary.Add(new Element<int, string>(1, "b"));
            dictionary.Add(new Element<int, string>(2, "c"));

            dictionary.Remove(2);

            Assert.True(dictionary.Contains(new Element<int, string>(0, "a")));
            Assert.True(dictionary.Contains(new Element<int, string>(1, "b")));
            Assert.False(dictionary.Contains(new Element<int, string>(2, "c")));

            Assert.False(dictionary.Contains(new Element<int, string>(4, "a")));
        }

        [Fact]
        public void RemoveElementThatDoesNotExistReturnsFalse()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(new Element<int, string>(0, "a"));
            dictionary.Add(new Element<int, string>(1, "b"));
            dictionary.Add(new Element<int, string>(2, "c"));

            Assert.False(dictionary.Remove(11));

            Assert.True(dictionary.Contains(new Element<int, string>(0, "a")));
            Assert.True(dictionary.Contains(new Element<int, string>(1, "b")));
            Assert.True(dictionary.Contains(new Element<int, string>(2, "c")));

            Assert.False(dictionary.Contains(new Element<int, string>(4, "a")));
        }

        [Fact]
        public void AddWorksAfterRemove()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);

            dictionary.Add(new Element<int, string>(0, "a"));
            dictionary.Add(new Element<int, string>(1, "b"));
            dictionary.Add(new Element<int, string>(2, "c"));

            dictionary.Remove(1);

            dictionary.Add(new Element<int, string>(3, "f"));

            Assert.True(dictionary.Contains(new Element<int, string>(0, "a")));        
            Assert.True(dictionary.Contains(new Element<int, string>(2, "c")));
            Assert.True(dictionary.Contains(new Element<int, string>(3, "f")));

            Assert.False(dictionary.Contains(new Element<int, string>(1, "b")));
            Assert.False(dictionary.Contains(new Element<int, string>(4, "a")));

            Assert.Equal(3, dictionary.Count);
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

            Assert.Equal(array[0], new KeyValuePair<int, string>(3, "a"));
            Assert.Equal(array[1], new KeyValuePair<int, string>(4, "b"));
            Assert.Equal(array[2], new KeyValuePair<int, string>(5, "c"));
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

            Assert.Equal(array[2], new KeyValuePair<int, string>(3, "a"));
            Assert.Equal(array[3], new KeyValuePair<int, string>(4, "b"));
            Assert.Equal(array[4], new KeyValuePair<int, string>(5, "c"));
        }
    }
} 