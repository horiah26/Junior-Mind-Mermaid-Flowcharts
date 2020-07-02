using System;
using Xunit;

namespace JSON.Tests
{
    public class StringTests
    {
        IPattern str = new String();

        [Fact]
        public void IsWrappedInDoubleQuotes()
        {
            Assert.Equal("", str.Match("\"abc\"").RemainingText());
        }

        [Fact]
        public void AlwaysStartsWithQuotes()
        {
            Assert.Equal("abc\"", str.Match("abc\"").RemainingText());
        }

        [Fact]
        public void AlwaysEndsWithQuotes()
        {
            Assert.Equal("\"abc", str.Match("\"abc").RemainingText());
        }

        [Fact]
        public void IsNotNull()
        {
            Assert.Null(str.Match(null).RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            Assert.Empty(str.Match(string.Empty).RemainingText());
        }

        [Fact]
        public void IsAnEmptyDoubleQuotedString()
        {
            Assert.Empty(str.Match("").RemainingText());
        }

        [Fact]
        public void HasStartAndEndQuotes()
        {
            Assert.Equal("\"", str.Match("\"").RemainingText());
        }

        [Fact]
        public void DoesNotContainControlCharacters()
        {
            Assert.Equal("\"a\nb\rc\"", str.Match("\"a\nb\rc\"").RemainingText());
        }

        [Fact]
        public void CanNotContainEscapedQuotationMark()
        {
            Assert.Equal("", str.Match("\"\\\"a\\\" b\"").RemainingText());
        }

        [Fact]
        public void CanContainEscapedReverseSolidus()
        {
            Assert.Equal("", str.Match("\"a \\\\ b\"").RemainingText());
        }

        [Fact]
        public void CanContainEscapedSolidus()
        {
            Assert.Equal("", str.Match("\"a \\/ b\"").RemainingText());
        }

        [Fact]
        public void CanContainEscapedBackspace()
        {
            Assert.Equal("", str.Match("\"a \\b b\"").RemainingText());
        }

        [Fact]
        public void CanContainEscapedFormFeed()
        {
            Assert.Equal("", str.Match("\"a \\f b\"").RemainingText());
        }

        [Fact]
        public void CanContainEscapedLineFeed()
        {
            Assert.Equal("", str.Match("\"a \\n b\"").RemainingText());           
        }

        [Fact]
        public void CanContainEscapedCarrigeReturn()
        {
            Assert.Equal("", str.Match("\"a \\r b\"").RemainingText());
        }

        [Fact]
        public void CanContainEscapedHorizontalTab()
        {
            Assert.Equal("", str.Match("\"a \\t b\"").RemainingText());
        }

        [Fact]
        public void DoesNotContainUnrecognizedExcapceCharacters()
        {
            Assert.Equal("\"a\\x\"", str.Match("\"a\\x\"").RemainingText());
        }

        [Fact]
        public void DoesNotEndWithReverseSolidus()
        {
            Assert.Equal("\"a\\\"", str.Match("\"a\\\"").RemainingText());
        }

        [Fact]
        public void DoesNotEndWithAnUnfinishedHexNumber()
        {
            Assert.Equal("\"a\\u\"", str.Match("\"a\\u\"").RemainingText());
            Assert.Equal("\"a\\u123\"", str.Match("\"a\\u123\"").RemainingText());
        }


    }
}
