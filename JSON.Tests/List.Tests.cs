using System;
using Xunit;

namespace JSON.Tests
{
    public class ListTests
    {
        [Fact]
        public void Test1()
        {
            var a = new List(new Range('0', '9'), new Character(','));
  

            Assert.True(a.Match("1,2,3").Success());
            Assert.Equal("", a.Match("1,2,3").RemainingText());
        }
    }
}