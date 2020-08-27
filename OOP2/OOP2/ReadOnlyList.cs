using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OOP2
{
    public class ReadOnlyList<T> : IList<T>
    {
        private readonly IList<T> list;

        public ReadOnlyList(List<T> list)
        {
            this.list = list;
        }

        public int Count => list.Count;

        public bool IsReadOnly => true;

        public T this[int index] { get => list[index]; set => ExceptionReadOnly(); }

        public void Add(T element)
        {
            ExceptionReadOnly();
        }

        public void Clear()
        {
            ExceptionReadOnly();
        }

        public bool Contains(T element)
        {
            return list.Contains(element);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ExceptionReadOnly();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public int IndexOf(T element)
        {
            return list.IndexOf(element);
        }

        public void Insert(int index, T element)
        {
            throw ExceptionReadOnly();
        }

        public bool Remove(T element)
        {
            throw ExceptionReadOnly();
        }

        public void RemoveAt(int index)
        {
            ExceptionReadOnly();
        }

        private Exception ExceptionReadOnly()
        {
            throw new ReadOnlyException("List is read only and cannot be modified.");   
        }
    }
}