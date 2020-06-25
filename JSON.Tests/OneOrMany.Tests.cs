using System;
using Xunit;

namespace JSON.Tests
{
    public class OneOrManyTests
    {        
        [Fact]
        public void Test1()
        {
            var a = new OneOrMore(new Range('0', '9'));

            Assert.True(a.Match("123").Success());
            Assert.Equal("", a.Match("123").RemainingText());
        }

        [Fact]
        public void Test2()
        {
            var a = new OneOrMore(new Range('0', '9'));

            Assert.True(a.Match("1a").Success());
            Assert.Equal("a", a.Match("1a").RemainingText());
        }

        [Fact]
        public void Test3()
        {
            var a = new OneOrMore(new Range('0', '9'));

            Assert.False(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void Test4()
        {
            var a = new OneOrMore(new Range('0', '9'));

            Assert.False(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void Test5()
        {
            var a = new OneOrMore(new Range('0', '9'));

            Assert.False(a.Match(null).Success());
            Assert.Null( a.Match(null).RemainingText());
        }
    }
}