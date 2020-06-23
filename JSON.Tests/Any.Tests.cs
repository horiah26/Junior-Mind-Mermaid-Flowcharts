using System;
using Xunit;

namespace JSON.Tests
{
    public class AnyTests
    {
        [Fact]
        public void Test1()
        {
            var e = new Any("eE");

            Assert.True(e.Match("ea").Success());
            Assert.Equal("a", e.Match("ea").RemainingText());
        }

        [Fact]
        public void Test2()
        {
            var e = new Any("eE");

            Assert.True(e.Match("Ea").Success());
            Assert.Equal("a", e.Match("ea").RemainingText());
        }

        [Fact]
        public void Test3()
        {
            var e = new Any("eE");

            Assert.False(e.Match("a").Success());
            Assert.Equal("a", e.Match("a").RemainingText());
        }

        [Fact]
        public void Test4()
        {
            var e = new Any("eE");

            Assert.False(e.Match("").Success());
            Assert.Equal("", e.Match("").RemainingText());
        }

        [Fact]
        public void Test5()
        {
            var e = new Any("eE");

            Assert.False(e.Match(null).Success());
            Assert.Null(e.Match(null).RemainingText());
        }

        [Fact]
        public void Test6()
        {
            var e = new Any("+-");

            Assert.True(e.Match("+3").Success());
            Assert.Equal("3", e.Match("+3").RemainingText());
        }

        [Fact]
        public void Test7()
        {
            var e = new Any("+-");

            Assert.True(e.Match("-2").Success());
            Assert.Equal("2", e.Match("-2").RemainingText());
        }

        [Fact]
        public void Test8()
        {
            var e = new Any("+-");

            Assert.False(e.Match("2").Success());
            Assert.Equal("2", e.Match("2").RemainingText());
        }
        [Fact]
        public void Test9()
        {
            var e = new Any("+-");

            Assert.False(e.Match("").Success());
            Assert.Equal("", e.Match("").RemainingText());
        }

        [Fact]
        public void Test10()
        {
            var e = new Any("eE");

            Assert.False(e.Match(null).Success());
            Assert.Null(e.Match(null).RemainingText());
        }
    }
}