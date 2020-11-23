using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

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
            string text = "-875";
            Assert.Equal(-875, StringOperations.StringToInt(text));
        }

        [Fact]
        public void MostCommonCharWorks()
        {
            string text = "abcabeb";
            Assert.Equal('b', StringOperations.MostCommonChar(text));
        }

        [Fact]
        public void CountVowelConsonants1()
        {
            string text = "abcabeb";

            Assert.Equal((3,4), StringOperations.CountVowelsConsonants(text));
        }

        [Fact]
        public void CountVowelConsonants2()
        {
            string text = "Ana are mere!";

            Assert.Equal((6, 4), StringOperations.CountVowelsConsonants(text));
        }

        [Fact]
        public void SubstringPalindromesWorks()
        {
            IEnumerable<string> expected = new[] { "aabaa", "aba", "aa", "aa", "a", "a", "b", "a", "a", "c" };

            var result = StringOperations.SubstringPalindromes("aabaac");

            Assert.True(result.SequenceEqual(expected));
        }
    }
}