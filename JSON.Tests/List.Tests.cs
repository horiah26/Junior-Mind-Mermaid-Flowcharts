using System;
using Xunit;

namespace JSON.Tests
{
    public class ListTests
    {
        [Fact]
        public void WorksForSimpleNumberList()
        {
            var a = new List(new Range('0', '9'), new Character(','));
  
            Assert.True(a.Match("1,2,3").Success());
            Assert.Equal("", a.Match("1,2,3").RemainingText());
        }

        [Fact]
        public void WorksForOneExtraSeparator()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            Assert.True(a.Match("1,2,3,").Success());
            Assert.Equal(",", a.Match("1,2,3,").RemainingText());
        }

        [Fact]
        public void WorksForOneElementWithoutSeparator()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            Assert.True(a.Match("1a").Success());
            Assert.Equal("a", a.Match("1a").RemainingText());
        }

        [Fact]
        public void ReturnsTrueIfNoElementOrSeparator()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            Assert.True(a.Match("abc").Success());
            Assert.Equal("abc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void ReturnsTrueToEmptyString()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void ReturnsTrueToNull()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            Assert.True(a.Match(null).Success());
            Assert.Null(a.Match(null).RemainingText());
        }

        [Fact]
        public void WorksForDifferentEscapeSeparators()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match("1; 22  ;\n 333 \t; 22").Success());
            Assert.Equal("", list.Match("1; 22  ;\n 333 \t; 22").RemainingText());
        }

        [Fact]
        public void WorksForOneElementAndAnEscapeSeparator()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match("1 \n;").Success());
            Assert.Equal(" \n;", list.Match("1 \n;").RemainingText());
        }

        [Fact]
        public void ReturnsTrueWhenCharacterAndSeparatorNotPresent()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match("abc").Success());
            Assert.Equal("abc", list.Match("abc").RemainingText());
        }
    }
}