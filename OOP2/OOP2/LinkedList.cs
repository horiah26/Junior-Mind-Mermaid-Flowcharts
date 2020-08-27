using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace OOP2
{
    class LinkedList<T> : ICollection<T>
    {

        public Node<T> sentinel = new Node<T>(default);
        public int Count { get; private set; }

        public bool IsReadOnly { get; private set; }

        public Node<T> First => Count != 0 ? sentinel.Next : throw NullNodeException();
        public Node<T> Last => Count != 0 ? sentinel.Previous : throw NullNodeException();

        private Exception NullNodeException()
        {
            throw new NotImplementedException();
        }

        public void Add(T element)
        {
            if(Count == 0) 
            {   Node<T> newNode = new Node<T>(element);
                newNode.Link(sentinel);
            }
            else
            {
                new Node<T>(element).Link(sentinel, sentinel);
            }
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(T element)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T element)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}