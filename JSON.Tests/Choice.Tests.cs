using System;
using System.ComponentModel;
using Xunit;

namespace JSON.Tests
{
    public class ChoiceTests
    {
        [Fact]
        public void ReturnsTrueCharacterRange()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9')
        );

            Assert.True(digit.Match("012").Success());
        }

        [Fact]
        public void ReturnsTrueCharacterRange2()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9')
        );

            Assert.True(digit.Match("12").Success());
        }

        [Fact]
        public void ReturnsTrueCharacterRange3()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9')
        );

            Assert.True(digit.Match("92").Success());
        }

        [Fact]
        public void ReturnsFalseToBadCharacter()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9')
        );

            Assert.False(digit.Match("a9").Success());
        }

        [Fact]
        public void ReturnsFalseEmptyString()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9')
        );

            Assert.False(digit.Match("").Success());
        }

        [Fact]
        public void ReturnsFalseNullString()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9')
        );

            Assert.False(digit.Match(null).Success());
        }

        [Fact]
        public void ReturnsTrueInDoubleChoiceCharacter()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9'));

            var hex = new Choice(
            digit,
            new Choice(
            new Range('a', 'f'),
            new Range('A', 'F'))
            );

            Assert.True(hex.Match("012").Success());
        }

        [Fact]
        public void ReturnsTrueInDoubleChoiceCharacterWithRemainingText()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9'));

            var hex = new Choice(
            digit,
            new Choice(
            new Range('a', 'f'),
            new Range('A', 'F'))
            );

            Assert.True(hex.Match("12").Success());
        }

        [Fact]
        public void ReturnsTrueInDoubleChoiceCharacterWithoutRemainingText()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9'));

            var hex = new Choice(
            digit,
            new Choice(
            new Range('a', 'f'),
            new Range('A', 'F'))
            );

            Assert.True(hex.Match("92").Success());
        }

        [Fact]
        public void ReturnsDigitAndLetterWithoutRemainingText()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9'));

            var hex = new Choice(
            digit,
            new Choice(
            new Range('a', 'f'),
            new Range('A', 'F'))
            );

            Assert.True(hex.Match("a9").Success());
        }

        [Fact]
        public void ReturnsDigitAndLetterWithoutRemainingText2()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9'));

            var hex = new Choice(
            digit,
            new Choice(
            new Range('a', 'f'),
            new Range('A', 'F'))
            );

            Assert.True(hex.Match("f8").Success());
        }

        [Fact]
        public void ReturnsDigitAndUppercaseLetterWithoutRemainingText()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9'));

            var hex = new Choice(
            digit,
            new Choice(
            new Range('a', 'f'),
            new Range('A', 'F'))
            );

            Assert.True(hex.Match("A9").Success());
        }

        [Fact]
        public void ReturnsUppercaseLetterAndNumber()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9'));

            var hex = new Choice(
            digit,
            new Choice(
            new Range('a', 'f'),
            new Range('A', 'F'))
            );

            Assert.True(hex.Match("F8").Success());
        }

        [Fact]
        public void ReturnsLowercaseLetterAndNumber()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9'));

            var hex = new Choice(
            digit,
            new Choice(
            new Range('a', 'f'),
            new Range('A', 'F'))
            );

            Assert.False(hex.Match("g8").Success());
        }

        [Fact]
        public void ReturnsUppercaseLetterAndNumber()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9'));

            var hex = new Choice(
            digit,
            new Choice(
            new Range('a', 'f'),
            new Range('A', 'F'))
            );

            Assert.False(hex.Match("G8").Success());
        }

        [Fact]
        public void ReturnsFalseToEmptyString()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9'));

            var hex = new Choice(
            digit,
            new Choice(
            new Range('a', 'f'),
            new Range('A', 'F'))
            );

           Assert.False(hex.Match("").Success());
        }

        [Fact]
        public void ReturnsFalseToNull()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9'));

            var hex = new Choice(
            digit,
            new Choice(
            new Range('a', 'f'),
            new Range('A', 'F'))
            );

            Assert.False(hex.Match(null).Success());
        }

    }
}
