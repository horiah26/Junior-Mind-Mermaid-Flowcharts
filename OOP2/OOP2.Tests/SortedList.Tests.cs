using System;
using Xunit;

namespace OOP2.Tests
{
    public class SortedListTests
    {
        [Fact]
        public void CreateListWith4Elements()
        {
            var array = new SortedList<int>();
            Assert.Empty(array);
        }

        [Fact]
        public void CanAddElements()
        {
            var array = new SortedList<int>();
            array.Add(1);
            array.Add(2);

            Assert.Equal(2, array.Count);
            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
        }

        [Fact]
        public void CanAddStrings()
        {
            var array = new SortedList<string>();
            array.Add("1");
            array.Add("2");

            Assert.Equal(2, array.Count);
            Assert.Equal("1", array[0]);
            Assert.Equal("2", array[1]);
        }

        [Fact]
        public void AddsNumberStringsInOrder()
        {
            var array = new SortedList<string>();
            array.Add("7");
            array.Add("3");
            array.Add("2");

            Assert.Equal(3, array.Count);
            Assert.Equal("2", array[0]);
            Assert.Equal("3", array[1]);
            Assert.Equal("7", array[2]);
        }

        [Fact]
        public void CanInsertStringInOrder()
        {
            var array = new SortedList<string>();
            array.Add("7");
            array.Add("3");
            array.Add("2");

            array.Insert(2, "5");

            Assert.Equal(4, array.Count);
            Assert.Equal("2", array[0]);
            Assert.Equal("3", array[1]);
            Assert.Equal("5", array[2]);
            Assert.Equal("7", array[3]);
        }

        [Fact]
        public void CanInsertMultiLetterStringInOrder()
        {
            var array = new SortedList<string>();
            array.Add("star");
            array.Add("wars");
            array.Add("trek");

            array.Insert(0, "discovery");

            Assert.Equal(4, array.Count);

            Assert.Equal("discovery", array[0]);
            Assert.Equal("star", array[1]);
            Assert.Equal("trek", array[2]);
            Assert.Equal("wars", array[3]);
        }

        [Fact]
        public void CanOrderLetterChars()
        {
            var array = new SortedList<char>();
            array.Add('d');
            array.Add('e');
            array.Add('c');
            array.Add('a');
            array.Add('g');

            array.Insert(1, 'b');

            Assert.Equal(6, array.Count);

            Assert.Equal('a', array[0]);
            Assert.Equal('b', array[1]);
            Assert.Equal('c', array[2]);
            Assert.Equal('d', array[3]);
            Assert.Equal('e', array[4]);
            Assert.Equal('g', array[5]);

        }


        [Fact]
        public void ArrayDoublesAt9Elements()
        {
            var array = new SortedList<int>();

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
            var array = new SortedList<int>();

            array.Add(3);
            array.Add(7);
            array.Add(6);
            array.Add(10);
            array.Add(13);

            Assert.Equal(5, array.Count);

            Assert.Equal(3, array[0]);
            Assert.Equal(6, array[1]);
            Assert.Equal(7, array[2]);
            Assert.Equal(10, array[3]);
            Assert.Equal(13, array[4]);
        }

        [Fact]
        public void ElementsAddedAreInCorrectOrder()
        {
            var array = new SortedList<int>();

            array.Add(3);
            array.Add(7);
            array.Add(6);

            Assert.Equal(3, array[0]);
            Assert.Equal(6, array[1]);
            Assert.Equal(7, array[2]);
        }

        [Fact]
        public void CanChangeValueAtPosition()
        {
            var array = new SortedList<int>();

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
            var array = new SortedList<int>();

            array.Add(3);
            array.Add(10);
            array.Add(24);

            Assert.Contains(10, array);
        }

        [Fact]
        public void ReturnsTrueIfContainsValueOfChar()
        {
            var array = new SortedList<char>();

            array.Add('a');
            array.Add('b');
            array.Add('c');

            Assert.Contains('b', array);
        }

        [Fact]
        public void ReturnsIndexOfElement()
        {
            var array = new SortedList<int>
            {
                3,
                10,
                24
            };

            Assert.Equal(1, array.IndexOf(10));
        }

        [Fact]
        public void CanInsertElement()
        {
            var array = new SortedList<int>();

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
            var array = new SortedList<int>();

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
            var array = new SortedList<int>();

            array.Add(3);
            array.Add(10);
            array.Add(24);
            array.Add(35);
            array.Add(15);

            array.Remove(10);

            Assert.Equal(2, array.IndexOf(24));
            Assert.Equal(4, array.Count);
        }

        [Fact]
        public void CanRemoveElementByIndex()
        {
            var array = new SortedList<int>();

            array.Add(3);
            array.Add(10);
            array.Add(15);
            array.Add(24);
            array.Add(35);


            array.RemoveAt(3);

            Assert.Equal(3, array.IndexOf(35));
            Assert.Equal(4, array.Count);
        }
    }
} 