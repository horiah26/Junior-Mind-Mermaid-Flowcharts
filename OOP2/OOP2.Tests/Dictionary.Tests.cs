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
    }
} 