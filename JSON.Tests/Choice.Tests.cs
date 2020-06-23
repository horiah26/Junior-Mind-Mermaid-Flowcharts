using System;
using System.ComponentModel;
using Xunit;

namespace JSON.Tests
{
    public class ChoiceTests
    {
        [Fact]
        public void Test1()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9')
        );

            Assert.True(digit.Match("012").Success());
        }

        [Fact]
        public void Test2()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9')
        );

            Assert.True(digit.Match("12").Success());
        }

        [Fact]
        public void Test3()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9')
        );

            Assert.True(digit.Match("92").Success());
        }

        [Fact]
        public void Test4()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9')
        );

            Assert.False(digit.Match("a9").Success());
        }

        [Fact]
        public void Test5()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9')
        );

            Assert.False(digit.Match("").Success());
        }

        [Fact]
        public void Test6()
        {
            var digit = new Choice(
            new Character('0'),
            new Range('1', '9')
        );

            Assert.False(digit.Match(null).Success());
        }

        [Fact]
        public void HexTest1()
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
        public void HexTest2()
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
        public void HexTest3()
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
        public void HexTest4()
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
        public void HexTest5()
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
        public void HexTest6()
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
        public void HexTest7()
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
        public void HexTest8()
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
        public void HexTest9()
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
        public void HexTest10()
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
        public void HexTest11()
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
