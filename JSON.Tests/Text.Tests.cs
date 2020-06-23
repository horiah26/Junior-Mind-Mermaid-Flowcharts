using System;
using Xunit;

namespace JSON.Tests
{
    public class TextTests
    {
        [Fact]
        public void Test1()
        {
            var True = new Text("true");

            Assert.True(True.Match("true").Success());
            Assert.Equal("", True.Match("true").RemainingText());
        }

        [Fact]
        public void Test2()
        {
            var True = new Text("true");

            Assert.True(True.Match("trueX").Success());
            Assert.Equal("X", True.Match("trueX").RemainingText());
        }

        [Fact]
        public void Test3()
        {
            var True = new Text("true");

            Assert.False(True.Match("false").Success());
            Assert.Equal("false", True.Match("false").RemainingText());
        }

        [Fact]
        public void Test4()
        {
            var True = new Text("");

            Assert.False(True.Match("").Success());
            Assert.Equal("", True.Match("").RemainingText());
        }

        [Fact]
        public void Test5()
        {
            var True = new Text(null);

            Assert.False(True.Match(null).Success());
            Assert.Null(True.Match(null).RemainingText());
        }

        [Fact]
        public void Test6()
        {
            var False = new Text("false");

            Assert.True(False.Match("false").Success());
            Assert.Equal("", False.Match("false").RemainingText());
        }

        [Fact]
        public void Test7()
        {
            var False = new Text("false");

            Assert.True(False.Match("falseX").Success());
            Assert.Equal("X", False.Match("falseX").RemainingText());
        }

        [Fact]
        public void Test8()
        {
            var False = new Text("false");

            Assert.False(False.Match("true").Success());
            Assert.Equal("true", False.Match("true").RemainingText());
        }

        [Fact]
        public void Test9()
        {
            var False = new Text("");

            Assert.False(False.Match("").Success());
            Assert.Equal("", False.Match("").RemainingText());
        }

        [Fact]
        public void Test10()
        {
            var False = new Text(null);

            Assert.False(False.Match(null).Success());
            Assert.Null(False.Match(null).RemainingText());
        }
    }
}