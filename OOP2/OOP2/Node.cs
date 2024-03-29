﻿namespace OOP2
{
    public class Node<T>
    {
        public T data;
        public Node<T> Next{ get; set; }
        public Node<T> Previous{ get; set; }

        public Node(T data)
        {
            this.data = data;
            Next = null;
            Previous = null;
        }

        public void Link(Node<T> previousNode, Node<T> nextNode)
        {
            previousNode.Next = this;
            Previous = previousNode;

            Next = nextNode;
            nextNode.Previous = this;
        }

        public void Remove()
        {
            Previous.Next = Next;
            Next.Previous = Previous;        
        }
    }
}