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
        public Node<T> sentinel = new Node<T>(default);
        public int Count { get; private set; }
        public bool IsReadOnly { get; private set; }

        public Node<T> First => Count != 0 ? sentinel.Next : throw NullNodeException();
        public Node<T> Last => Count != 0 ? sentinel.Previous : throw NullNodeException();

        public LinkedList()
        {
            Count = 0;
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
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

        public void Clear()
        {
            Count = 0;
            sentinel = new Node<T>(default);
        }

        public bool Contains(T element)
        {
            foreach(var v in this)
            {
                if (v.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
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