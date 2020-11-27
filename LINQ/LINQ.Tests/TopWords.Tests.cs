using Xunit;

namespace LINQ.Tests
{
    public class TopWordsTests
    {
        [Fact]
        public void TopWordsWork()
        {
            string text = "Nory was a Catholic because her mother was a Catholic, and Nory’s mother was a Catholic because her father was a Catholic, and her father was a Catholic because his mother was a Catholic, or had been";

            Assert.Collection(TopWords.TopWordsInText(text),
                item => Assert.Equal("was", item),
                item => Assert.Equal("a", item),
                item => Assert.Equal("Catholic", item),
                item => Assert.Equal("because", item),
                item => Assert.Equal("her", item),
                item => Assert.Equal("mother", item),
                item => Assert.Equal("and", item),
                item => Assert.Equal("father", item),
                item => Assert.Equal("Nory", item),
                item => Assert.Equal("Nory’s", item),
                item => Assert.Equal("his", item),
                item => Assert.Equal("or", item),
                item => Assert.Equal("had", item),
                item => Assert.Equal("been", item));
        }
    }
}