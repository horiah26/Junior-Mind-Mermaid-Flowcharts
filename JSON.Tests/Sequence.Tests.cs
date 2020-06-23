using System;
using System.ComponentModel;
using Xunit;

namespace JSON.Tests
{
    public class SequenceTests
    {
        [Fact]
        public void Test1()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            Assert.True(ab.Match("abcd").Success());
            Assert.Equal("cd", ab.Match("abcd").RemainingText());
        }

        [Fact]
        public void Test2()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            Assert.False(ab.Match("ax").Success());
            Assert.Equal("ax", ab.Match("ax").RemainingText());
        }

        [Fact]
        public void Test3()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            Assert.False(ab.Match("def").Success());
            Assert.Equal("def", ab.Match("def").RemainingText());
        }

        [Fact]
        public void Test4()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            Assert.False(ab.Match("").Success());
            Assert.Equal("", ab.Match("").RemainingText());
        }

        [Fact]
        public void Test5()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            Assert.False(ab.Match(null).Success());
            Assert.Null(ab.Match(null).RemainingText());
        }

        [Fact]
        public void Test6()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var abc = new Sequence(
                ab,
                new Character('c')
            );

            Assert.True(abc.Match("abcd").Success());
            Assert.Equal("d", abc.Match("abcd").RemainingText());
        }

        [Fact]
        public void Test7()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var abc = new Sequence(
                ab,
                new Character('c')
            );

            Assert.True(abc.Match("abcd").Success());
            Assert.Equal("d", abc.Match("abcd").RemainingText());
        }

        [Fact]
        public void Test8()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var abc = new Sequence(
                ab,
                new Character('c')
            );

            Assert.False(abc.Match("def").Success());
            Assert.Equal("def", abc.Match("def").RemainingText());
        }

        [Fact]
        public void Test9()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var abc = new Sequence(
                ab,
                new Character('c')
            );

            Assert.False(abc.Match("abx").Success());
            Assert.Equal("abx", abc.Match("abx").RemainingText());
        }

        [Fact]
        public void Test10()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var abc = new Sequence(
                ab,
                new Character('c')
            );

            Assert.False(abc.Match("").Success());
            Assert.Equal("", abc.Match("").RemainingText());
        }

        [Fact]
        public void Test11()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var abc = new Sequence(
                ab,
                new Character('c')
            );

            Assert.False(abc.Match(null).Success());
            Assert.Null(abc.Match(null).RemainingText());
        }

        [Fact]
        public void Test12()
        {

            var hex = new Choice(
                new Range('0', '9'),            
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            Assert.True(hexSeq.Match("u1234").Success());
            Assert.Equal("", hexSeq.Match("u1234").RemainingText());
        }

        [Fact]
        public void Test13()
        {

            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            Assert.True(hexSeq.Match("uabcdef").Success());
            Assert.Equal("ef", hexSeq.Match("uabcdef").RemainingText());
        }

        [Fact]
        public void Test14()
        {

            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            Assert.True(hexSeq.Match("uB005 ab").Success());
            Assert.Equal(" ab", hexSeq.Match("uB005 ab").RemainingText());
        }

        [Fact]
        public void Test15()
        {

            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            Assert.False(hexSeq.Match("abc").Success());
            Assert.Equal("abc", hexSeq.Match("abc").RemainingText());
        }

        [Fact]
        public void Test16()
        {

            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            Assert.False(hexSeq.Match(null).Success());
            Assert.Null(hexSeq.Match(null).RemainingText());
        }

    }
}
