using System;
using System.ComponentModel;
using Xunit;

namespace Range.Tests
{
    public class RangeTests
    {
        [Fact]
        public void WhitinRange()
        {
            var range = new Range('a', 'f');
            Assert.True(range.Match("bed"));
        }
        [Fact]
        public void OutsideRange()
        {
            var range = new Range('a', 'f');
            Assert.False(range.Match("gadget"));
        }
        [Fact]
        public void FirstInRange()
        {
            var range = new Range('a', 'f');
            Assert.True(range.Match("apple"));
        }
        [Fact]
        public void LastInRange()
        {
            var range = new Range('a', 'f');
            Assert.True(range.Match("flower"));
        }

    }
}
