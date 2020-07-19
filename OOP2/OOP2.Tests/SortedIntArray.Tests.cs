using System;
using Xunit;

namespace OOP2.Tests
{
    public class SortedIntArrayTests
    {
        [Fact]
        public void CreateArrayWith4Elements()
        {
            var array = new SortedIntArray();
            Assert.Equal(4, array.Count);
        }

        [Fact]
        public void CanInsertOneElement()
        {
            var array = new SortedIntArray();

            array.Insert(0, 3);

            Assert.Equal(4, array.Count);

            Assert.Equal(3, array[0]);
        }

        [Fact]
        public void CanInsertSeveralElements()
        {
            var array = new SortedIntArray();

            array.Insert(0, 3);
            array.Insert(1, 6);
            array.Insert(2, 7);

            Assert.Equal(4, array.Count);

            Assert.Equal(3, array[0]);
            Assert.Equal(6, array[1]);
            Assert.Equal(7, array[2]);
        }

        [Fact]
        public void CanInsertAndAddSeveralElementsInSamePosition()
        {
            var array = new SortedIntArray();

            array.Insert(0, 9);
            array.Insert(0, 3);
            array.Add(6);
            array.Add(7);
            array.Add(8);
            array.Insert(0, 1);    

            Assert.Equal(8, array.Count);

            Assert.Equal(1, array[0]);
            Assert.Equal(3, array[1]);
            Assert.Equal(6, array[2]);
            Assert.Equal(7, array[3]);
            Assert.Equal(8, array[4]);
            Assert.Equal(9, array[5]);
        }

        [Fact]
        public void ArrayDoublesAt9Elements()
        {
            var array = new SortedIntArray();

            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Add(6);
            array.Add(7);
            array.Add(8);
            array.Add(9);

            Assert.Equal(16, array.Count);
        }

        [Fact]
        public void ArrayDoublesSize()
        {
            var array = new SortedIntArray();

            array.Add(3);
            array.Add(7);
            array.Add(6);
            array.Add(10);
            array.Add(13);

            Assert.Equal(8, array.Count);

            Assert.Equal(3, array[0]);
            Assert.Equal(6, array[1]);
            Assert.Equal(7, array[2]);
            Assert.Equal(10, array[3]);
            Assert.Equal(13, array[4]);
        }

        [Fact]
        public void ElementsAddedAreCorrect()
        {
            var array = new SortedIntArray();

            array.Add(3);
            array.Add(7);
            array.Add(6);

            Assert.Equal(3, array[0]);
            Assert.Equal(6, array[1]);
            Assert.Equal(7, array[2]);
        }

        [Fact]
        public void SetIndexOnlyIfCorrect()
        {
            var array = new SortedIntArray();

            array.Add(3);
            array.Add(10);

            array[1] = 5;

            Assert.Equal(3, array[0]);
            Assert.Equal(5, array[1]);
            Assert.Equal(10, array[2]);
        }

        [Fact]
        public void DoesNotSetByIndexIfExistingElementIsBigger()
        {
            var array = new SortedIntArray();

            array.Add(3);
            array.Add(10);

            array[0] = 5;

            Assert.Equal(3, array[0]);
            Assert.Equal(10, array[1]);
        }

        [Fact]
        public void SetIndexOnlyIfCorrectTwoNumbers()
        {
            var array = new SortedIntArray();

            array.Add(3);
            array.Add(10);

            array[1] = 5;
            array[2] = 7;

            Assert.Equal(3, array[0]);
            Assert.Equal(5, array[1]);
            Assert.Equal(7, array[2]);
            Assert.Equal(10, array[3]);
        }

        [Fact]
        public void DoesNotSetIndexIfAddedInWrongOrder()
        {
            var array = new SortedIntArray();

            array.Add(3);
            array.Add(10);

            array[2] = 7;
            array[1] = 5;

            Assert.Equal(3, array[0]);
            Assert.Equal(5, array[1]);
            Assert.Equal(10, array[2]);
        }

        [Fact]
        public void ReturnsTrueIfContainsValue()
        {
            var array = new SortedIntArray();

            array.Add(3);
            array.Add(10);
            array.Add(24);

            Assert.True(array.Contains(10));
        }

        [Fact]
        public void ReturnsIndexOfElement()
        {
            var array = new SortedIntArray();

            array.Add(31);
            array.Add(10);
            array.Add(24);

            Assert.Equal(0, array.IndexOf(10));
        }

        [Fact]
        public void CanInsertElement()
        {
            var array = new SortedIntArray();

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
        public void CanInsertElementInlastElementPosition()
        {
            var array = new SortedIntArray();

            array.Add(3);
            array.Add(10);
            array.Add(24);

            array.Insert(3, 35);

            Assert.Equal(4, array.Count);

            Assert.Equal(3, array[0]);
            Assert.Equal(10, array[1]);
            Assert.Equal(24, array[2]);
            Assert.Equal(35, array[3]);
        }

        [Fact]
        public void CanInsertAtTheEndOfUsedArray()
        {
            var array = new SortedIntArray();

            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);

            array.Insert(5, 6);

            Assert.Equal(8, array.Count);

            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(3, array[2]);
            Assert.Equal(4, array[3]);
            Assert.Equal(5, array[4]);
            Assert.Equal(6, array[5]);
            Assert.Equal(0, array[6]);
            Assert.Equal(0, array[7]);
        }

        [Fact]
        public void CannotInsertElementInBadPlace()
        {
            var array = new SortedIntArray();

            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);

            array.Insert(6, 6);

            Assert.Equal(8, array.Count);

            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(3, array[2]);
            Assert.Equal(4, array[3]);
            Assert.Equal(5, array[4]);
            Assert.Equal(0, array[5]);
            Assert.Equal(0, array[6]);
            Assert.Equal(0, array[7]);
        }

        [Fact]
        public void CanClearArray()
        {
            var array = new SortedIntArray();

            array.Add(3);
            array.Add(10);
            array.Add(24);
            array.Add(51);
            array.Add(31);

            array.Clear();

            Assert.Equal(0, array.Count);
        }

        [Fact]
        public void CanRemoveElementByName()
        {
            var array = new SortedIntArray();

            array.Add(3);
            array.Add(10);
            array.Add(24);
            array.Add(35);
            array.Add(15);

            array.Remove(10);

            Assert.Equal(2, array.IndexOf(24));
            Assert.Equal(8, array.Count);
        }

        [Fact]
        public void CanRemoveElementByIndex()
        {
            var array = new SortedIntArray();

            array.Add(3);
            array.Add(10);
            array.Add(24);
            array.Add(35);
            array.Add(15);

            array.RemoveAt(2);

            Assert.Equal(2, array.IndexOf(24));
            Assert.Equal(8, array.Count);
        }
    }
}