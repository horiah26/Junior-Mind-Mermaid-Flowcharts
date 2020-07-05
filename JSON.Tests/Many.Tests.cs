using System;
using Xunit;

namespace JSON.Tests
{
    public class ManyTests
    {
        [Fact]
        public void WorksForOneInstance()
        {
            var a = new Many(new Character('a'));

            Assert.True(a.Match("abc").Success());
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void WorksForManyInstances()
        {
            var a = new Many(new Character('a'));

            Assert.True(a.Match("aaaabc").Success());
            Assert.Equal("bc", a.Match("aaaabc").RemainingText());
        }

        [Fact]
        public void ReturnsTrueWhenNoInstancesDone()
        {
            var a = new Many(new Character('a'));

            Assert.True(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void ReturnsTrueToEmptyString()
        {
            var a = new Many(new Character('a'));

            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void ReturnsTrueToNull()
        {
            var a = new Many(new Character('a'));

            Assert.True(a.Match(null).Success());
            Assert.Null( a.Match(null).RemainingText());
        }

        [Fact]
        public void StopsWhenReachesOtherValues()
        {
            var digits = new Many(new Range('0', '9'));

            Assert.True(digits.Match("12345ab123").Success());
            Assert.Equal("ab123", digits.Match("12345ab123").RemainingText());
        }

        [Fact]
        public void ReturnTrueWhenOutOfRange()
        {
            var digits = new Many(new Range('0', '9'));

            Assert.True(digits.Match("ab").Success());
            Assert.Equal("ab", digits.Match("ab").RemainingText());
        }

        [Fact]
        public void WorksForRepeatingString()
        {
            var digits = new Many(new Text("abc"));

            Assert.True(digits.Match("abcabcabcabc").Success());
            Assert.Equal("", digits.Match("abcabcabcabc").RemainingText());
        }

    }
}