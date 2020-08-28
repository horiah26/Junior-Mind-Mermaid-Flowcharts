using System;
using Xunit;

namespace OOP2.Tests
{
    public class LinkedListTests
    {
        [Fact]
        public void CanAddOneElementAndListIsCircular()
        {            
            var linkedList = new LinkedList<int>();

            linkedList.Add(1);

            Assert.Equal(0, linkedList.First.Previous.data);
            Assert.Equal(1, linkedList.First.data);
            Assert.Equal(0, linkedList.First.Next.data);
        }

        [Fact]
        public void CanInitializeWithArray()
        {
            string[] words =
                { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);

            Assert.Equal("the", sentence.First.data);
            Assert.Equal("fox", sentence.First.Next.data);
            Assert.Equal("jumps", sentence.First.Next.Next.data);
            Assert.Equal("over", sentence.Last.Previous.Previous.data);
            Assert.Equal("the", sentence.Last.Previous.data);
            Assert.Equal("dog", sentence.Last.data);

        }

        [Fact]
        public void CanAddTwoElements()
        {            
            var linkedList = new LinkedList<int>();

            linkedList.Add(1);

            Assert.Equal(1, linkedList.First.data);

            linkedList.Add(2);   

            Assert.Equal(1, linkedList.First.data);
            Assert.Equal(2, linkedList.First.Next.data);            
        }

        [Fact]
        public void Clears()
        {            
            var linkedList = new LinkedList<int>
            {
                1,
                2,
                3
            };

            linkedList.Clear();

            Assert.Empty(linkedList);
            Assert.Throws<NullReferenceException>(() => linkedList.First.data);
            Assert.Throws<NullReferenceException>(() => linkedList.Last.data);

            linkedList.Add(1);

            Assert.Equal(1, linkedList.First.data);
            Assert.Equal(1, linkedList.Last.data);
        }

        [Fact]
        public void ContainsWorks()
        {            
            var linkedList = new LinkedList<int>
            {
                1,
                2,
                3
            };


            Assert.Contains(1, linkedList);
            Assert.Contains(2, linkedList);
            Assert.Contains(3, linkedList);

            Assert.DoesNotContain(4, linkedList);
            Assert.DoesNotContain(0, linkedList);            
        }

        [Fact]
        public void CanRemoveByValue()
        {            
            var linkedList = new LinkedList<int>
            {
                1,
                2,
                3
            };                

            linkedList.Remove(2); 

            Assert.Contains(1, linkedList);
            Assert.DoesNotContain(2, linkedList);
            Assert.Contains(3, linkedList);

            linkedList.Remove(3);

            Assert.Contains(1, linkedList);
            Assert.DoesNotContain(2, linkedList);
            Assert.DoesNotContain(3, linkedList);

            linkedList.Remove(1);

            Assert.DoesNotContain(1, linkedList);
            Assert.DoesNotContain(2, linkedList);
            Assert.DoesNotContain(3, linkedList);            
        }

        [Fact]
        public void CanCopyToArray()
        {
            var linkedList = new LinkedList<int>
            {
                1,
                2,
                3
            };

            var array = new int[8];

            linkedList.CopyTo(array, 4);

            Assert.Equal(1, array[4]);
            Assert.Equal(2, array[5]);
            Assert.Equal(3, array[6]);
        }

        [Fact]
        public void RemovesFirst()
        {            
            var linkedList = new LinkedList<int>
            {
                1,
                2,
                3,
                4,
                5
            };

            linkedList.RemoveFirst();

            Assert.Equal(2, linkedList.First.data);
            Assert.Equal(3, linkedList.First.Next.data);
            Assert.Equal(5, linkedList.Last.data);

            linkedList.RemoveFirst();

            Assert.Equal(3, linkedList.First.data);
            Assert.Equal(5, linkedList.Last.data);            
        }

        [Fact]
        public void RemovesLast()
        {
            var linkedList = new LinkedList<int>
            {
                1,
                2,
                3,
                1,
            };

            linkedList.RemoveLast();

            Assert.Equal(1, linkedList.First.data);
            Assert.Equal(2, linkedList.First.Next.data);
            Assert.Equal(3, linkedList.Last.data);

            linkedList.RemoveLast();

            Assert.Equal(1, linkedList.First.data);
            Assert.Equal(2, linkedList.Last.data);           
        }

        [Fact]
        public void CanAddFirst()
        {
            var linkedList = new LinkedList<int>
            {
                1,
                2,
                3,
                1,
            };

            linkedList.AddFirst(6);

            Assert.Equal(6, linkedList.First.data);
            Assert.Equal(1, linkedList.First.Next.data);
            Assert.Equal(1, linkedList.Last.data);

            linkedList.AddFirst(100);

            Assert.Equal(100, linkedList.First.data);
            Assert.Equal(6, linkedList.First.Next.data);
            Assert.Equal(1, linkedList.Last.data);
        }

        [Fact]
        public void CanAddBefore()
        {
            string[] words =
                { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);

            var node = sentence.Find("fox");

            sentence.AddBefore(node, "red");

            Assert.Equal("red", sentence.First.Next.data);
            Assert.Equal("fox", sentence.First.Next.Next.data);

        }

        [Fact]
        public void CanAddAfter()
        {
            string[] words =
                { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);

            var node = sentence.Find("fox");

            sentence.AddAfter(node, "quickly");

            Assert.Equal("quickly", sentence.First.Next.Next.data);
            Assert.Equal("jumps", sentence.First.Next.Next.Next.data);

        }

        [Fact]
        public void CanFindFirst()
        {
            string[] words =
                { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);

            var node = sentence.Find("fox");
            Assert.Equal(sentence.First.Next, node);


            var node2 = sentence.Find("the");
            Assert.Equal(sentence.First, node2);
        }

        [Fact]
        public void CanFindLast()
        {
            string[] words =
                { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);

            var node = sentence.FindLast("fox");
            Assert.Equal(sentence.First.Next, node);


            var node2 = sentence.FindLast("the");
            Assert.Equal(sentence.Last.Previous, node2);
        }
    }
}