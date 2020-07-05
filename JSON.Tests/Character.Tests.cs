using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Xunit;

namespace JSON.Tests
{
    public class CharacterTests
    {
        [Fact]
        public void ReturnsTrueGoodLetter()
        {
            var character = new Character('a');
            Assert.True(character.Match("abc").Success());
        }

        [Fact]
        public void ReturnsFalseBadLetter()
        {
            var character = new Character('a');
            Assert.False(character.Match("bac").Success());
        }

        [Fact]
        public void ReturnsFalseUppercase()
        {
            var character = new Character('A');
            Assert.False(character.Match("abc").Success());
        }
    }
}
