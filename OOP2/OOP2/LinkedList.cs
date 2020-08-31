using System;
using System.Collections;
using System.Collections.Generic;

namespace OOP2
{
    public class LinkedList<T> : ICollection<T>
    {
        private Node<T> sentinel = new Node<T>(default);

        public int Count { get; private set; }
        public bool IsReadOnly { get; }

        public Node<T> First => Count != 0 ? sentinel.Next : throw new NullReferenceException("Linked List is Empty");
        public Node<T> Last => Count != 0 ? sentinel.Previous : throw new NullReferenceException("Linked List is Empty");

        public LinkedList()
        {
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
        }

        public LinkedList(T[] array)
        {
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;

            foreach(var element in array)
            {
                Add(element);
            }
        }

        public void Add(T element)
        {
            AddLast(element);
        }

        public void Add(Node<T> node)
        {
            AddLast(node);
        }

        public void AddLast(T element)
        {
            AddLast(new Node<T>(element)); 
        }

        public void AddLast(Node<T> node)
        {
            CheckIfNull(node);
            CheckLinkedToAnotherList(node);

            Insert(sentinel.Previous, node, sentinel);
            Count++;
        }

        public void AddFirst(T element)
        {
            AddFirst(new Node<T>(element));
        }

        public void AddFirst(Node<T> node)
        {
            CheckIfNull(node);
            CheckLinkedToAnotherList(node);

            Insert(sentinel, node, sentinel.Next);
            Count++;
        }

        public void AddAfter(Node<T> node, T element)
        {
            AddAfter(node, new Node<T>(element));
        }

        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            CheckIfNull(node);
            CheckInList(node);
            CheckIfNull(newNode);

            Insert(node, newNode, node.Next);
            Count++;
        }

        public void AddBefore(Node<T> node, T element)
        {
            AddBefore(node, new Node<T>(element));
        }

        public void AddBefore(Node<T> node, Node<T> newNode)
        {
            CheckIfNull(node);
            CheckInList(node);
            CheckIfNull(newNode);

            Insert(node.Previous, newNode, node);
            Count++;
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
           return Remove(Find(data));
        }

        public bool Remove(Node<T> node)
        {            
            CheckIfNull(node);
            CheckInList(node);

            Node<T> foundNode = Finder(node, ForwardSearch());

            if(foundNode != null)
            {
                foundNode.Remove();
                Count--;
                return true;
            }

            return false;                
        }                  

        public void RemoveFirst()
        {
            Remove(First.data);
        }

        public void RemoveLast()
        {
            sentinel.Link(sentinel.Previous.Previous, sentinel.Next);
            Count--;
        }

        public Node<T> Find(T element)
        {
            return Finder(element, ForwardSearch());
        }

        public Node<T> FindLast(T element)
        {
            return Finder(element, BackwardSearch());
        }

        private Node<T> Finder(T element, IEnumerable<Node<T>> searchDirection)
        {
            foreach (Node<T> node in searchDirection)
            {
                if (node.data.Equals(element))
                {
                    return node;
                }
            }

            return null;
        }

        private Node<T> Finder(Node<T> nodeToFind, IEnumerable<Node<T>> searchDirection)
        {
            foreach (Node<T> node in searchDirection)
            {
                if (node.Equals(nodeToFind))
                {
                    return node;
                }
            }

            return null;
        }

        private void Insert(Node<T> previousNode, Node<T> newnode, Node<T> nextNode)
        {
            newnode.Link(previousNode, nextNode);
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

        private IEnumerable<Node<T>> ForwardSearch()
        {
            for (Node<T> node = sentinel.Next; node != sentinel; node = node.Next)
            {
                yield return node;
            }
        }
        private IEnumerable<Node<T>> BackwardSearch()
        {
            for (Node<T> node = sentinel.Previous; node != sentinel; node = node.Previous)
            {
                yield return node;
            }
        }

        private void CheckIfNull(Node<T> node)
        {
            if (node == null)
            {
                throw new NullReferenceException("Node is null");
            }
        }

        private void CheckInList(Node<T> node)
        {
            if (Finder(node, ForwardSearch()) == null)
            {
                throw new InvalidOperationException("Node is not in the current LinkedList<T>.");
            }
        }

        private void CheckLinkedToAnotherList(Node<T> node)
        {
            if (node.Previous != null || node.Next != null)
            {
                throw new InvalidOperationException("Node is linked to another LinkedList<T>.");
            }
        }
    }
}