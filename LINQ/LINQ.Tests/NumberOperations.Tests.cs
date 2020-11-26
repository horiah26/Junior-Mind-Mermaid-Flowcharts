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

        [Fact]
        public void PythagorasTriosWorks()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Assert.Collection(NumberOperations.PythagorasTrios(numbers),
            item => Assert.Equal((3, 4, 5), item),
            item => Assert.Equal((6, 8, 10), item));
        }
    }
}