using System;
using Xunit;

namespace JSON.Tests
{
    public class ManyTests
    {
        [Fact]
        public void Test1()
        {
            var a = new Many(new Character('a'));

            Assert.True(a.Match("abc").Success());
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void Test2()
        {
            var a = new Many(new Character('a'));

            Assert.True(a.Match("aaaabc").Success());
            Assert.Equal("bc", a.Match("aaaabc").RemainingText());
        }

        [Fact]
        public void Test3()
        {
            var a = new Many(new Character('a'));

            Assert.True(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void Test4()
        {
            var a = new Many(new Character('a'));

            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void Test5()
        {
            var a = new Many(new Character('a'));

            Assert.True(a.Match(null).Success());
            Assert.Null( a.Match(null).RemainingText());
        }

        [Fact]
        public void Test6()
        {
            var digits = new Many(new Range('0', '9'));

            Assert.True(digits.Match("12345ab123").Success());
            Assert.Equal("ab123", digits.Match("12345ab123").RemainingText());
        }

        [Fact]
        public void Test7()
        {
            var digits = new Many(new Range('0', '9'));

            Assert.True(digits.Match("ab").Success());
            Assert.Equal("ab", digits.Match("ab").RemainingText());
        }

    }
}