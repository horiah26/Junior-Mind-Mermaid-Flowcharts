using Xunit;

namespace JSON.Tests
{
    public class RangeTests
    {
        [Fact]
        public void WhitinRange()
        {
            var range = new Range('a', 'f');
            Assert.True(range.Match("bed").Success());
        }

        [Fact]
        public void OutsideRange()
        {
            var range = new Range('a', 'f');
            Assert.False(range.Match("gadget").Success());
        }

        [Fact]
        public void FirstInRange()
        {
            var range = new Range('a', 'f');
            Assert.True(range.Match("apple").Success());
        }

        [Fact]
        public void LastInRange()
        {
            var range = new Range('a', 'f');
            Assert.True(range.Match("flower").Success());
        }

    }
}
