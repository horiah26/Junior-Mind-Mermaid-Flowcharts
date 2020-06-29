using System;
using Xunit;

namespace JSON.Tests
{
    public class NumberTests
    {
        [Fact]
        public void CanBeZero()
        {
            Number number = new Number();
            Assert.True(number.Match("0").Success());
        }

        [Fact]
        public void DoesNotContainLetters()
        {
            Number number = new Number();
            Assert.False(number.Match("a").Success());
        }

        [Fact]
        public void CanHaveASingleDigit()
        {
            Number number = new Number();
            Assert.True(number.Match("7").Success());
        }

        [Fact]
        public void CanHaveMultipleDigits()
        {
            Number number = new Number();
            Assert.True(number.Match("70").Success());
        }

        [Fact]
        public void IsNotNull()
        {
            Number number = new Number();
            Assert.False(number.Match(null).Success());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            Number number = new Number();
            Assert.False(number.Match(string.Empty).Success()); ;
        }

        [Fact]
        public void CanStartWithZeroReturnsRemaining()
        {
            Number number = new Number();
            Assert.True(number.Match("07").Success());
            Assert.Equal("7", number.Match("07").RemainingText());
        }

        [Fact]
        public void CanBeNegative()
        {
            Number number = new Number();
            Assert.True(number.Match("-26").Success());
        }

        //[Fact(Skip = "Remove this Skip as you implement")]
        //public void CanBeMinusZero()
        //{
        //    Assert.True(IsJsonNumber("-0"));
        //}

        //[Fact(Skip = "Remove this Skip as you implement")]
        //public void CanBeFractional()
        //{
        //    Assert.True(IsJsonNumber("12.34"));
        //}

        //[Fact(Skip = "Remove this Skip as you implement")]
        //public void TheFractionCanHaveLeadingZeros()
        //{
        //    Assert.True(IsJsonNumber("0.00000001"));
        //    Assert.True(IsJsonNumber("10.00000001"));
        //}

        //[Fact(Skip = "Remove this Skip as you implement")]
        //public void DoesNotEndWithADot()
        //{
        //    Assert.False(IsJsonNumber("12."));
        //}

        //[Fact(Skip = "Remove this Skip as you implement")]
        //public void DoesNotHaveTwoFractionParts()
        //{
        //    Assert.False(IsJsonNumber("12.34.56"));
        //}

        //[Fact(Skip = "Remove this Skip as you implement")]
        //public void TheDecimalPartDoesNotAllowLetters()
        //{
        //    Assert.False(IsJsonNumber("12.3x"));
        //}

        //[Fact(Skip = "Remove this Skip as you implement")]
        //public void CanHaveAnExponent()
        //{
        //    Assert.True(IsJsonNumber("12e3"));
        //}

        //[Fact(Skip = "Remove this Skip as you implement")]
        //public void TheExponentCanStartWithCapitalE()
        //{
        //    Assert.True(IsJsonNumber("12E3"));
        //}

        //[Fact(Skip = "Remove this Skip as you implement")]
        //public void TheExponentCanHavePositive()
        //{
        //    Assert.True(IsJsonNumber("12e+3"));
        //}

        //[Fact(Skip = "Remove this Skip as you implement")]
        //public void TheExponentCanBeNegative()
        //{
        //    Assert.True(IsJsonNumber("61e-9"));
        //}

        //[Fact(Skip = "Remove this Skip as you implement")]
        //public void CanHaveFractionAndExponent()
        //{
        //    Assert.True(IsJsonNumber("12.34E3"));
        //}

        //[Fact(Skip = "Remove this Skip as you implement")]
        //public void TheExponentDoesNotAllowLetters()
        //{
        //    Assert.False(IsJsonNumber("22e3x3"));
        //}

        //[Fact(Skip = "Remove this Skip as you implement")]
        //public void DoesNotHaveTwoExponents()
        //{
        //    Assert.False(IsJsonNumber("22e323e33"));
        //}

        //[Fact(Skip = "Remove this Skip as you implement")]
        //public void TheExponentIsAlwaysComplete()
        //{
        //    Assert.False(IsJsonNumber("22e"));
        //    Assert.False(IsJsonNumber("22e+"));
        //    Assert.False(IsJsonNumber("23E-"));
        //}

        //[Fact(Skip = "Remove this Skip as you implement")]
        //public void TheExponentIsAfterTheFraction()
        //{
        //    Assert.False(IsJsonNumber("22e3.3"));
        //}

    }
}