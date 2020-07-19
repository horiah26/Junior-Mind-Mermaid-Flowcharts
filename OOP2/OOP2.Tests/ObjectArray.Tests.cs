using System;
using Xunit;

namespace OOP2.Tests
{
    public class ObjectArrayTests
    {
        [Fact]
        public void CreateArrayWith4Elements()
        {
            var array = new ObjectArray();
            Assert.Equal(4, array.Count);
        }

        [Fact]
        public void CanAddDifferentTypes()
        {
            var array = new ObjectArray();

            object newObject = new object[1];
            int[] integerArray = new int[] { 0, 1, 2 };

            array.Add("word");
            array.Add('c');
            array.Add(true);
            array.Add(null);
            array.Add(5);
            array.Add(newObject);
            array.Add(integerArray);

            Assert.Equal(8, array.Count);

            Assert.Equal("word", array[0]);
            Assert.Equal('c', array[1]);
            Assert.True((bool)array[2]);
            Assert.Null(array[3]);
            Assert.Equal(5, array[4]);
            Assert.Equal(newObject, array[5]);
            Assert.Equal(integerArray, array[6]);
        }
    }
}