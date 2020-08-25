using System;
using System.Data;
using Xunit;

namespace OOP2.Tests
{
    public class ReadOnlyListTests
    {
        [Fact]
        public void CanReadReadOnlyList()
        {
            var array = new List<int>
            {
                1,
                2
            };

            var readonlyArray = new ReadOnlyList<int>(array);

            Assert.Equal(1, readonlyArray[0]);
            Assert.Equal(2, readonlyArray[1]);
        }

        [Fact]
        public void ThrowsReadOnlyExceptionAdd()
        {
            var array = new List<int>
            {
                1,
                2
            };

            var readonlyArray = new ReadOnlyList<int>(array);

            Assert.Throws<ReadOnlyException>(() => readonlyArray.Add(3));
        }
        [Fact]
        public void ThrowsReadOnlyExceptionInsert()
        {
            var array = new List<int>
            {
                1,
                2
            };

            var readonlyArray = new ReadOnlyList<int>(array);

            Assert.Throws<ReadOnlyException>(() => readonlyArray.Insert(3,1));
        }

        [Fact]
        public void ThrowsReadOnlyExceptionRemove()
        {
            var array = new List<int>
            {
                1,
                2
            };

            var readonlyArray = new ReadOnlyList<int>(array);

            Assert.Throws<ReadOnlyException>(() => readonlyArray.Remove(1));
        }

        [Fact]
        public void ThrowsReadOnlyExceptionRemoveAt()
        {
            var array = new List<int>
            {
                1,
                2
            };

            var readonlyArray = new ReadOnlyList<int>(array);

            Assert.Throws<ReadOnlyException>(() => readonlyArray.RemoveAt(1));
        }

        [Fact]
        public void ThrowsReadOnlyExceptionCopyTo()
        {
            var array = new List<int>
            {
                1,
                2
            };

            var destinationArray = new int[4];

            var readonlyArray = new ReadOnlyList<int>(array);

            Assert.Throws<ReadOnlyException>(() => readonlyArray.CopyTo(destinationArray, 0));
        }

        [Fact]
        public void ThrowsReadOnlyExceptionClear()
        {
            var array = new List<int>
            {
                1,
                2
            };

            var readonlyArray = new ReadOnlyList<int>(array);

            Assert.Throws<ReadOnlyException>(() => readonlyArray.Clear());
        }
    }
}