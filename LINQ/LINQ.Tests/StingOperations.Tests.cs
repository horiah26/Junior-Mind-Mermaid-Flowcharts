using System;
using Xunit;
using System.Linq;

namespace LINQ.Tests
{
    public class StringOperationsTests
    {
        [Fact]
        public void FirstUniqueCharWorks()
        {
            string text = "abcabe";
            Assert.Equal('c', StringOperations.FirstUniqueChar(text));
        }

        [Fact]
        public void StringToIntWorks()
        {
            string text = "abcabe";
            Assert.Equal(590, StringOperations.StringToInt(text));
        }
    }
}