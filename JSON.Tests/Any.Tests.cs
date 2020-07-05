using System;
using Xunit;

namespace JSON.Tests
{
    public class AnyTests
    {
        [Fact]
        public void MatchesLowercaseLetter()
        {
            var e = new Any("eE");

            Assert.True(e.Match("ea").Success());
            Assert.Equal("a", e.Match("ea").RemainingText());
        }

        [Fact]
        public void MatchesUppercaseLetter()
        {
            var e = new Any("eE");

            Assert.True(e.Match("Ea").Success());
            Assert.Equal("a", e.Match("ea").RemainingText());
        }

        [Fact]
        public void ReturnsFalseWhenDoesntMatch()
        {
            var e = new Any("eE");

            Assert.False(e.Match("a").Success());
            Assert.Equal("a", e.Match("a").RemainingText());
        }

        [Fact]
        public void ReturnsFalseEmptyString()
        {
            var e = new Any("eE");

            Assert.False(e.Match("").Success());
            Assert.Equal("", e.Match("").RemainingText());
        }

        [Fact]
        public void ReturnsFalseNullString()
        {
            var e = new Any("eE");

            Assert.False(e.Match(null).Success());
            Assert.Null(e.Match(null).RemainingText());
        }

        [Fact]
        public void WorksForSigns()
        {
            var e = new Any("+-");

            Assert.True(e.Match("+3").Success());
            Assert.Equal("3", e.Match("+3").RemainingText());
        }

        [Fact]
        public void WorksForSigns2()
        {
            var e = new Any("+-");

            Assert.True(e.Match("-2").Success());
            Assert.Equal("2", e.Match("-2").RemainingText());
        }

        [Fact]
        public void ReturnsFalseWhenSignNotPresent()
        {
            var e = new Any("+-");

            Assert.False(e.Match("2").Success());
            Assert.Equal("2", e.Match("2").RemainingText());
        }
        [Fact]
        public void ReturnsFalseEmptyString2()
        {
            var e = new Any("+-");

            Assert.False(e.Match("").Success());
            Assert.Equal("", e.Match("").RemainingText());
        }

        [Fact]
        public void ReturnsFalseNullString2()
        {
            var e = new Any("+-");

            Assert.False(e.Match(null).Success());
            Assert.Null(e.Match(null).RemainingText());
        }
    }
}