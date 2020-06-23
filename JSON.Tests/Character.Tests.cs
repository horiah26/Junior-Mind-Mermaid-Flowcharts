using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Xunit;

namespace JSON.Tests
{
    public class CharacterTests
    {
        [Fact]
        public void OneLetter()
        {
            var character = new Character('a');
            Assert.True(character.Match("abc").Success());
        }

        [Fact]
        public void WrongLetter()
        {
            var character = new Character('a');
            Assert.False(character.Match("bac").Success());
        } 
    }
}
