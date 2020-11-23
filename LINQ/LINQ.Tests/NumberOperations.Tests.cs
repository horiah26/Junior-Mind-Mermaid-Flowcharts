using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace LINQ.Tests
{
    public class NumberOperationsTests
    {
        [Fact]
        public void SegmentsSmallerThanWorks()
        {
            int[] inputArray = { 1, 2, 3 };

            Assert.Collection(NumberOperations.SegmentsSmallerThan(inputArray, 5),
            item => Assert.Equal(new int[] { 1 }, item),
            item => Assert.Equal(new int[] { 1, 2 }, item),
            item => Assert.Equal(new int[] { 2 }, item),
            item => Assert.Equal(new int[] { 2, 3 }, item),
            item => Assert.Equal(new int[] { 3 }, item));
        }

        [Fact]
        public void PlusMinusMixWorks()
        {
            Assert.Collection(NumberOperations.PlusMinusMix(4, 2),
            item => Assert.Equal("+1 +2 +3 -4", item),
            item => Assert.Equal("-1 +2 -3 +4", item));
        }
    }
}