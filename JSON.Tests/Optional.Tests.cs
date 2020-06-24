using System;
using Xunit;

namespace JSON.Tests
{
    public class OptionalTests
    {
        [Fact]
        public void Test1()
        {
            var a = new Optional(new Character('a'));

            Assert.True(a.Match("abc").Success());
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void Test2()
        {
            var a = new Optional(new Character('a'));

            Assert.True(a.Match("aabc").Success());
            Assert.Equal("abc", a.Match("aabc").RemainingText());
        }

        [Fact]
        public void Test3()
        {
            var a = new Optional(new Character('a'));

            Assert.True(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void Test4()
        {
            var a = new Optional(new Character('a'));

            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void Test5()
        {
            var a = new Optional(new Character('a'));

            Assert.True(a.Match(null).Success());
            Assert.Null( a.Match(null).RemainingText());
        }

        [Fact]
        public void Test6()
        {
            var sign = new Optional(new Character('-'));

            Assert.True(sign.Match("123").Success());
            Assert.Equal("123", sign.Match("123").RemainingText());
        }

        [Fact]
        public void Test7()
        {
            var sign = new Optional(new Character('-'));

            Assert.True(sign.Match("-123").Success());
            Assert.Equal("123", sign.Match("-123").RemainingText());
        }
    }
}