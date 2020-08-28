using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace OOP2
{
    public class LinkedList<T> : ICollection<T>
    {
        private readonly Node<T> sentinel = new Node<T>(default);
        public int Count { get; private set; }
        public bool IsReadOnly { get; }

        public Node<T> First => Count != 0 ? sentinel.Next : throw NullNodeException();
        public Node<T> Last => Count != 0 ? sentinel.Previous : throw NullNodeException();
        
        public LinkedList()
        {
            Count = 0;
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
        }

        public LinkedList(T[] array)
        {
            foreach (T element in array)
            {
                Add(element);
            }
        }

        public void Add(T element)
        {
            if(Count == 0)
            {
                new Node<T>(element).Link(sentinel, sentinel);
            }
            else
            {
                new Node<T>(element).Link(sentinel.Previous, sentinel);
            }

            Count++;
        }

        public void AddLast(T element)
        {
            Add(element);
        }

        public void Add(Node<T> node)
        {
            if (Count == 0)
            {
                node.Link(sentinel, sentinel);
            }
            else
            {
                node.Link(sentinel.Previous, sentinel);
            }

            Count++;
        }

        public void AddFirst(T element)
        {
            if (Count == 0)
            {
                new Node<T>(element).Link(sentinel, sentinel);
            }
            else
            {
                new Node<T>(element).Link(sentinel, First);
            }
        }

        public void AddAfter(Node<T> node, T element)
        {
            new Node<T>(element).Link(node, node.Next);
        }

        public void AddBefore(Node<T> node, T element)
        {
            new Node<T>(element).Link(node.Previous, node);
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(T element)
        {
            return Find(element) != null; 
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is null");
            }
            else if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Index must be greater than 0");
            }
            else if (array.Length - arrayIndex <= Count)
            {
                throw new ArgumentOutOfRangeException("The number of elements in the source T[] array is greater than the available space from arrayIndex to the end of the destination array.");
            }

            int arrayCount = 0;

            foreach(T value in this)
            {
                array[arrayIndex + arrayCount] = value;
                arrayCount++;
            }
        }

        public bool Remove(T data)
        {
            Node<T> enumNode = sentinel;

            for (int i = 0; i < Count; i++)
            {
                enumNode = enumNode.Next;

                if (enumNode.data.Equals(data))
                {
                    enumNode.Previous.Next = enumNode.Next;
                    enumNode.Next.Previous = enumNode.Previous;

                    Count--;
                    return true;
                }
            }

            return false;
        }

        public void RemoveFirst()
        {
            Remove(First.data);
        }

        public void RemoveLast()
        {
            sentinel.Link(sentinel.Previous.Previous);
        }

        public Node<T> Find(T element)
        {
            return (Finder(element, "First"));
        }

        public Node<T> FindLast(T element)
        {
            return (Finder(element, "Last"));
        }

        public Node<T> Finder(T element, string startPoint)
        {
            Node<T> enumNode = sentinel;

            for (int i = 0; i < Count; i++)
            {
                if (startPoint == "First")
                {
                    enumNode = enumNode.Next;
                }
                else if (startPoint == "Last")
                {
                    enumNode = enumNode.Previous;
                }
                else
                {
                    throw new ArgumentException("Start point can only be First or Last");
                }

                if (enumNode.data.Equals(element))
                {
                    return enumNode;
                }
            }

            return null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> enumNode = sentinel;

            for (int i = 0; i < Count; i++)
            {
                enumNode = enumNode.Next;
                yield return enumNode.data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Exception NullNodeException()
        {
            throw new NullReferenceException("Node is null");
        }
    }
}