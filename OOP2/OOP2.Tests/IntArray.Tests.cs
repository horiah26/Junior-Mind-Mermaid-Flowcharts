using System;
using Xunit;

namespace OOP2.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CreateEmptyArray()
        {
            var array = new IntArray();
            Assert.Equal(0, array.Count());
        }

        [Fact]
        public void CanAddOneElement()
        {
            var array = new IntArray();
            array.Add(1);
            Assert.Equal(1, array.Count());
        }

        [Fact]
        public void CanAddSeveralElements()
        {
            var array = new IntArray();

            array.Add(3);
            array.Add(7);
            array.Add(6);

            Assert.Equal(3, array.Count());
        }


        [Fact]
        public void ElementsAddedAreCorrect()
        {
            var array = new IntArray();

            array.Add(3);
            array.Add(7);
            array.Add(6);

            Assert.Equal(3, array.Element(0));
            Assert.Equal(7, array.Element(1));
            Assert.Equal(6, array.Element(2));
        }

        [Fact]
        public void CanChangeValueAtPosition()
        {
            var array = new IntArray();

            array.Add(3);
            array.Add(10);

            array.SetElement(0, 7);
            array.SetElement(1, 5);

            Assert.Equal(7, array.Element(0));
            Assert.Equal(5, array.Element(1));
        }

        [Fact]
        public void ReturnsTrueIfContainsValue()
        {
            var array = new IntArray();

            array.Add(3);
            array.Add(10);
            array.Add(24);

            Assert.True(array.Contains(10));
        }

        [Fact]
        public void CanCheckExistant()
        {
            var array = new IntArray();

            array.Add(3);
            array.Add(10);
            array.Add(24);

            Assert.True(array.Contains(10));
        }

        [Fact]
        public void ReturnsIndexOfElement()
        {
            var array = new IntArray();

            array.Add(3);
            array.Add(10);
            array.Add(24);

            Assert.Equal(1, array.IndexOf(10));
        }

        [Fact]
        public void CanInsertElement()
        {
            var array = new IntArray();

            array.Add(3);
            array.Add(10);
            array.Add(24);

            array.Insert(1, 5);

            Assert.Equal(4, array.Count());

            Assert.Equal(3, array.Element(0));
            Assert.Equal(5, array.Element(1));
            Assert.Equal(10, array.Element(2));
            Assert.Equal(24, array.Element(3));
        }

        [Fact]
        public void CanClearArray()
        {
            var array = new IntArray();

            array.Add(3);
            array.Add(10);
            array.Add(24);

            array.Clear();

            Assert.Equal(0, array.Count());
        }

        [Fact]
        public void CanRemoveElementByName()
        {
            var array = new IntArray();

            array.Add(3);
            array.Add(10);
            array.Add(24);

            array.Remove(10);

            Assert.Equal(1, array.IndexOf(24));
            Assert.Equal(2, array.Count());
        }

        [Fact]
        public void CanRemoveElementByIndex()
        {
            var array = new IntArray();

            array.Add(3);
            array.Add(10);
            array.Add(24);

            array.RemoveAt(1);

            Assert.Equal(1, array.IndexOf(24));
            Assert.Equal(2, array.Count());
        }
    }
}