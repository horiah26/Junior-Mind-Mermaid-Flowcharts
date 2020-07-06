using Xunit;

namespace JSON.Tests
{
    public class NumberTests
    {
        Number number = new Number();

        [Fact]
        public void CanBeZero()
        {
            Assert.True(number.Match("0").Success());
            Assert.Equal("", number.Match("0").RemainingText());
        }

        [Fact]
        public void DoesNotContainLetters()
        {
            Assert.False(number.Match("a").Success());
            Assert.Equal("a", number.Match("a").RemainingText());
        }

        [Fact]
        public void CanHaveASingleDigit()
        {
            Assert.True(number.Match("7").Success());
            Assert.Equal("", number.Match("7").RemainingText());
        }

        [Fact]
        public void CanHaveMultipleDigits()
        {
            Assert.True(number.Match("70").Success());
            Assert.Equal("", number.Match("70").RemainingText());
        }

        [Fact]
        public void IsNotNull()
        {
            Assert.False(number.Match(null).Success());
            Assert.Null(number.Match(null).RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            Assert.False(number.Match(string.Empty).Success());
        }

        [Fact]
        public void CanNotStartWithZeroReturnsRemaining()
        {
            Assert.True(number.Match("07").Success());
            Assert.Equal("7", number.Match("07").RemainingText());
        }

        [Fact]
        public void CanBeNegative()
        {
            Assert.True(number.Match("-26").Success());
            Assert.Equal("", number.Match("-26").RemainingText());
        }

        [Fact]
        public void CanBeMinusZero()
        {
            Assert.True(number.Match("-0").Success());
            Assert.Equal("", number.Match("-0").RemainingText());
        }

        [Fact]
        public void CanBeFractional()
        {
            Assert.True(number.Match("12.34").Success());
            Assert.Equal("", number.Match("12.34").RemainingText());
        }

        [Fact]
        public void TheFractionCanHaveLeadingZeros()
        {
            Assert.Equal("", number.Match("0.00000001").RemainingText());
            Assert.Equal("", number.Match("10.00000001").RemainingText());
        }

        [Fact]
        public void DotRemainsIfEndsWithDot()
        {
            Assert.Equal(".", number.Match("12.").RemainingText());
        }

        [Fact]
        public void DoesNotHaveTwoFractionParts()
        {
            Assert.Equal(".56", number.Match("12.34.56").RemainingText());
        }

        [Fact]
        public void TheDecimalPartDoesNotAllowLetters()
        {
            Assert.Equal("x", number.Match("12.3x").RemainingText());
        }

        [Fact]
        public void CanHaveAnExponent()
        {
            Assert.Equal("", number.Match("12e3").RemainingText());
        }

        [Fact]
        public void TheExponentCanStartWithCapitalE()
        {
            Assert.Equal("", number.Match("12E3").RemainingText());
        }

        [Fact]
        public void TheExponentCanHavePositive()
        {
            Assert.Equal("", number.Match("12e+3").RemainingText());
        }

        [Fact]
        public void TheExponentCanBeNegative()
        {
            Assert.Equal("", number.Match("61e-9").RemainingText());
        }

        [Fact]
        public void CanHaveFractionAndExponent()
        {
            Assert.Equal("", number.Match("12.34E3").RemainingText());
        }

        [Fact]
        public void TheExponentDoesNotAllowLetters()
        {
            Assert.Equal("x3", number.Match("22e3x3").RemainingText());
        }

        [Fact]
        public void DoesNotHaveTwoExponents()
        {
            Assert.Equal("e33", number.Match("22e323e33").RemainingText());
        }

        [Fact]
        public void TheExponentIsAlwaysComplete()
        {
            Assert.Equal("e", number.Match("22e").RemainingText());
            Assert.Equal("e+", number.Match("22e+").RemainingText());
            Assert.Equal("E-", number.Match("22E-").RemainingText());
        }

        [Fact]
        public void TheExponentIsAfterTheFraction()
        {
            Assert.Equal(".3", number.Match("22e3.3").RemainingText());
        }

    }
}