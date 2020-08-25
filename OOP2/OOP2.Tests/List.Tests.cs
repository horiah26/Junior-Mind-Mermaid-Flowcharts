using System;
using Xunit;

namespace OOP2.Tests
{
    public class ListTests
    {
        [Fact]
        public void CanReadReadonlyList()
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
        public void ThrowsInsertWrongIndexException()
        {
            var array = new List<int>();
            array.Add(1);
            array.Add(2);


            Assert.Throws<ArgumentOutOfRangeException>(() => array.Insert(4, 1));
        }

        [Fact]
        public void ThrowsCopyToWrongArrayDimensionException()
        {
            var listArray = new List<int>();

            listArray.Add(3);
            listArray.Add(10);
            listArray.Add(24);
            listArray.Add(35);
            listArray.Add(15);

            var array = new int[3];

            Assert.Throws<ArgumentOutOfRangeException>(() => listArray.CopyTo(array, 0));
        }

        [Fact]
        public void ThrowsCopyToWrongIndexException()
        {
            var listArray = new List<int>();

            listArray.Add(3);
            listArray.Add(10);
            listArray.Add(24);
            listArray.Add(35);
            listArray.Add(15);

            var array = new int[3];

            Assert.Throws<ArgumentOutOfRangeException>(() => listArray.CopyTo(array, 13));
        }

        [Fact]
        public void CreateListWith4Elements()
        {
            var array = new List<int>();
            Assert.Empty(array);
        }

        [Fact]
        public void CanAddElements()
        {
            var array = new List<int>();
            array.Add(1);
            array.Add(2);

            Assert.Equal(2, array.Count);
            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
        }

        [Fact]
        public void CanAddStrings()
        {
            var array = new List<string>();
            array.Add("1");
            array.Add("2");

            Assert.Equal(2, array.Count);
            Assert.Equal("1", array[0]);
            Assert.Equal("2", array[1]);
        }

        [Fact]
        public void ArrayDoublesAt9Elements()
        {
            var array = new List<int>();

            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Add(6);
            array.Add(7);
            array.Add(8);
            array.Add(9);

            Assert.Equal(9, array.Count);
        }

        [Fact]
        public void ArrayDoublesSize()
        {
            var array = new List<int>();

            array.Add(3);
            array.Add(7);
            array.Add(6);
            array.Add(10);
            array.Add(13);

            Assert.Equal(5, array.Count);

            Assert.Equal(3, array[0]);
            Assert.Equal(7, array[1]);
            Assert.Equal(6, array[2]);
            Assert.Equal(10, array[3]);
            Assert.Equal(13, array[4]);
        }


        [Fact]
        public void ElementsAddedAreCorrect()
        {
            var array = new List<int>();

            array.Add(3);
            array.Add(7);
            array.Add(6);

            Assert.Equal(3, array[0]);
            Assert.Equal(7, array[1]);
            Assert.Equal(6, array[2]);
        }

        [Fact]
        public void CanChangeValueAtPosition()
        {
            var array = new List<int>();

            array.Add(3);
            array.Add(10);

            array[0] = 7;
            array[1] = 5;

            Assert.Equal(7, array[0]);
            Assert.Equal(5, array[1]);
        }

        [Fact]
        public void ReturnsTrueIfContainsValue()
        {
            var array = new List<int>();

            array.Add(3);
            array.Add(10);
            array.Add(24);

            Assert.Contains(10, array);
        }

        [Fact]
        public void ReturnsTrueIfContainsValueOfChar()
        {
            var array = new List<char>();

            array.Add('a');
            array.Add('b');
            array.Add('c');

            Assert.Contains('b', array);
        }


        [Fact]
        public void ReturnsIndexOfElement()
        {
            var array = new List<int>();

            array.Add(3);
            array.Add(10);
            array.Add(24);

            Assert.Equal(1, array.IndexOf(10));
        }

        [Fact]
        public void CanInsertElement()
        {
            var array = new List<int>();

            array.Add(3);
            array.Add(10);
            array.Add(24);

            array.Insert(1, 5);

            Assert.Equal(4, array.Count);

            Assert.Equal(3, array[0]);
            Assert.Equal(5, array[1]);
            Assert.Equal(10, array[2]);
            Assert.Equal(24, array[3]);
        }

        [Fact]
        public void CanClearArray()
        {
            var array = new List<int>();

            array.Add(3);
            array.Add(10);
            array.Add(24);
            array.Add(51);
            array.Add(31);

            array.Clear();

            Assert.Empty(array);
        }

        [Fact]
        public void CanRemoveElementByName()
        {
            var array = new List<int>();

            array.Add(3);
            array.Add(10);
            array.Add(24);
            array.Add(35);
            array.Add(15);

            array.Remove(10);

            Assert.Equal(1, array.IndexOf(24));
            Assert.Equal(4, array.Count);
        }

        [Fact]
        public void CanRemoveElementByIndex()
        {
            var array = new List<int>();

            array.Add(3);
            array.Add(10);
            array.Add(24);
            array.Add(35);
            array.Add(15);

            array.RemoveAt(2);

            Assert.Equal(2, array.IndexOf(35));
            Assert.Equal(4, array.Count);
        }

        [Fact]
        public void CanCopyToArray()
        {
            var listArray = new List<int>();

            listArray.Add(3);
            listArray.Add(10);
            listArray.Add(24);
            listArray.Add(35);
            listArray.Add(15);

            var array = new int[8];

            listArray.CopyTo(array, 0);

            Assert.Equal(3, array[0]);
            Assert.Equal(10, array[1]);
            Assert.Equal(24, array[2]);
            Assert.Equal(35, array[3]);
            Assert.Equal(15, array[4]);
        }

        [Fact]
        public void CanCopyToArrayNonZeroIndex()
        {
            var listArray = new List<int>();

            listArray.Add(3);
            listArray.Add(10);
            listArray.Add(24);
            listArray.Add(35);
            listArray.Add(15);

            var array = new int[16];

            listArray.CopyTo(array, 3);

            Assert.Equal(3, array[3]);
            Assert.Equal(10, array[4]);
            Assert.Equal(24, array[5]);
            Assert.Equal(35, array[6]);
            Assert.Equal(15, array[7]);
        }

        [Fact]
        public void CanRemoveFirstOccurence()
        {
            var listArray = new List<int>();

            listArray.Add(3);
            listArray.Add(10);
            listArray.Add(24);
            listArray.Add(35);
            listArray.Add(15);

            listArray.Remove(10);

            Assert.Equal(3, listArray[0]);
            Assert.Equal(24, listArray[1]);
            Assert.Equal(35, listArray[2]);
            Assert.Equal(15, listArray[3]);
        }
    }
}